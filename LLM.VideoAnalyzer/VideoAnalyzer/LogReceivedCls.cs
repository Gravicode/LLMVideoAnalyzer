using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoAnalyzer
{
    public class LogReceivedCls : EventArgs
    {
        public enum MessageTypes { INFO, WARNING, ERROR }
        public MessageTypes MessageType { get; set; } = MessageTypes.INFO;
        public DateTime Created { get; set; } = DateTime.Now;
        public string Message { get; set; }

        public override string ToString()
        {
            return $"[{MessageType}][{Created.ToString("dd-MMM-yyyy HH:mm")}] -> {Message}";
        }
    }
}
