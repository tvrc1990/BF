using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF.Core.Log
{
    public class LogModel
    {
        public int Id { set; get; }
        public string UserId { set; get; }
        public int Type { set; get; }
        public string Content { set; get; }
        public DateTime CreateDate { set; get; }
    }
}
