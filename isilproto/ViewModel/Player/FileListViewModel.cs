using Cacm.Isils.Model;
using Cacm.Isils.Model.Base;
using Cacm.Isils.ViewModel.Base;
using System.Collections.Generic;
using System.Windows.Input;
using System;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Security;
using Cacm.Isils.Model.Data;
using System.IO;
using System.Linq;

namespace Cacm.Isils.ViewModel
{
    /// <summary>
    /// view model for file list history of the player
    /// </summary>
    /// <seealso cref="Cacm.Isils.Model.Base.BaseViewModel" />
   public class FileListViewModel : BaseViewModel
    {
        #region private
        private ObservableCollection<MultimediaFilesModel> _fileListItems;  // student list
        private ObservableCollection<MultimediaFilesModel> _fileListItemsReverse;  // student list
        #endregion

        #region Public

    
        private ObservableCollection<MultimediaFilesModel> FileListItems
        {
            get => _fileListItems; set { _fileListItems = value; OnPropertyChanged(nameof(FileListItems)); }
        }
        /// <summary>
        /// Gets or sets the items for files.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public ObservableCollection<MultimediaFilesModel> FileListItemsReverse
        {
            get => _fileListItemsReverse; set { _fileListItemsReverse = value; OnPropertyChanged(nameof(FileListItemsReverse)); }
        }
 
      
        #endregion

        #region Commands

        public ICommand FileBrowseCommand { get; set; }
        public ICommand PlayCommand { get; set; }

        #endregion

        #region Constructor
        public FileListViewModel()
        {
            FileListItems = new ObservableCollection<MultimediaFilesModel>();
            FileListItemsReverse = new ObservableCollection<MultimediaFilesModel>();
            FileBrowseCommand = new RelayCommand(async () => await FileBrowseCommandImplementation());

            PlayCommand = new RelayParameterizedCommand(async (parameter) => await IsPlayingCommandImplementation(parameter));


        }




        #endregion

        #region Implementation
        private async Task IsPlayingCommandImplementation(object parameter)
        {
          
            foreach (var file in FileListItems)
                {
                    if (File.Exists(parameter as string))
                    {
                        file.IsPlaying = file.FullPath == (parameter as string) ? true:false ;
                    }
                    else
                    {
                        if(file.FullPath== (parameter as string))
                        {
                            FileListItems.Remove(file);
                        break;
                        }

                    }
                }

            if (File.Exists(parameter as string))
            {
                MultimediaPlayerViewModel.Instance.Vlc.LoadMedia((parameter as string));
                MultimediaPlayerViewModel.Instance.Vlc.Play();
                await Task.Delay(1);
            }
           
           
        }

        /// <summary>
        /// Files the browse command implementation.
        /// </summary>
        /// <returns></returns>
        private async Task FileBrowseCommandImplementation()
        {

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Multiselect = true; //allow multiple file select
            dlg.Title = "ISIL File Browser";
            // Set filter for file extension and default file extension 
            dlg.Filter = "Media Files|VIDEO_TS.IFO;*.TRAILERS;*.URL;*.ASX;*.B4S; *.M3U;*.PLS;*.WPL;*.ZPL;*.ASF;*.AVI;*.AVS;*.DAT;*.FLC; *.FLI;*.MKV;*.MOV;*.MP4;*.MPG;*.MPEG;*.M2V;*.OGM;*.PART; *.VOB;*.RM;*.RAM;*.RMM;*.RMVB;*.SWF;*.TS;*.TP;*.WMV; *.AAC;*.AC3;*.APE;*.CDA;*.DTS;*.FLAC;*.MID;*.MKA;*.MP2; *.MP3;*.MPA;*.MPC;*.OGG;*.RA;*.WAV;*.WMA;*.7Z;*.ARJ;*.BZ2; *.CAB;*.RAR;*.ZIP| Video Files|*.ASX;*.B4S;*.M3U;*.PLS;*.WPL;*.ZPL;*.ASF; *.AVI;*.AVS;*.DAT;*.FLC;*.FLI;*.MKV;*.MOV;*.MP4;*.MPG; *.MPEG;*.M2V;*.OGM;*.PART;*.VOB;*.RM;*.RAM;*.RMM; *.RMVB;*.SWF;*.TS;*.TP;*.WMV;*.7Z;*.ARJ;*.BZ2;*.CAB; *.RAR;*.ZIP| Audio Files|*.ASX;*.B4S;*.M3U;*.PLS;*.WPL;*.ZPL;*.AAC; *.AC3;*.APE;*.CDA;*.DTS;*.FLAC;*.MID;*.MKA;*.MP2;*.MP3; *.MPA;*.MPC;*.OGG;*.RA;*.WAV;*.WMA;*.7Z;*.ARJ;*.BZ2; *.CAB;*.RAR;*.ZIP| Play Lists|*.ASX;*.B4S;*.M3U;*.PLS;*.WPL;*.ZPL;*.7Z; *.ARJ;*.BZ2;*.CAB;*.RAR;*.ZIP| CD Audio|*.CDA | Presentation|*.pptx;*.ppt;*.docx;*.doc;*.xls;*.xlsx | Images|*.BMP;*.GIF;*.JPEG;*.JPG;*.JPS;*.PNG| All Files|*.*'";
            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();
           
            if (result == true & ClearIsPlaying())
            {
                try
                {
                    foreach (String file in dlg.FileNames)
                    {
                       MultimediaFilesModel fileitem = new MultimediaFilesModel
                        {
                            FileName = Path.GetFileName(file),
                            FullPath = file,
                            ItemType = GetFileType(file)
                        };

                        var indexFile = FileListItems.IndexOf(FileListItems.Where(X => X.FullPath == file).FirstOrDefault());
                        if (indexFile > -1)
                        {
                            FileListItems.RemoveAt(indexFile);                        
                            FileListItems.Add(fileitem);
                        }
                        else
                        {                           
                            FileListItems.Add(fileitem);
                        }

                    }

                    //reverse the items
                    var TempFileListItems = FileListItems;
                    FileListItemsReverse = new ObservableCollection<MultimediaFilesModel>(TempFileListItems.Reverse());

                    MultimediaPlayerViewModel.Instance.Vlc.LoadMedia(FileListItems[FileListItems.Count-1].FullPath);
                    FileListItems[FileListItems.Count - 1].IsPlaying = true;

                    MultimediaPlayerViewModel.Instance.Vlc.Play();
                }

                catch (SecurityException ex)
                {
                    // The user lacks appropriate permissions to read files, discover paths, etc.
                    FileListItems.RemoveAt(FileListItems.Count - 1);

                }
                catch (Exception ex)
                {
                    FileListItems.RemoveAt(FileListItems.Count - 1);

                }
                // textBox1.Text = filename;
            }
            await Task.Delay(1);
        }
        #endregion

        #region function
     private bool ClearIsPlaying()
        {
            foreach (var file in FileListItems)
            {
                file.IsPlaying =  false;
            }
            return true;
        }
       
        #endregion

        #region Helper

        private string[] AudioExtensionList  = { ".m4a", ".m4b", ".mp3", ".wav",".mid" };
        private string[] VideoExtensionList = {
            ".webm", ".mkv", ".flv",
            ".avi", ".mov", ".mp4",
            ".mpg", ".mpeg", ".m4v", ".3gp"
        };
        private PlayerFileType GetFileType(String FilePath)
        {
          String extension = Path.GetExtension(FilePath);

          return Array.IndexOf(AudioExtensionList, extension) > -1 ? PlayerFileType.Audio : Array.IndexOf(VideoExtensionList, extension) > -1 ? PlayerFileType.Video : PlayerFileType.Others;

        }

   

        #endregion
    }
}
