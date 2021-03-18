using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1._3
{
    class EventArgString : EventArgs
    {
        public string text;
        
        public EventArgString(string str)
        {
            this.text = str;
        }
        /*
        public string Test
        {
            get 
            { 
                return this.text; 
            }
        }
        */
    }
}
