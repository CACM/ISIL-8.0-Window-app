using Cacm.Isils.Model;
using Cacm.Isils.Model.Data;
using Cacm.Isils.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace isil
{
    class studentService
    {
        public studentService()
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
            //studentViewModelObject.LoadStudents();
        }

    }
}
