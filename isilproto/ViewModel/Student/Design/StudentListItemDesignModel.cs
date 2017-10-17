using Cacm.Isils.Model.Data;

namespace Cacm.Isils.ViewModel
{
    class StudentListItemDesignModel:StudentListItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static StudentListItemDesignModel Instance => new StudentListItemDesignModel();

        #endregion

        #region Constructor
        public StudentListItemDesignModel()
        {
 
            StudentSeatno = 64;
         
        }
        #endregion
    }
}
