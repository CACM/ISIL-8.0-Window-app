
namespace isil
{
    class student
    {

        private string studentName, studentRfidNo;


        private bool studentMicActive, studentChannelOpen, studentChannelClosed;
        private string studentPollAns;
        private int studentSeatno;
        private string studenthandRasiedTime;

        public string StudenthandRasiedTime
        {
            get { return studenthandRasiedTime; }
            set { studenthandRasiedTime = value; }
        }



        public int StudentSeatno
        {
            get { return studentSeatno; }
            set { studentSeatno = value; }
        }
        public string StudentPollAns
        {
            get { return studentPollAns; }
            set { studentPollAns = value; }
        }

        public string StudentRfidNo
        {
            get { return studentRfidNo; }
            set { studentRfidNo = value; }
        }

        public string StudentName
        {
            get { return studentName; }
            set { studentName = value; }
        }


        public bool StudentChannelClosed
        {
            get { return studentChannelClosed; }
            set { studentChannelClosed = value; }
        }

        public bool StudentChannelOpen
        {
            get { return studentChannelOpen; }
            set { studentChannelOpen = value; }
        }

        public bool StudentMicActive
        {
            get { return studentMicActive; }
            set { studentMicActive = value; }
        }








    }
}
