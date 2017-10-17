using CefSharp;
using System;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

namespace Cacm.Isils
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 
 
    public sealed partial class App : Application
    {

        public App()
        {
            //Perform dependency check to make sure all relevant resources are in our output directory.
            var settings = new CefSettings();
             
            settings.CefCommandLineArgs.Add("disable-gpu", "1");
            settings.SetOffScreenRenderingBestPerformanceArgs();
            Cef.Initialize(settings);
          
        }
 
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            Cef.Shutdown();
            System.Windows.Application.Current.Shutdown();
          
        }

    }
}
