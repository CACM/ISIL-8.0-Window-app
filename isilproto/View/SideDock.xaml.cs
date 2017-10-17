using Cacm.Isils.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfAppBar;

namespace Cacm.Isils.View
{
    /// <summary>
    /// Interaction logic for SideDock.xaml
    /// </summary>
    public partial class SideDock : Window
    {
        SideDockViewModel ViewModel;
        public SideDock()
        {
            ViewModel=  new SideDockViewModel();
            DataContext = ViewModel;
            InitializeComponent();
            PollWindowPositionChange();
        }

        #region Helper
        /// <summary>
        /// Polls the window position change after the docking is complete.
        /// popup window was opening without dock so the function was created
        /// </summary>
        /// <returns></returns>
        private async Task PollWindowPositionChange()
        {
            PopupPollTimer.Width = 309;
            await Task.Delay(3000); 
            PopupPollTimer.Width = 311;
 
        }

        #endregion

        #region click functions
        /// <summary>
        /// Handles the Click event of the NormalDock control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void NormalDock_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = null; // release the datacontext so the static resourse remain unchnaged. 
            var MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }
        private void StudentMenu_Click(object sender, RoutedEventArgs e)
        {
            PollWindowPositionChange();
        }
        #endregion


    }
}
