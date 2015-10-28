using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF.Log.Core
{
    public class InfoLog : ILog
    {
        public void Write(string content)
        {
            log4net.Config.BasicConfigurator.Configure();
            var logger = log4net.LogManager.GetLogger(typeof(ILog));
            logger.Info(content);
        }
    }
}
