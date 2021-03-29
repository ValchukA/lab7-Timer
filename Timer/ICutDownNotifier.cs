using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer
{
    public interface ICutDownNotifier
    {
        public void Initialize(Timer timer);

        public void Run(Timer timer, int time, int step) => timer.OnStarted(time, step);
    }
}
