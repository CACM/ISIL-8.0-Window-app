
using MahApps.Metro.Controls;
using System;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Animation;

namespace isil
{


    public partial class MainWindow1 : MetroWindow
    {
        #region Variable_disble_move_restore
        const int WM_SYSCOMMAND = 0x0112;
        const int SC_MOVE = 0xF010;
        const int SC_RESTORE = 0xF120;
        private const int WM_NCLBUTTONDBLCLK = 0x00A3; //double click on a title bar a.k.a. non-client area of the form

        #endregion
        #region function_disable_move_restore
        private void Window1_SourceInitialized(object sender, EventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            HwndSource source = HwndSource.FromHwnd(helper.Handle);
            source.AddHook(WndProc);
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {

            switch (msg)
            {
                case WM_SYSCOMMAND:
                    int command = wParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                    {
                        handled = true;
                    }
                    else if (command == SC_RESTORE && WindowState == WindowState.Maximized)
                    {
                        // prevent user from restoring the window while it is maximized
                        // (but allow restoring when it is minimized)
                        handled = true;
                    }
                    break;

                default:
                    break;
            }

            return IntPtr.Zero;
        }
        #endregion
        string[] audioFileFormat = {
			".wav", ".mp3", ".wma", ".zab"
		};
        Storyboard browserLoadingSB;
        public MainWindow1()
        {
            InitializeComponent();
            this.SourceInitialized += Window1_SourceInitialized; // disable window move and restore
            Player.VlcMediaPlayer.EndReached += VlcMediaPlayer_EndReached; // vlc end reach
            Player.VlcMediaPlayer.Stoped+=VlcMediaPlayer_Stoped ;

            Player.StateChanged += VlcMediaPlayer_Playing;
             browserLoadingSB = this.FindResource("browserLoading") as Storyboard; // intialize animation for browser loading

      
        }
        #region Vlc_Functions
        private void VlcMediaPlayer_Stoped(object sender, Meta.Vlc.ObjectEventArgs<Meta.Vlc.Interop.Media.MediaState> e)
        {
            try
            {
                containerVlc.Visibility = System.Windows.Visibility.Hidden;
                BtnPlayerClose.Visibility = System.Windows.Visibility.Hidden;
                webBrowser.Visibility = Visibility.Visible;
            }
            catch { }
        }

        void VlcMediaPlayer_Playing(object sender, Meta.Vlc.ObjectEventArgs<Meta.Vlc.Interop.Media.MediaState> e)
        {
            try
            {
                containerVlc.Visibility = Visibility.Visible;
                BtnPlayerClose.Visibility = Visibility.Visible;
                webBrowser.Visibility = Visibility.Hidden;
            }
            catch { }
          
            
            
        }
     
     



        void VlcMediaPlayer_EndReached(object sender, Meta.Vlc.ObjectEventArgs<Meta.Vlc.Interop.Media.MediaState> e)
        {

            btnPlayerPlay.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                                   new Action(delegate()
                                   {
                                       btnPlayerPlay.IsChecked = false;
                                       Player.Stop();
                                   }));

        }

        private void btnPlayerOpen_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            var openfiles = new Microsoft.Win32.OpenFileDialog();

            openfiles.Filter = "Media Files|VIDEO_TS.IFO;*.TRAILERS;*.URL;*.ASX;*.B4S; *.M3U;*.PLS;*.WPL;*.ZPL;*.ASF;*.AVI;*.AVS;*.DAT;*.FLC; *.FLI;*.MKV;*.MOV;*.MP4;*.MPG;*.MPEG;*.M2V;*.OGM;*.PART; *.VOB;*.RM;*.RAM;*.RMM;*.RMVB;*.SWF;*.TS;*.TP;*.WMV; *.AAC;*.AC3;*.APE;*.CDA;*.DTS;*.FLAC;*.MID;*.MKA;*.MP2; *.MP3;*.MPA;*.MPC;*.OGG;*.RA;*.WAV;*.WMA;*.7Z;*.ARJ;*.BZ2; *.CAB;*.RAR;*.ZIP| Video Files|*.ASX;*.B4S;*.M3U;*.PLS;*.WPL;*.ZPL;*.ASF; *.AVI;*.AVS;*.DAT;*.FLC;*.FLI;*.MKV;*.MOV;*.MP4;*.MPG; *.MPEG;*.M2V;*.OGM;*.PART;*.VOB;*.RM;*.RAM;*.RMM; *.RMVB;*.SWF;*.TS;*.TP;*.WMV;*.7Z;*.ARJ;*.BZ2;*.CAB; *.RAR;*.ZIP| Audio Files|*.ASX;*.B4S;*.M3U;*.PLS;*.WPL;*.ZPL;*.AAC; *.AC3;*.APE;*.CDA;*.DTS;*.FLAC;*.MID;*.MKA;*.MP2;*.MP3; *.MPA;*.MPC;*.OGG;*.RA;*.WAV;*.WMA;*.7Z;*.ARJ;*.BZ2; *.CAB;*.RAR;*.ZIP| Play Lists|*.ASX;*.B4S;*.M3U;*.PLS;*.WPL;*.ZPL;*.7Z; *.ARJ;*.BZ2;*.CAB;*.RAR;*.ZIP| CD Audio|*.CDA | Presentation|*.pptx;*.ppt;*.docx;*.doc;*.xls;*.xlsx | Images|*.BMP;*.GIF;*.JPEG;*.JPG;*.JPS;*.PNG| All Files|*.*'";

            if (openfiles.ShowDialog() == true)
            {
                var mrl = openfiles.FileName;

                if (mrl.Length < 4) return;
                var playerext = mrl.Substring(mrl.Length - 4);
                if (Array.IndexOf(audioFileFormat, playerext) >= 0)
                {

                    containerVlc.Visibility = System.Windows.Visibility.Hidden;
                    BtnPlayerClose.Visibility = System.Windows.Visibility.Hidden;

                }
                else
                {
                    containerVlc.Visibility = System.Windows.Visibility.Visible;
                    BtnPlayerClose.Visibility = System.Windows.Visibility.Visible;


                }

                String pathString = txtBrowser.Text;

                Uri uri = null;
                if (!Uri.TryCreate(pathString, UriKind.Absolute, out uri))
                    Player.Stop();
                Player.LoadMedia(openfiles.FileName);
                Player.Play();
                btnPlayerPlay.IsChecked = true;
            }

            containerVlc.Visibility = System.Windows.Visibility.Hidden;
            BtnPlayerClose.Visibility = System.Windows.Visibility.Hidden;
            return;

        }




        private void btnPlayerPlay_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (Player.VlcMediaPlayer.State == Meta.Vlc.Interop.Media.MediaState.Ended)
            {
                Player.Stop();
                Player.Play();
            }

            Player.PauseOrResume();
        }

        private void btnPlayerPlay_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            Player.PauseOrResume();
        }


        private void child02_IsOpenChanged(object sender, RoutedEventArgs e)
        {
            if (modalWindowVlc.IsOpen == false)
            {


                containerFullScreenPlayer.Children.Remove(Player);
                containerVlcPlayer.Children.Add(Player);
            }
            else
            {

                containerVlcPlayer.Children.Remove(Player);
                containerFullScreenPlayer.Children.Add(Player);
            }
        }


        private void btnPlayerPlay_Copy_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (modalWindowVlc.IsOpen == false)
            {
                modalWindowVlc.IsOpen = true;
            }
            else
            {
                modalWindowVlc.IsOpen = false;
            }

        }

        private void BtnPlayerClose_Click(object sender, RoutedEventArgs e)
        {
            Player.Stop();
        }



        #endregion



       /* private void Browser_LoadingStateChanged(object sender, CefSharp.LoadingStateChangedEventArgs e)
        {
            this.Dispatcher.Invoke(() => { //Invoke UI Thread
               
            });
           
            if (e.IsLoading)
            {
                this.Dispatcher.Invoke(() => { //Invoke UI Thread
                    browserLoadingSB.Begin();
                });
            }
            else
            {
                this.Dispatcher.Invoke(() => { //Invoke UI Thread
                    browserLoadingSB.Stop();
                });
            }

           
            
            Console.WriteLine("Browser_LoadingStateChanged");
        }*/

        private void txtBrowser_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;
            // your event handler here
            e.Handled = true;
          
            string input = txtBrowser.Text;
            if (input.StartsWith("http://") || input.StartsWith("https://"))
            {
                
            }
            else if (input.Contains("."))
            {
               
            }
            else
            {
                


            }
        }

        private void btn_docking_Click(object sender, RoutedEventArgs e)
        {

            toolbar docking = new toolbar();
            docking.Show();
            TopToolbar dockingTop = new TopToolbar();
            dockingTop.Show();
            this.Close();
        }
    }

}




