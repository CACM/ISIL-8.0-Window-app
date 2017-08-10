using Cacm.Isils.Model.Base;
using Cacm.Isils.Model.Data;
using System;

namespace Cacm.Isils.Model
{
    class StudentModel:BaseModel
    {

        #region Private Properties
        private int studentSeatno;
        private long studentRfidNo;
        private String studentName;
        private String studentPhoto;
        private long studentHandRasiedTime;
        private bool studentHandRasied;
        private PollAnsDataType studentPollAns;
        private AudioChannelType studentChannel;
        private bool studentMicActive;
        #endregion

        #region Get & Set Properties

        /// <summary>
        /// Gets or sets the student photo.
        /// </summary>
        /// <value>
        /// The student photo.
        /// </value>
        public String StudentPhoto
        {
            get => studentPhoto;

            set
            {

                if (studentPhoto != value)
                {
                    studentPhoto = value;
                    RaisePropertyChanged(nameof(StudentPhoto));
                }
            }
        }

        /// <summary>
        /// Gets or sets the student hand rasied time.
        /// </summary>
        /// <value>
        /// The student hand rasied time.
        /// </value>
        public long StudentHandRasiedTime
        {
            get
            {
                return studentHandRasiedTime;
            }

            set
            {
                if (studentHandRasiedTime != value)
                {
                    studentHandRasiedTime = value;
                    RaisePropertyChanged(nameof(StudentHandRasiedTime));
                }
            }
        }


        public bool StudentHandRasied
        {
            get
            {
                return StudentHandRasiedTime > 0 ? true : false;

            }

            set
            {
                if (studentHandRasied != value)
                {
                    studentHandRasied = value;
                    RaisePropertyChanged(nameof(StudentHandRasied));
                }
            }
        }




        /// <summary>
        /// Gets or sets the student seatno.
        /// </summary>
        /// <value>
        /// The student seatno.
        /// </value>
        public int StudentSeatno
        {

            get
            {
                return studentSeatno;
            }

            set
            {
                if (studentSeatno != value)
                {
                    studentSeatno = value;
                    RaisePropertyChanged(nameof(StudentSeatno));
                }
            }

        }


        /// <summary>
        /// Gets or sets the student poll ans.
        /// </summary>
        /// <value>
        /// The student poll ans.
        /// </value>
        public PollAnsDataType StudentPollAns
        {

            get
            {
                return studentPollAns;
            }

            set
            {
                if (studentPollAns != value)
                {
                    studentPollAns = value;
                    RaisePropertyChanged(nameof(StudentPollAns));
                }
            }
        }

        /// <summary>
        /// Gets or sets the student rfid no.
        /// </summary>
        /// <value>
        /// The student rfid no.
        /// </value>
        public long StudentRfidNo
        {
            get
            {
                return studentRfidNo;
            }

            set
            {
                if (studentRfidNo != value)
                {
                    studentRfidNo = value;
                    RaisePropertyChanged(nameof(StudentRfidNo));
                }
            }
        }


        /// <summary>
        /// Gets or sets the name of the student.
        /// </summary>
        /// <value>
        /// The name of the student.
        /// </value>
        public string StudentName
        {

            get
            {
                return studentName;
            }

            set
            {
                if (studentName != value)
                {
                    studentName = value;
                    RaisePropertyChanged(nameof(StudentName));
                }
            }
        }


        /// <summary>
        /// Gets or sets the student channel.
        /// </summary>
        /// <value>
        /// The student channel.
        /// </value>
        public AudioChannelType StudentChannel
        {
            get
            {
                return studentChannel;
            }

            set
            {
                if (studentChannel != value)
                {
                    studentChannel = value;
                    RaisePropertyChanged(nameof(StudentChannel));
                }
            }
        }
        /// <summary>
        /// Gets or sets the student mic active.
        /// </summary>
        /// <value>
        /// The student mic active.
        /// </value>
        public bool StudentMicActive
        {

            get
            {
                return studentMicActive;
            }

            set
            {
                if (studentMicActive != value)
                {
                    studentMicActive = value;
                    RaisePropertyChanged(nameof(StudentMicActive));
                }
            }
        }

        #endregion

       

    }
}
