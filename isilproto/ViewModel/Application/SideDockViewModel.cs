using Cacm.Isils.Model.Base;
using Cacm.Isils.ViewModel.Base;
using System.Windows.Input;
using System.Threading.Tasks;
using WpfAppBar;
using System.Windows;
using System.Windows.Controls.Primitives;
using Cacm.Isils.Model;

namespace Cacm.Isils.ViewModel
{
    class SideDockViewModel : BaseViewModel
    {
        #region Private Properties

        /// <summary>
        /// The window is docked
        /// </summary>
        private bool isDocked;
        private ApplicationToolBarViewModel _applicationToolBar;

        #endregion

        #region Public Properties
        public static SideDockViewModel Instance => new SideDockViewModel();

        /// <summary>
        /// Gets or sets a value indicating whether this Window is docked.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is docked; otherwise, <c>false</c>.
        /// </value>
        public bool IsDocked
        {
            get => isDocked;

            set
            {

                if (isDocked != value)
                {
                    isDocked = value;
                    OnPropertyChanged(nameof(IsDocked));
                }
            }
        }
        /// <summary>
        /// The application tool bar reference instance 
        /// </summary>
        public ApplicationToolBarViewModel ApplicationToolBar
        {
            get => _applicationToolBar;

            set
            {

                if (_applicationToolBar != value)
                {
                    _applicationToolBar = value;
                    OnPropertyChanged(nameof(ApplicationToolBar));
                }
            }
        }
      
 
        #endregion

        #region Commands

        /// <summary>
        /// Gets or sets the load student command.
        /// </summary>
        /// <value>
        /// The load student command.
        /// </value>
        public ICommand LoadStudentCommand { get; set; }
      

        /// <summary>
        /// Command for resize to normal window command.
        /// </summary>
        /// <value>
        /// The normal window command.
        /// </value>
        public ICommand NormalWindowCommand { get; set; }
        /// <summary>
        /// Gets or sets the window unload command.
        /// </summary>
        /// <value>
        /// The window unload command.
        /// </value>
        public ICommand WindowUnloadCommand { get; set; }
        /// <summary>
        /// Gets  the windowload command.
        /// </summary>
        /// <value>
        /// The windowload command.
        /// </value>
        public ICommand WindowloadCommand { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public SideDockViewModel()
        {
            ApplicationToolBar  = ApplicationToolBarViewModel.Instance; 
            NormalWindowCommand = new RelayParameterizedCommand(async (parameter) => await NormalWindowCommandImplementation(parameter));
            LoadStudentCommand  = new RelayParameterizedCommand(async (parameter) => await WindowResizeOnStudentLoadUnload(parameter));
            WindowUnloadCommand = new RelayParameterizedCommand(async (parameter) => await WindowUnloadCommandImplementation(parameter));
            WindowloadCommand   = new RelayParameterizedCommand(async (parameter) => await WindowloadCommandImplementation(parameter));
            

        }
        #endregion

        #region Implementation
        /// <summary>
        /// Windowloads the command implementation.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        private async Task WindowloadCommandImplementation(object parameter)
                {

           (parameter as Window).Visibility = Visibility.Hidden;        
            AppBarFunctions.SetAppBar((parameter as Window), ABEdge.Right);
            IsDocked = true;
            await Task.Delay(500);
            AppBarFunctions.SetAppBar((parameter as Window), ABEdge.None);
            IsDocked = false;
            await Task.Delay(500);
            AppBarFunctions.SetAppBar((parameter as Window), ABEdge.Right);
            await Task.Delay(100);
            (parameter as Window).Visibility = Visibility.Visible;
        }
        /// <summary>
        /// Resize the window 
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        private async Task WindowResizeOnStudentLoadUnload(object parameter)
        {
            (parameter as Window).Visibility = Visibility.Hidden;
            AppBarFunctions.SetAppBar((parameter as Window), ABEdge.None);
            IsDocked = false;
            await Task.Delay(500);
            AppBarFunctions.SetAppBar((parameter as Window), ABEdge.Right);
            IsDocked = true;
            await Task.Delay(100);
            (parameter as Window).Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Normals the window command implementation.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        private async Task NormalWindowCommandImplementation(object parameter)
        {
            await Task.Delay(1);
            AppBarFunctions.SetAppBar((parameter as Window), ABEdge.None);
            IsDocked = false;
            //TODO: Window unload and load the normal window
        }
        /// <summary>
        /// Windows the unload command implementation.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        private async Task WindowUnloadCommandImplementation(object parameter)
        {
            AppBarFunctions.SetAppBar((parameter as Window), ABEdge.None);
            IsDocked = false;
            await Task.Delay(100);
          //  MessageBox.Show((parameter as Window), "unload");
        }
        #endregion
       

    }

}
