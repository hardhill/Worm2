using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worm2
{
    public class Timeout : System.Timers.Timer
    {
        public Timeout(Action action, double delay)
        {
            this.AutoReset = true;
            this.Interval = delay;
            this.Elapsed += (sender, args) => action();
            this.Start();
        }
    }
}
