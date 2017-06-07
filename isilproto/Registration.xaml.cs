using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EasyEncryption;
using System.Security.Cryptography;
using Microsoft.Win32;
using isilproto;
namespace isil
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : MetroWindow
    {
        private string pass;
        public Registration()
        {
            InitializeComponent();
            string key=ThumbPrint.Value()+nameTxt.Text+pass;
            pass = "IPSITASAHADAS";
            keyTxt.Text = ThumbPrint.Value();

        //   MessageBox.Show();
        }


        private static string CreateSalt(int size)
        {
            //Generate a cryptographic random number.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);

            // Return a Base64 string representation of the random number.
            return Convert.ToBase64String(buff);
        }
//        System.Security.Cryptography.AesCryptoServiceProvider crypto = new System.Security.Cryptography.AesCryptoServiceProvider();

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string key = ThumbPrint.Value() + nameTxt.Text + ThumbPrint.Password;
            var md5 = EasyEncryption.MD5.ComputeMD5Hash(key);
            if (md5 == genarateTxt.Text)
            {

                //accessing the CurrentUser root element  
                //and adding "OurSettings" subkey to the "SOFTWARE" subkey  
                RegistryKey keyReg = Registry.CurrentUser.CreateSubKey(@staticSharedFunctions.registryPath);

                //storing the values  
                keyReg.SetValue("Reg", md5);
                keyReg.SetValue("Name", nameTxt.Text);
                keyReg.Close();

               
                MetroWindow mainWindow = new MainWindow1();
                mainWindow.Show();
                this.Close();
                //MessageBox.Show("success");

            }

          //  MessageBox.Show(encryptString + "");
           // en.Text = md5;

        }
    
    }


}
