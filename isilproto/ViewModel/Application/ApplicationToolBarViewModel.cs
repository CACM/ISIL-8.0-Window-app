using Cacm.Isils.Model.Base;
using Cacm.Isils.ViewModel.Base;
using System.Windows.Input;
using System.Threading.Tasks;
using WpfAppBar;
using System.Windows;
using Cacm.Isils.Model;
using System;

namespace Cacm.Isils.ViewModel
{
    class ApplicationToolBarViewModel : BaseViewModel
    {
        #region Private
        /// <summary>
        /// The instance for singleton class
        /// </summary>
        private static ApplicationToolBarViewModel _instance = null;
        /// <summary>
        /// The toolbar model for application toolbar button
        /// </summary>
        private ApplicationToolBarModel _toolbar;
        private MultimediaPlayerViewModel _multimediaPlayer;
        #endregion

        #region Public
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static ApplicationToolBarViewModel Instance { get { return _instance ?? (_instance = new ApplicationToolBarViewModel()); } }


        /// <summary>
        /// Gets or sets the multimedia player.
        /// </summary>
        /// <value>
        /// The multimedia player.
        /// </value>
        public MultimediaPlayerViewModel MultimediaPlayer
        {
            get => _multimediaPlayer;
            set { _multimediaPlayer = value; OnPropertyChanged(nameof(MultimediaPlayer)); }
        }
        /// <summary>
        /// Gets or sets the tool bar.
        /// </summary>
        /// <value>
        /// The tool bar.
        /// </value>
        public ApplicationToolBarModel ToolBar
        {
            get => _toolbar;
            set { _toolbar = value; OnPropertyChanged(nameof(ToolBar)); }
        }
        #endregion

        #region Commands
        public ICommand PollCommand { get; set; }
        public ICommand OpenGroupCommand { get; set; }
        public ICommand CloseGroupCommand { get; set; }
        public ICommand OneToOneCommand { get; set; }
        public ICommand PushToTalkCommand { get; set; }
        public ICommand HandRaiseCommand { get; set; }
        public ICommand AuxCommand { get; set; }
        public ICommand HeadSetCommand { get; set; }
        public ICommand CourseWareCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand SettingCommand { get; set; }
        public ICommand SideDockCommand { get; set; }
        public ICommand NormalDockCommand { get; set; }
        public ICommand ResetCommand { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationToolBarViewModel"/> class.
        /// </summary>
        public ApplicationToolBarViewModel()
        {
            if (_instance == null)
            {
                _toolbar = new ApplicationToolBarModel();
                //  Console.Write("instance" + toolbar.PollStatus);
            }

            MultimediaPlayer = MultimediaPlayerViewModel.Instance;
          
            PollCommand = new RelayParameterizedCommand(async (parameter) => await PollImplementationAsync(parameter));
            OpenGroupCommand = new RelayParameterizedCommand(async (parameter) => await OpenGroupCommandImplementationAsync(parameter));
            CloseGroupCommand = new RelayParameterizedCommand(async (parameter) => await CloseGroupCommandImplementationAsync(parameter));
            OneToOneCommand = new RelayParameterizedCommand(async (parameter) => await OneToOneCommandImplementationAsync(parameter));
            PushToTalkCommand = new RelayParameterizedCommand(async (parameter) => await PushToTalkCommandImplementationAsync(parameter));
            HandRaiseCommand = new RelayParameterizedCommand(async (parameter) => await HandRaiseCommandImplementationAsync(parameter));
            AuxCommand = new RelayParameterizedCommand(async (parameter) => await AuxCommandImplementationAsync(parameter));
            HeadSetCommand = new RelayParameterizedCommand(async (parameter) => await HeadSetCommandImplementationAsync(parameter));
            CourseWareCommand = new RelayParameterizedCommand(async (parameter) => await CourseWareCommandImplementationAsync(parameter));
            CloseCommand = new RelayParameterizedCommand(async (parameter) => await CloseCommandImplementationAsync(parameter));
            SettingCommand = new RelayParameterizedCommand(async (parameter) => await SettingCommandImplementationAsync(parameter));
            SideDockCommand = new RelayParameterizedCommand(async (parameter) => await SideDockCommandImplementationAsync(parameter));
            NormalDockCommand = new RelayParameterizedCommand(async (parameter) => await NormalDockCommandImplementationAsync(parameter));
            ResetCommand = new RelayParameterizedCommand(async (parameter) => await ResetCommandImplementationAsync(parameter));
        }

        #endregion

        #region Implementation Methods
        private async Task PollImplementationAsync(object parameter)
        {
              await Task.Delay(1);
        }
        private async Task OpenGroupCommandImplementationAsync(object parameter)
        {
 
            await Task.Delay(1);
        }
        private async Task CloseGroupCommandImplementationAsync(object parameter)
        {
            //toggle the status
             await Task.Delay(1);
        }
        private async Task OneToOneCommandImplementationAsync(object parameter)
        {
            //toggle the status
             await Task.Delay(1);
        }
        private async Task PushToTalkCommandImplementationAsync(object parameter)
        {
            //toggle the status
                await Task.Delay(1);
        }
        private async Task HandRaiseCommandImplementationAsync(object parameter)
        {
            //toggle the status
             await Task.Delay(1);
        }
        private async Task AuxCommandImplementationAsync(object parameter)
        {
            //toggle the status
              await Task.Delay(1);
        }
        private async Task HeadSetCommandImplementationAsync(object parameter)
        {
            //toggle the status
            await Task.Delay(1);
        }
        private async Task CourseWareCommandImplementationAsync(object parameter)
        {
            //toggle the status
              await Task.Delay(1);
        }
        private async Task CloseCommandImplementationAsync(object parameter)
        {
             
            await Task.Delay(1);
        }
        private async Task SettingCommandImplementationAsync(object parameter)
        {
            
            
            await Task.Delay(1);
        }
        private async Task NormalDockCommandImplementationAsync(object parameter)
        {
             
            
            await Task.Delay(1);

        }
        private async Task SideDockCommandImplementationAsync(object parameter)
        {
            await Task.Delay(1);
        }
        private async Task ResetCommandImplementationAsync(object parameter)
        {
                    await Task.Delay(1);
        }
        #endregion

        #region Helper Methods
        /// <summary>
        /// Toggles the status for the toggle button 
        /// return inverse.
        /// </summary>
        /// <param name="status">if set to <c>true</c> [status].</param>
        /// <returns></returns>
        private bool ToggleStatus(bool status)
        {
            return !status;
        }
        #endregion
    }

}
