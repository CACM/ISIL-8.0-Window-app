using NLog;
using System;

namespace Cacm.Isils.Model.Lib
{
    /// <summary>
    /// Common Shared Properties & Methods
    /// 
    /// </summary>
    static class CommonPropertiesAndMethods
    {
        /// <summary>
        /// The registry key registration identifier
        /// </summary>
        public const String registryKeyRegistrationId = "RegistryKey";

        /// <summary>
        /// The registry key fullname
        /// </summary>
        public const String registryKeyFullname = "RegistryFullname";

        /// <summary>
        /// The registry path 
        /// </summary>
        public const String registryPath = "SOFTWARE\\CACM\\ISIL";

        /// <summary>
        /// The registry password which concate with machine id
        /// </summary>
        public const String registryPassword = "IPSITASAHADAS";

        /// <summary>
        /// Initializes the array function.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        public static  T[] InitializeArray<T>(int length) where T : new()
        {
            T[] array = new T[length];
            for (int i = 0; i < length; ++i)
            {
                array[i] = new T();
            }

            return array;
        }

        /// <summary>
        /// The logger instance
        /// </summary>
        public static Logger Logger = LogManager.GetCurrentClassLogger();

    }
}
