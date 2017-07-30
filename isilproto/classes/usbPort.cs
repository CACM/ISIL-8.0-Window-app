using isil.Properties;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NLog;
using System.ComponentModel;
namespace isil
{
    class usbPort
    {
        SerialPort serial;
        messageNotify msg;
        private string recieved_data;
        studentService studentService;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private System.Windows.Threading.DispatcherTimer userDataReceivedToObjectTimer;
        public usbPort()
        {
            serial = new SerialPort();
            msg = new messageNotify();

            userDataReceivedToObjectTimer = new System.Windows.Threading.DispatcherTimer();
            userDataReceivedToObjectTimer.Tick += new EventHandler(userReceivedStringToObject);
            userDataReceivedToObjectTimer.Interval = new TimeSpan(100000);

            //initializing student object 
            student[] studentObject = staticSharedFunctions.InitializeArray<student>(staticSharedFunctions.getNumberOfStudentsSeats());
           // studentService = studentService.Instance();
            for (int i = 0; i < staticSharedFunctions.getNumberOfStudentsSeats(); i++)
            {
           //     studentService.addStudent(studentObject[i]);
                studentObject[i].StudentSeatno = i;
            }
        }

        private void userReceivedStringToObject(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }





        public Boolean openPort(string port)
        {
            logger.Info("port open, port name  : " + port);

            serial.PortName = port;
            serial.Open();
            if (this.serial.IsOpen == true)
            {
                serial.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(serialDataRecieve);
                userDataReceivedToObjectTimer.Start();
                return true;
            }
            else
            {
                return false;
            }

        }




        private void backgroundWorker_usbDataProcess_stringToObject_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            BackgroundWorker helperBW = sender as BackgroundWorker;
            int arg = (int)e.Argument;
            BackgroundProcessLogicMethod_usbDataProcess_stringToObject(helperBW, arg);
            if (helperBW.CancellationPending)
            {
                e.Cancel = true;
            }
        }

        private void BackgroundProcessLogicMethod_usbDataProcess_stringToObject(BackgroundWorker bw, int a)
        {

            System.Diagnostics.Debug.WriteLine(recieved_data);
            int z = 0;

            try
            {
                if (recieved_data.Length >= z)
                {
                    if (recieved_data.IndexOf("UID", 0) != -1)
                    {
                        string rfid = "";
                        rfid = recieved_data.Substring(3, 12);
                        string rfidSeat = "";
                        rfidSeat = recieved_data.Substring(15, 3);
                        //  rfidarray[Int32.Parse(rfidSeat)] = rfid;
                       // studentService.getStudentBySeatno(int.Parse(rfidSeat)).StudentRfidNo = rfid;

                    }

                    while ((z = recieved_data.IndexOf("GD,", z)) != -1)
                    {
                        string tempsubstring = "";

                        if (z + 3 <= recieved_data.Length)
                        {
                            try
                            {
                                tempsubstring = recieved_data.Substring(z + 3, 27);
                            }
                            catch (ArgumentOutOfRangeException ex)
                            {
                                logger.Fatal(ex);

                            }

                        }
                        string[] pieces = tempsubstring.Split(new string[] {
							","
						}, StringSplitOptions.None);

                        if (pieces[0] != "000")
                        {
                            try
                            {
                               // studentService.getStudentBySeatno(int.Parse(pieces[0])).StudentMicActive = pieces[1] == "2" ? true : false; // mic active check per user
                               // studentService.getStudentBySeatno(int.Parse(pieces[0])).StudenthandRasiedTime = pieces[2]; //hand rasied timmer
                               // studentService.getStudentBySeatno(int.Parse(pieces[0])).StudentPollAns = pieces[3]; // store poll ans data.
                               // studentService.getStudentBySeatno(int.Parse(pieces[0])).StudentChannelClosed = pieces[5] == "1" ? true : false; // closed group channel
                               // studentService.getStudentBySeatno(int.Parse(pieces[0])).StudentChannelOpen = pieces[5] == "2" ? true : false; // open group channel
                               // studentService.getStudentBySeatno(int.Parse(pieces[0])).StudentChannelOpen = pieces[5] == "2" ? true : false; // open group channel

                            }
                            catch (Exception e)
                            {
                                logger.Fatal(e.Message);
                            }

                        }
                        z++;
                    }

                }
            }
            catch (Exception e1)
            {
                logger.Fatal(e1);

            }



        }


        private void serialDataRecieve(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                recieved_data += serial.ReadLine();

            }
            catch (Exception e1)
            {
                logger.Fatal(e1);
            }
        }
        public string[] getPortNames()
        {
            return SerialPort.GetPortNames();
        }

        private messageNotify searchConnectPort()
        {
            string[] ports = SerialPort.GetPortNames();
            bool portFound = false;
            Console.WriteLine("The following serial ports were found:");

            // Display each port name to the console. 
            foreach (string port in ports)
            {
                if (this.serial.IsOpen == true)
                {
                    this.serial.DiscardInBuffer();
                    this.serial.Close();
                    this.serial.Dispose();
                }

                Console.WriteLine("New ports" + port);
                //   MessageBox.Show("save" + port);
                try
                {
                    serial.PortName = port;
                    serial.BaudRate = 9600;
                    serial.Handshake = System.IO.Ports.Handshake.RequestToSendXOnXOff;
                    serial.Parity = Parity.None;
                    serial.DataBits = 8;
                    serial.StopBits = StopBits.Two;
                    serial.ReadTimeout = 100;
                    serial.WriteTimeout = 100;
                    serial.DtrEnable = true;
                    serial.Open();

                    string pat = @"ISILPORT";

                    // Instantiate the regular expression object.
                    Regex r = new Regex(pat, RegexOptions.IgnoreCase);
                    Match m = r.Match(serial.ReadLine());

                    if (m.Success)
                    {
                        Settings.Default["port1"] = port;
                        Settings.Default.Save();



                        portFound = true;



                    }
                    this.serial.DiscardInBuffer();
                    serial.Close();
                }
                catch (Exception ex)
                {
                    msg.setMessage(ex.ToString(), false);
                    return msg;

                }


            }
            if (portFound == false && Settings.Default["port1"].ToString() == "")
            {

                msg.setMessage("ISIL PORT NOT FOUND. PLEASE RESTART OR TRY MAUALLY", false);
                return msg;

            }
            openPort(Settings.Default["port1"].ToString());
            msg.setMessage(Settings.Default["port1"].ToString(), true);
            return msg;

        }
    }
}
