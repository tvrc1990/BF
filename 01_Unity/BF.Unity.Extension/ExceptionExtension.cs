using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF.Unity.Extension
{
    public static class ExceptionExtension
    {
        public static string ToLog(this Exception exception)
        {
            int count = 1;
            StringBuilder formatBuilder = new StringBuilder();
            formatBuilder.AppendLine("/r/n");
            formatBuilder.AppendLine("Date：" + DateTime.Now);
            while (exception != null)
            {
                formatBuilder.AppendLine("Index: " + count);
                formatBuilder.AppendLine("Message: " + exception.Message);
                formatBuilder.AppendLine("Type: " + exception.GetType().FullName);
                formatBuilder.AppendLine("Method: " + (exception.TargetSite == null ? null : exception.TargetSite.Name));
                formatBuilder.AppendLine("Source: " + exception.Source);
                if (exception.StackTrace != null)
                {
                    formatBuilder.AppendLine("StackTrace: " + exception.StackTrace);
                }
                if (exception.InnerException != null)
                {
                    formatBuilder.AppendLine("InnerException: ");
                }
                exception = exception.InnerException;
                count++;
            }
            formatBuilder.AppendLine("/r/n");
            
            return formatBuilder.ToString();
        }
    }
}
