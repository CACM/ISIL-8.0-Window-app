using Cacm.Isils.Model;
using Cacm.Isils.Model.Base;
using Cacm.Isils.Model.Data;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace Cacm.Isils.ViewModel
{
    /// <summary>
    /// Custom Window View Model For Splash Window
    /// </summary>
    /// <seealso cref="Cacm.Isils.Model.Base.BaseViewModel" />
    class SplashViewModel :BaseViewModel 
    {

        #region private members
        /// <summary>
        /// The loading text MSG
        /// </summary>
        private string _loadingTextMsg;
        #endregion

        #region Public Members
        /// <summary>
        /// Gets or sets the loading text MSG.
        /// </summary>
        /// <value>
        /// The loading text MSG.
        /// </value>
        public string LoadingTextMsg
        {
            get { return _loadingTextMsg; }
            set
            {
                _loadingTextMsg = value;
                OnPropertyChanged(nameof(LoadingTextMsg));
            }
        }
        #endregion

        #region Constractor
        public SplashViewModel()
        {
            Task.Run(async () =>
            {

                for (int i = 0; i < 10; i++)
                {
                    await Task.Delay(600);

                    Console.WriteLine("Cannot open Redirect.txt for writing");
                    StudentModel s = new StudentModel
                    {
                        StudentChannel = AudioChannelType.OpenChannel,
                        StudentHandRasiedTime = 1245,
                        StudentMicActive = true,
                        StudentName = "Sumit Das",
                        StudentPollAns = PollAnsDataType.A,
                        StudentRfidNo = 12312412,
                        StudentSeatno = i,
                        StudentHandRasied = true
                    };

                    if (StudentViewModel.Instance != null)
                    {
                        //Why you need the "var datacontext" in your example here ?
                        StudentViewModel.Instance.LoadStudents(s);
                    }


                }
            });
        }
        #endregion
       

    }
}
