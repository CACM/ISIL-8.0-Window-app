using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace isil
{
    class StudentViewModel : BaseViewModel
    {
        //  public static StudentModel Instance => new StudentModel();
        public static StudentViewModel Instance { get; set; } //NEW
        public ObservableCollection<StudentModel> student; 
        public StudentViewModel()
        {
            if (student == null)
            {
                student = new ObservableCollection<StudentModel>();
            }
        }

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



        public void LoadStudents(StudentModel s)
        {
            // ObservableCollection<StudentModel> students = new ObservableCollection<StudentModel>();

          

            App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
            {
                Students.Add(s);

            });
        }


        public void UpdateContent(StudentModel s)
        {
            ObservableCollection<StudentModel> students = new ObservableCollection<StudentModel>();
            students.Add(s);
            Students = students;
        }
    }

}

