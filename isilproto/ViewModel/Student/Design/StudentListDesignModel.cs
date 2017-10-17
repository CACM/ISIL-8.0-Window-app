using Cacm.Isils.Model.Data;
using System.Collections.Generic;

namespace Cacm.Isils.ViewModel
{
    class StudentListDesignModel:StudentListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static StudentListDesignModel Instance => new StudentListDesignModel();

        #endregion

        #region Constructor
        public StudentListDesignModel()
        {


            Students = new List<StudentListItemViewModel>
              {
                  new StudentListItemViewModel
                  {
                      StudentPhoto="",
                      StudentChannel= AudioChannelType.Default,
                      StudentHandRasiedTime =1245,
                      StudentMicActive =false,
                      StudentName ="Sumit Das",
                      StudentAllowPoll=false,
                      StudentPollAns =PollAnsDataType.A,
                      StudentRfidNo =12312412,
                      StudentSeatno =12,
                      StudentHandRasied =true
                   },
                  new StudentListItemViewModel
                  {
                      StudentPhoto="",
                      StudentChannel= AudioChannelType.CloseChannel,
                      StudentHandRasiedTime =1245,
                      StudentMicActive =true,
                      StudentName ="Abhik",
                        StudentAllowPoll=false,
                      StudentPollAns =PollAnsDataType.B,
                      StudentRfidNo =12312412,
                      StudentSeatno =34,
                      StudentHandRasied =false
                   },
                   new StudentListItemViewModel
                  {
                      StudentPhoto="",
                      StudentChannel= AudioChannelType.PushToTalkChannel,
                      StudentHandRasiedTime =1245,
                      StudentMicActive =true,
                      StudentName ="Sumit Das",
                        StudentAllowPoll=false,
                      StudentPollAns =PollAnsDataType.A,
                      StudentRfidNo =12312412,
                      StudentSeatno =39,
                      StudentHandRasied =false
                   },
                  new StudentListItemViewModel
                  {
                      StudentPhoto="",
                      StudentChannel= AudioChannelType.OneToOneChannel,
                      StudentHandRasiedTime =1245,
                      StudentMicActive =true,
                      StudentName ="Abhik",
                      StudentPollAns =PollAnsDataType.B,
                      StudentRfidNo =12312412,
                      StudentSeatno =99,
                      StudentAllowPoll=false,
                      StudentHandRasied =false
                   },
                   new StudentListItemViewModel
                  {
                      StudentPhoto="",
                      StudentChannel= AudioChannelType.Default,
                      StudentHandRasiedTime =1245,
                      StudentMicActive =true,
                      StudentName ="Sumit Das",
                      StudentPollAns =PollAnsDataType.A,
                      StudentRfidNo =12312412,
                      StudentSeatno =124,
                        StudentAllowPoll=false,
                      StudentHandRasied =false
                   },
                  new StudentListItemViewModel
                  {
                      StudentPhoto="",
                      StudentChannel= AudioChannelType.Default,
                      StudentHandRasiedTime =1245,
                      StudentMicActive =false,
                      StudentName ="Abhik",
                      StudentPollAns =PollAnsDataType.B,
                      StudentRfidNo =12312412,
                        StudentAllowPoll=false,
                      StudentSeatno =64,
                      StudentHandRasied =false
                   },
                   new StudentListItemViewModel
                  {
                      StudentPhoto="",
                      StudentChannel= AudioChannelType.OpenChannel,
                      StudentHandRasiedTime =1245,
                      StudentMicActive =true,
                      StudentName ="Sumit Das",
                      StudentPollAns =PollAnsDataType.A,
                      StudentRfidNo =12312412,
                      StudentSeatno =1,
                      StudentHandRasied =true
                   },
                  new StudentListItemViewModel
                  {
                      StudentPhoto="",
                        StudentAllowPoll=true,
                      StudentChannel= AudioChannelType.OpenChannel,
                      StudentHandRasiedTime =1245,
                      StudentMicActive =true,
                      StudentName ="Abhik",
                      StudentPollAns =PollAnsDataType.B,
                      StudentRfidNo =12312412,
                      StudentSeatno =1,
                      StudentHandRasied =true
                   },
                   new StudentListItemViewModel
                  {
                      StudentPhoto="",
                      StudentChannel= AudioChannelType.OpenChannel,
                      StudentHandRasiedTime =1245,
                      StudentMicActive =true,
                      StudentName ="Sumit Das",
                      StudentPollAns =PollAnsDataType.A,
                      StudentRfidNo =12312412,
                      StudentSeatno =1,
                      StudentHandRasied =true
                   },
                  new StudentListItemViewModel
                  {
                      StudentPhoto="",
                      StudentChannel= AudioChannelType.OpenChannel,
                      StudentHandRasiedTime =1245,
                      StudentMicActive =true,
                      StudentName ="Abhik",
                      StudentPollAns =PollAnsDataType.B,
                      StudentRfidNo =12312412,
                      StudentSeatno =1,
                      StudentHandRasied =true
                   },
                   new StudentListItemViewModel
                  {
                      StudentPhoto="",
                      StudentChannel= AudioChannelType.OpenChannel,
                      StudentHandRasiedTime =1245,
                      StudentMicActive =true,
                      StudentName ="Sumit Das",
                      StudentPollAns =PollAnsDataType.A,
                      StudentRfidNo =12312412,
                      StudentSeatno =1,
                      StudentHandRasied =true
                   },
                   new StudentListItemViewModel
                  {
                      StudentPhoto="",
                      StudentChannel= AudioChannelType.OpenChannel,
                      StudentHandRasiedTime =1245,
                      StudentMicActive =true,
                      StudentName ="Sumit Das",
                      StudentPollAns =PollAnsDataType.A,
                      StudentRfidNo =12312412,
                      StudentSeatno =1,
                      StudentHandRasied =true
                   },
                  new StudentListItemViewModel
                  {
                      StudentPhoto="",
                      StudentChannel= AudioChannelType.OpenChannel,
                      StudentHandRasiedTime =1245,
                      StudentMicActive =true,
                      StudentName ="Abhik",
                      StudentPollAns =PollAnsDataType.B,
                      StudentRfidNo =12312412,
                      StudentSeatno =1,
                      StudentHandRasied =true
                   },
                   new StudentListItemViewModel
                  {
                      StudentPhoto="",
                      StudentChannel= AudioChannelType.OpenChannel,
                      StudentHandRasiedTime =1245,
                      StudentMicActive =true,
                      StudentName ="Sumit Das",
                      StudentPollAns =PollAnsDataType.A,
                      StudentRfidNo =12312412,
                      StudentSeatno =1,
                      StudentHandRasied =true
                   },
                  new StudentListItemViewModel
                  {
                      StudentPhoto="",
                      StudentChannel= AudioChannelType.OpenChannel,
                      StudentHandRasiedTime =1245,
                      StudentMicActive =true,
                      StudentName ="Abhik",
                      StudentPollAns =PollAnsDataType.B,
                      StudentRfidNo =12312412,
                      StudentSeatno =1,
                      StudentHandRasied =true
                   },
                   new StudentListItemViewModel
                  {
                      StudentPhoto="",
                      StudentChannel= AudioChannelType.OpenChannel,
                      StudentHandRasiedTime =1245,
                      StudentMicActive =true,
                      StudentName ="Sumit Das",
                      StudentPollAns =PollAnsDataType.A,
                      StudentRfidNo =12312412,
                      StudentSeatno =1,
                      StudentHandRasied =true
                   },
                  new StudentListItemViewModel
                  {
                      StudentPhoto="",
                      StudentChannel= AudioChannelType.OpenChannel,
                      StudentHandRasiedTime =1245,
                      StudentMicActive =true,
                      StudentName ="Abhik",
                      StudentPollAns =PollAnsDataType.B,
                      StudentRfidNo =12312412,
                      StudentSeatno =1,
                      StudentHandRasied =true
                   },
                   new StudentListItemViewModel
                  {
                      StudentPhoto="",
                      StudentChannel= AudioChannelType.OpenChannel,
                      StudentHandRasiedTime =1245,
                      StudentMicActive =true,
                      StudentName ="Sumit Das",
                      StudentPollAns =PollAnsDataType.A,
                      StudentRfidNo =12312412,
                      StudentSeatno =1,
                      StudentHandRasied =true
                   },
                  new StudentListItemViewModel
                  {
                      StudentPhoto="",
                      StudentChannel= AudioChannelType.OpenChannel,
                      StudentHandRasiedTime =1245,
                      StudentMicActive =true,
                      StudentName ="Abhik",
                      StudentPollAns =PollAnsDataType.B,
                      StudentRfidNo =12312412,
                      StudentSeatno =1,
                      StudentHandRasied =true
                   }


              };
        }
        #endregion
    }
}
