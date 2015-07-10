using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF.Log
{
   public class ErrorLog:ILog
    {
       public void Write(string content)
        {
            throw new NotImplementedException();
        }
    }
}
