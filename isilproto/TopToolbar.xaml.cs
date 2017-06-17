using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfAppBar;

namespace isil
{
    /// <summary>
    /// Interaction logic for TopToolbar.xaml
    /// </summary>
    public partial class TopToolbar : Window
    {
        public TopToolbar()
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
            AppBarFunctions.SetAppBar(this, ABEdge.Top);
        }
    }
}
