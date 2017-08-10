using Cacm.Isils.Model.Base;
using Cacm.Isils.View;
using NAudio.CoreAudioApi;
using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Cacm.Isils.ViewModel
{
    /// <summary>
    /// Custom Window View Model For Splash Window
    /// </summary>
    /// <seealso cref="Cacm.Isils.Model.Base.BaseViewModel" />
    class SplashViewModel :BaseViewModel 
    {
        #region  Properties

        private String _splashLoadingText;
        public String SplashDetailsText
        {
            get => "Centre for Advanced Communication (CACM) is the manufacturer and patent holder of Interactive Software Integrated Learning System (ISILS) which is the key to run our se lf-developed Interactive Language Communication Labs earning the trademark with goodwill as Skill Junction Labs.";
            set=> SplashDetailsText = value;
        }

        public String SplashProductName
        {
            get => System.Reflection.Assembly.GetExecutingAssembly().GetName().Name
            + " " +
            System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            set => SplashProductName = value;
        }

   
        public String SplashLoadingText
        {
            get => _splashLoadingText;

            set
            {
                if (_splashLoadingText != value)
                {
                    _splashLoadingText = value;
                    OnPropertyChanged(nameof(SplashLoadingText));
                }
            }
        }

        BackgroundWorker worker;
        #endregion

        #region constructor 
        /// <summary>
        /// Initializes a new instance of the <see cref="SplashViewModel" /> class.
        /// </summary>
        public SplashViewModel()
        {
            SplashLoadingText = "asd";

            worker = new BackgroundWorker();
    
            worker.DoWork += worker_DoWork;
          
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.WorkerSupportsCancellation = true;
            worker.RunWorkerAsync();
        
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine("start");
            ///Get the Audio Driver List
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            foreach (MMDevice device in enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.All))
            {
                SplashLoadingText = device.FriendlyName + " - " + device.State;
                Thread.Sleep(500);
            }
           

        }
        #endregion

    }
}
