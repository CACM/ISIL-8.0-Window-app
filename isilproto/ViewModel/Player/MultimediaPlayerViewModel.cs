using Cacm.Isils.Model.Base;
using Cacm.Isils.ViewModel.Base;
using System.Windows.Input;
using System.Threading.Tasks;
using WpfAppBar;
using System.Windows;
using Cacm.Isils.Model;
using System;
using Meta.Vlc.Wpf;
using NAudio.Wave;
using System.IO;

namespace Cacm.Isils.ViewModel
{
    class MultimediaPlayerViewModel : BaseViewModel
    {
        #region Private
        /// <summary>
        /// The instance for singleton class
        /// </summary>
        private static MultimediaPlayerViewModel instance = null;
        /// <summary>
        /// The toolbar model for application toolbar button
        /// </summary>
        private MultimediaPlayerModel player;
        private VlcPlayer vlc;
        private WaveIn waveIn;
        private WaveFileWriter writer;
        private String MediaFullFileNameString;
        #endregion

        #region Public
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static MultimediaPlayerViewModel Instance { get { return instance ?? (instance = new MultimediaPlayerViewModel()); } }

        public VlcPlayer Vlc
        {
            get => vlc;
            set { vlc = value; OnPropertyChanged(nameof(Vlc)); }
        }
        /// <summary>
        /// Gets or sets the tool bar.
        /// </summary>
        /// <value>
        /// The tool bar.
        /// </value>
        public MultimediaPlayerModel Player
        {
            get => player;
            set { player = value; OnPropertyChanged(nameof(Player)); }
        }
        #endregion

        #region Commands
        public ICommand PlayPauseCommand { get; set; }
        public ICommand RecordingCommand { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationToolBarViewModel"/> class.
        /// </summary>
        public MultimediaPlayerViewModel()
        {
            PlayPauseCommand = new RelayParameterizedCommand(async (parameter) => await PlayPauseCommandImplementation(parameter));

            RecordingCommand = new RelayParameterizedCommand(async (parameter) => await RecordingCommandImplementation(parameter));

            if (instance == null)
            {
                player = new MultimediaPlayerModel();
                //  Console.Write("instance" + toolbar.PollStatus);
            }
            player.AudioVolume = .5f;//volume position on app startup

         }

        #endregion

        #region Implementation Methods
        private async Task PlayPauseCommandImplementation(object parameter)
        {
            if (vlc.VlcMediaPlayer.State == Meta.Vlc.Interop.Media.MediaState.Ended)
            {
                vlc.Stop();
                vlc.Play();
            }

            vlc.PauseOrResume();
           


            await Task.Delay(1);
        }
        private async Task RecordingCommandImplementation(object parameter)
        {
            if ((bool)parameter)
            {
                try
                {
                    System.DateTime dateTime = DateTime.Now;

                    waveIn = new WaveIn();
                    waveIn.DeviceNumber = 0;
                    waveIn.DataAvailable += waveIn_DataAvailable;
                    int sampleRate = 128000; // 8 kHz
                    int channels = 2; // mono
                    waveIn.WaveFormat = new WaveFormat(sampleRate, channels);

                    string MediaFileName = "My Documents/ISILS_Briefcase/ClassRec-" + dateTime.Day + "-" + dateTime.Month + "-" + dateTime.Year + "_" + dateTime.Hour + "_" + dateTime.Minute + "_" + dateTime.Second + ".wav";
                    Uri MediaFullFileName = new Uri(new Uri(Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments)), MediaFileName);
                    if (!Directory.Exists(Path.GetDirectoryName(MediaFullFileName.LocalPath)))
                    { 
                        // Try to create the directory.
                        Directory.CreateDirectory(Path.GetDirectoryName(MediaFullFileName.LocalPath));
                    }

               
                    MediaFullFileNameString = Convert.ToString(MediaFullFileName.LocalPath);
                 //   MessageBox.Show(MediaFullFileName.LocalPath);
                    //MediaFullFileNameString = @MediaFullFileNameString;
                    writer = new WaveFileWriter(MediaFullFileName.LocalPath, waveIn.WaveFormat);
                    waveIn.StartRecording();
                  
                }
                catch (Exception ex)
                {
                    // this.ErrorPopup.IsOpen = true;
                    // ErrorMsgLabel.Content = ex.Message;

                }
            }
            else
            {
                waveIn.StopRecording();
                waveIn.Dispose();
                writer.Close();
                writer = null;

              

            }

     



            await Task.Delay(1);
        }
        #endregion

        #region Helper Methods
        void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            byte[] buffer = e.Buffer;
            int bytesRecorded = e.BytesRecorded;
            WriteToFile(buffer, bytesRecorded);
    

        }
        private void WriteToFile(byte[] buffer, int bytesRecorded)
        {

            writer.WriteData(buffer, 0, bytesRecorded);

        }
        #endregion
    }

}
