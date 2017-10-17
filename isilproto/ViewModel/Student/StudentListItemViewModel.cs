using Cacm.Isils.Model.Base;
using Cacm.Isils.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cacm.Isils.ViewModel
{
    /// <summary>
    /// student   single item model
    /// </summary>
    /// <seealso cref="Cacm.Isils.Model.Base.BaseViewModel" />
    class StudentListItemViewModel :BaseViewModel
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
        private bool studentAllowPoll;
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
                    OnPropertyChanged(nameof(StudentPhoto));
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
                    OnPropertyChanged(nameof(StudentHandRasiedTime));
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [student hand rasied].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [student hand rasied]; otherwise, <c>false</c>.
        /// </value>
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
                    OnPropertyChanged(nameof(StudentHandRasied));
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
                    OnPropertyChanged(nameof(StudentSeatno));
                }
            }

        }

        /// <summary>
        /// Gets or sets a value indicating whether [student allow poll].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [student allow poll]; otherwise, <c>false</c>.
        /// </value>
        public bool StudentAllowPoll
        {

            get
            {
                return studentAllowPoll;
            }

            set
            {
                if (studentAllowPoll != value)
                {
                    studentAllowPoll = value;
                    OnPropertyChanged(nameof(StudentAllowPoll));
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
                    OnPropertyChanged(nameof(StudentPollAns));
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
                    OnPropertyChanged(nameof(StudentRfidNo));
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
                    OnPropertyChanged(nameof(StudentName));
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
                    OnPropertyChanged(nameof(StudentChannel));
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
                    OnPropertyChanged(nameof(StudentMicActive));
                }
            }
        }

        /// <summary>
        /// Gets the show bubble.
        /// </summary>
        /// <value>
        /// The show bubble.
        /// </value>
        public String ShowBubble
        {
            get
            {
                if (StudentChannel != AudioChannelType.Default)
                {
                    return null;
                }
                else if (studentAllowPoll)
                {
                    return studentPollAns.ToString();
                }
                else if (studentHandRasied)
                {
                    return studentHandRasiedTime.ToString();
                }
                else
                {
                    return null;
                }
                  
            }

           
        }

        /// <summary>
        /// Gets a value indicating whether this student is selected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this student is selected; otherwise, <c>false</c>.
        /// </value>
        public bool IsSelected
        {
            get
            {
                if (studentMicActive && studentChannel!=AudioChannelType.Default)
                {
                    return true;
                }
            
                else
                {
                    return false;
                }

            }


        }

        #endregion

        #region Constructor

        /// <summary>
        /// default value for the proerty 
        /// Initializes a new instance of the <see cref="StudentListItemViewModel"/> class.
        /// </summary>
        public StudentListItemViewModel()
        {            
            StudentPhoto = null;
            StudentHandRasiedTime = 0;
            StudentHandRasied = false;
            StudentPollAns = PollAnsDataType.NONE;
            StudentRfidNo = 0;
            StudentName = null;
            StudentChannel = AudioChannelType.Default;
            StudentMicActive = false;
        }

        #endregion
               
    }
}
