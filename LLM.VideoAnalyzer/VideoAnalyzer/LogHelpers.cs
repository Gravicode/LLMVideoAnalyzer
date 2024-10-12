using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoAnalyzer
{
    public class LogHelpers
    {
        public static event EventHandler<LogReceivedCls> LogReceived;

        public static void WriteLog(string Message, LogReceivedCls.MessageTypes messageTypes = LogReceivedCls.MessageTypes.INFO)
        {
            var msg = new LogReceivedCls() { Message = Message, MessageType = messageTypes };
            LogReceived?.Invoke(null, msg);
            Debug.WriteLine(msg.ToString());
        }
        public static void WriteLog(Exception ex)
        {
            WriteLog(ex.ToString(), LogReceivedCls.MessageTypes.ERROR);
        }
    }
}
