using System.Collections.Generic;

namespace isil
{
    class studentService
    {
        private static studentService instance;
        private List<student> studentList = null;
        private static readonly object syncRoot = new object();
        private studentService()
        {
            if (studentList == null)
            {
                studentList = new List<student>();
            }
        }
        public static studentService Instance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new studentService();
                    }
                }

            }
            return instance;
        }

        public void addStudent(student stu)
        {
            studentList.Add(stu);
        }

        public student getStudentBySeatno(int seatno)
        {
            return studentList.Find(stu => stu.StudentSeatno.Equals(seatno));
        }
    }
}
