using isilproto;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace isil
{
    /// <summary>
    /// Interaction logic for splash.xaml
    /// </summary>
    public partial class splash : MetroWindow
    {
        public splash()
        {
            InitializeComponent();
            showDelegate = new ShowDelegate(this.showText);
            hideDelegate = new HideDelegate(this.hideText);
            this.ShowInTaskbar = false;
            this.Loaded += new RoutedEventHandler(splash_loaded);

        }

        private void load()
      {
          MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            foreach (MMDevice device in enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.All))
            {
            
                this.Dispatcher.Invoke(showDelegate, device.FriendlyName + ", " + device.State);
                Thread.Sleep(50);
                //do some loading work
                this.Dispatcher.Invoke(hideDelegate);
          

            }

                this.Dispatcher.Invoke(showDelegate,"Getting registration key....");
                try { 
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@staticSharedFunctions.registryPath);
               
                //if it does exist, retrieve the stored values  
                if (key != null)
                {
                   regKey=key.GetValue("Reg").ToString();
                   regName = key.GetValue("Name").ToString();
                    key.Close();
                }  
                    }
                catch { }

                string keyStroed = ThumbPrint.Value() + regName + ThumbPrint.Password;
               hashMd5Key = EasyEncryption.MD5.ComputeMD5Hash(keyStroed);
              //  Thread.Sleep(200);
                //do some loading work
                this.Dispatcher.Invoke(hideDelegate);
         

          //close the window
          Thread.Sleep(200);
          this.Dispatcher.Invoke(DispatcherPriority.Normal,
      (Action)delegate() {

          if (hashMd5Key == regKey) {
              this.Dispatcher.Invoke(showDelegate, "Loading ISIL");
              Thread.Sleep(50);
              Window MainWindow1 = new MainWindow1();
              MainWindow1.Show();
          
          }
          else
          {
              MetroWindow registrationWindow = new Registration();
              registrationWindow.Show();
          }

          Close();
      });
      }
        private delegate void ShowDelegate(string txt);
        private delegate void HideDelegate();
        ShowDelegate showDelegate;
        HideDelegate hideDelegate;


              private void showText(string txt)
        {
            splashMsgTxt.Content = txt;
          
        }
        private void hideText()
        {
   
        }


        private void splash_loaded(object sender, RoutedEventArgs e)
        {

            loadingThread = new Thread(load);
            loadingThread.Start();

          //  int waveInDevices = WaveIn.DeviceCount;
          //  for (int waveInDevice = 0; waveInDevice < waveInDevices; waveInDevice++)
          //  {
           //     WaveInCapabilities deviceInfo = WaveIn.GetCapabilities(waveInDevice);

           //     splashMsgTxt.Content = waveInDevice + ", " + deviceInfo.ProductName + ", " + deviceInfo.Channels + "channels";
          //  }
        }

        Thread loadingThread;
        private string hashMd5Key;
        private String regKey, regName = "";
    }
}
