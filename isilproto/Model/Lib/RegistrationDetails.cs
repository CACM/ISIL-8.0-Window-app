using Microsoft.Win32;
using System;

namespace Cacm.Isils.Model.Lib
{
    /// <summary>
    /// Get Regististration Details from regedit data
    /// </summary>
    class RegistrationDetails
    {
        #region privates Methods

        /// <summary>
        /// Genarates the md5.
        /// </summary>
        /// <param name="fullName">The full name.</param>
        /// <returns></returns>
        private string GenarateMD5(String fullName)
        {
            return EasyEncryption.MD5.ComputeMD5Hash(
                ThumbPrint.Value() 
                + fullName 
                + CommonPropertiesAndMethodsHelper.registryPassword
                );
        }

    #endregion

        #region public properties

        /// <summary>
        /// The registry key details instance
        /// </summary>
        private static RegistryKey registryKeyDetails;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationDetails"/> class.
        /// </summary>
        public RegistrationDetails()
        {
            if(registryKeyDetails!=null)
            {
                return;
            }

            try
            {
                 registryKeyDetails = Registry.CurrentUser.OpenSubKey(CommonPropertiesAndMethodsHelper.registryPath);
            }
            catch (Exception e) {
                CommonPropertiesAndMethodsHelper.Logger.Fatal(e.Message.ToString());
            }
        }

        /// <summary>
        /// Gets the registry key.
        /// </summary>
        /// <value>
        /// The registry key.
        /// </value>
        public string RegistrationId
        {
            get => registryKeyDetails?.GetValue(CommonPropertiesAndMethodsHelper.registryKeyRegistrationId).ToString();
            set => registryKeyDetails.SetValue(CommonPropertiesAndMethodsHelper.registryKeyRegistrationId,value) ;
        }

        /// <summary>
        /// Gets the full name of the registration .
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        /// 
        public string RegistrationFullName
        {
            get => registryKeyDetails?.GetValue(CommonPropertiesAndMethodsHelper.registryKeyFullname).ToString();
            set => registryKeyDetails.SetValue(CommonPropertiesAndMethodsHelper.registryKeyFullname, value);
            
        }

        #endregion

        #region public methods

        /// <summary>
        /// Validates the registration .
        /// </summary>
        /// <param name="registrationId">The registration identifier.</param>
        /// <param name="fullname">The fullname.</param>
        /// <returns></returns>
        bool ValidRegistrationCheck(String registrationId,String fullname)
        {
            return (registrationId == GenarateMD5(fullname)) ?true: false;
        }

        #endregion 

    }
}
