using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isil
{
    class messageNotify
    {
        private string message ;
        private bool success;
        public void setMessage(string msg, bool suc){
            message= msg;
            success=suc;
        }
   
    }
}
