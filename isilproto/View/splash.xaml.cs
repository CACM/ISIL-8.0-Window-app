using Cacm.Isils.ViewModel;
using System.Windows;

namespace Cacm.Isils.View
{
    /// <summary>
    /// Interaction logic for Splash.xaml
    /// </summary>
    public partial class Splash : Window
    {
        public Splash()
        {
            InitializeComponent();
            this.DataContext = new SplashViewModel();

        }
    }
}
