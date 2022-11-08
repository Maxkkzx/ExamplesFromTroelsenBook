using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessMultipleExceptions
{
    [global::System.Serializable]
    public class CarIsDeadException : ApplicationException
    {
        public CarIsDeadException() { }
        public CarIsDeadException(string message) : base(message) { }
        public CarIsDeadException(string message, Exception inner) : base(message, inner) { }

        protected CarIsDeadException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }

        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }
        public CarIsDeadException(string message, string cause, DateTime time)
        {
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }
    }

}
