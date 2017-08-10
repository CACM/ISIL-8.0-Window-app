using Cacm.Isils.Model;
using Cacm.Isils.Model.Base;
using System;
using System.Collections.ObjectModel;

namespace Cacm.Isils.ViewModel
{
    class StudentViewModel : BaseViewModel
    {

        #region Properties

        /// <summary>
        /// Gets or sets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static StudentViewModel Instance { get; set; } //single instance for all the view

        /// <summary>
        /// The student
        /// </summary>
        private ObservableCollection<StudentModel> student;  // student list

        /// <summary>
        /// the list of students for the view
        /// </summary>
        /// <value>
        /// The students.
        /// </value>
        public ObservableCollection<StudentModel> Students
        {
            get => student; set { student = value; OnPropertyChanged(nameof(student)); }
        }
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentViewModel"/> class.
        /// </summary>
        public StudentViewModel()
        {
            if (student == null)
            {
                student = new ObservableCollection<StudentModel>();
            }
        }
        #endregion

        #region CURD METHOD
        /// <summary>
        /// add new the students.
        /// </summary>
        /// <param name="s">The s.</param>
        public void LoadStudents(StudentModel s)
        {
            // ObservableCollection<StudentModel> students = new ObservableCollection<StudentModel>(); 
            App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
            {
                Students.Add(s);

            });
        }
        #endregion  
        
  
    }

}

