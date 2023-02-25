using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousMethod
{
    public class CarEventsArgs : EventArgs
    {
        public readonly string msg;
        
        public CarEventsArgs(string msg)
        {
            this.msg = msg;
        }
    }
}
