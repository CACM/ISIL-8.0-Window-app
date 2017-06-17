using MahApps.Metro.Controls;
using System.Windows;
using WpfAppBar;
using System;

namespace isil
{
    /// <summary>
    /// Interaction logic for toolbar.xaml
    /// </summary>
    public partial class toolbar : Window
    {
        public toolbar()
        {
            
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Window_Loaded);

            this.Unloaded += new RoutedEventHandler(Window_Closed);

        }

        private void Window_Closed(object sender, RoutedEventArgs e)
        {
            AppBarFunctions.SetAppBar(this, ABEdge.None);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           AppBarFunctions.SetAppBar(this, ABEdge.Left);
        }
      
    }
}
