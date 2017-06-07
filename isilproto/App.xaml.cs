using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace isilproto
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 

    internal delegate void Invoker();
    public sealed partial class App : System.Windows.Application
{

    public App()
    {
        ApplicationInitialize = _applicationInitialize;
    }
    public static new App Current
    {
        get { return Application.Current as App; }
    }
    internal delegate void ApplicationInitializeDelegate(MetroWindow splash);
    internal ApplicationInitializeDelegate ApplicationInitialize;
    private void _applicationInitialize(MetroWindow splash)
    {
        // fake workload, but with progress updates.
        Thread.Sleep(500);
     //   splash.SetProgress(0.2);

        Thread.Sleep(500);
       // splashWindow.SetProgress(0.4);

        Thread.Sleep(500);
      //  splashWindow.SetProgress(0.6);

        Thread.Sleep(500);
      //  splashWindow.SetProgress(0.8);

        Thread.Sleep(500);
       // splashWindow.SetProgress(1);

        // Create the main window, but on the UI thread.
        Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Invoker)delegate
        {
            MainWindow = new MainWindow1();
            MainWindow.Show();
        });
    }
}
}
