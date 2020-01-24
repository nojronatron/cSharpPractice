using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarEvents
{
    //  Mirror Microsoft's recommended event pattern
    //  For simple events pass an instance of EventArgs directly
    //  When passing custom data build a suitable class deriving from EventArgs
    public class CarEventArgs : EventArgs
    {
        public readonly string msg;
        public CarEventArgs(string message)
        {
            msg = message;
        }
    }
}
