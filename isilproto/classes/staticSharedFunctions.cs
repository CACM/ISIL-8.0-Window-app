
using isil.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isil
{
    static class staticSharedFunctions 
    {


        public  const String registryPath = "SOFTWARE\\CACM\\ISIL";
     public  static  T[] InitializeArray<T>(int length) where T : new()
        {
            T[] array = new T[length];
            for (int i = 0; i < length; ++i)
            {
                array[i] = new T();
            }

            return array;
        }

        public static int getNumberOfStudentsSeats(){

          return (int)Settings.Default["noOfDevices"] + 1;
        }


    }
}
