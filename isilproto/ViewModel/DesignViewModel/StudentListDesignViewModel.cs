using Cacm.Isils.Model;
using Cacm.Isils.Model.Data;
using System.Collections.ObjectModel;

namespace Cacm.Isils.ViewModel.DesignViewModel
{
    class StudentListDesignViewModel:StudentViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static new StudentListDesignViewModel Instance => new StudentListDesignViewModel();

        #endregion

        #region  Constructor With Dummy Data
        /// <summary>
        /// dummy data for design 
        /// Initializes a new instance of the <see cref="StudentListDesignViewModel"/> class.
        /// </summary>
        public StudentListDesignViewModel()
        {
            //if (Students == null)
            //{
            //    Students = new List<StudentModel>();
            //}

            Students = new ObservableCollection<StudentModel>
            {
                new StudentModel
                {
                    StudentChannel= AudioChannelType.OpenChannel, StudentHandRasiedTime=1245,StudentMicActive=true,StudentName="Sumit Das",StudentPollAns=PollAnsDataType.A,StudentRfidNo=12312412,StudentSeatno=1,StudentHandRasied=true


                 },
                 new StudentModel
                {
                    StudentChannel= AudioChannelType.OpenChannel, StudentHandRasiedTime=1245,StudentMicActive=true,StudentName="Sumit Das",StudentPollAns=PollAnsDataType.A,StudentRfidNo=12312412,StudentSeatno=1,StudentHandRasied=true


                 },
            };
        }
        #endregion




  

        /// <summary>
        /// Updates the student by seatno.
        /// </summary>
        /// <param name="seatno">The seatno.</param>
        /// <param name="newStudent">The new student.</param>
        /// <returns></returns>


    }
}
