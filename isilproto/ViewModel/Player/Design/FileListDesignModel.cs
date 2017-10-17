using Cacm.Isils.Model;
using Cacm.Isils.Model.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Cacm.Isils.ViewModel
{
    public class FileListDesignModel:FileListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static FileListDesignModel Instance => new FileListDesignModel();

        #endregion

        #region Constructor
        public FileListDesignModel()
        {

            FileListItemsReverse = new ObservableCollection<MultimediaFilesModel>
              {
                  new MultimediaFilesModel
                  {
                       ItemType = PlayerFileType.Audio,
            FileName = "Audiofile.wav",
            FullPath = "C:\\Users\\sumit\\Desktop\\fasetto-word-develop\\Source\\" ,
            Duration = "00:22:12"
                   },
                            new MultimediaFilesModel
                  {
                       ItemType = PlayerFileType.Audio,
            FileName = "Audiofile.wav",
            FullPath = "C:\\Users\\sumit\\Desktop\\fasetto-word-develop\\Source\\" ,
            Duration = "00:22:12"
                   },
                                      new MultimediaFilesModel
                  {
                       ItemType = PlayerFileType.Audio,
            FileName = "Audiofile.wav",
            FullPath = "C:\\Users\\sumit\\Desktop\\fasetto-word-develop\\Source\\" ,
            Duration = "00:22:12"
                   },
                                                new MultimediaFilesModel
                  {
                       ItemType = PlayerFileType.Audio,
            FileName = "Audiofile.wav",
            FullPath = "C:\\Users\\sumit\\Desktop\\fasetto-word-develop\\Source\\" ,
            Duration = "00:22:12"
                   },
                                                          new MultimediaFilesModel
                  {
                       ItemType = PlayerFileType.Audio,
            FileName = "Audiofile.wav",
            FullPath = "C:\\Users\\sumit\\Desktop\\fasetto-word-develop\\Source\\" ,
            Duration = "00:22:12"
                   },
                                                                    new MultimediaFilesModel
                  {
                       ItemType = PlayerFileType.Audio,
            FileName = "Audiofile.wav",
            FullPath = "C:\\Users\\sumit\\Desktop\\fasetto-word-develop\\Source\\" ,
            Duration = "00:22:12"
                   },
                                                                              new MultimediaFilesModel
                  {
                       ItemType = PlayerFileType.Audio,
            FileName = "Audiofile.wav",
            FullPath = "C:\\Users\\sumit\\Desktop\\fasetto-word-develop\\Source\\" ,
            Duration = "00:22:12"
                   },

                  new MultimediaFilesModel
                  {
                       ItemType = PlayerFileType.Audio,
            FileName = "Audiofile.mp3",
            FullPath = "C:\\umit\\Desktop\\fasetto-word-develop\\Source\\" ,
            Duration = "00:21:12"
                   },
                  new MultimediaFilesModel
                  {
                       ItemType = PlayerFileType.Audio ,
            FileName = "Audiofile.mp3",
            FullPath = "C:\\umit\\Desktop\\fasetto-word-develop\\Source\\" ,
            Duration = "00:21:12"
                   },
                  new MultimediaFilesModel
                  {
                       ItemType = PlayerFileType.Video ,
            FileName = "Audiofile.avi",
            FullPath = "C:\\Users\\sumit\\Desktop\\fasetto-word-develop\\Source\\" ,
            Duration = "00:31:12"
                   }

              };
        }
        #endregion
    }
}
