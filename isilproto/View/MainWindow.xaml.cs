using Cacm.Isils.ViewModel;
using NAudio.CoreAudioApi;
using System;
using System.Windows;
using System.Windows.Forms;
using Meta.Vlc;
using Meta.Vlc.Interop.Media;
using CefSharp;
using System.ComponentModel;

namespace Cacm.Isils.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MMDevice device;
        public MainWindow()
        {
            DataContext = ApplicationToolBarViewModel.Instance;
         
            InitializeComponent();
            MultimediaPlayerViewModel.Instance.Vlc = Player;
            Player.StateChanged += Vlc_StateChanged;

       

            #region audio controller 
            MMDeviceEnumerator DevEnum = new MMDeviceEnumerator();
            device = DevEnum.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            device.AudioEndpointVolume.OnVolumeNotification += AudioEndpointVolume_OnVolumeNotification;
            #endregion
        }

       

        private void Vlc_StateChanged(object sender, ObjectEventArgs<MediaState> e)
        {
           
            ApplicationToolBarViewModel.Instance.MultimediaPlayer.Player.IsPlaying = Player.VlcMediaPlayer.State == MediaState.Playing ? true : false;
        }

        /// <summary>
        /// on window volue change notification which sync to local instance.
        /// </summary>
        /// <param name="data">The data.</param>
        private void AudioEndpointVolume_OnVolumeNotification(AudioVolumeNotificationData data)
        {
           
            if (data.Muted == true)
            {
                //System.Windows.MessageBox.Show(data.Muted.ToString());
                ApplicationToolBarViewModel.Instance.MultimediaPlayer.Player.AudioVolume = 0;
            }
            else
            {
                ApplicationToolBarViewModel.Instance.MultimediaPlayer.Player.AudioVolume = data.MasterVolume;
            }
            
        }

        private void SideDock_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = null; // release the datacontext so the static resourse remain unchnaged. 
            var SideDock = new SideDock();
            SideDock.Show();
            base.Close();
            //AppBarFunctions.SetAppBar(this, ABEdge.None);
            
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            CloseImplementationMethod();
            base.Close();
        }

        private void CloseImplementationMethod()
        {
            Player.Stop();
            Player.VlcMediaPlayer.VlcInstance.Dispose();
            Player = null;
 
        }

  

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            CloseImplementationMethod();
        }
    }
}
