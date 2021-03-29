using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer
{
    public class TimerReporter : ICutDownNotifier
    {
        public void Initialize(Timer timer)
        {
            timer.Started += delegate (object sender, TimerStartedEventArgs e)
            {
                Console.WriteLine($"Таймер \"{((Timer)sender).Title}\" стартовал в {e.StartTime:F}");
            };

            timer.CountingDown += delegate (object sender, TimerCountingDownEventArgs e)
            {
                Console.WriteLine($"Таймер \"{((Timer)sender).Title}\" закончится через {e.TimeLeft / 1000}");
            };

            timer.Finished += delegate (object sender, TimerFinishedEventArgs e)
            {
                Console.WriteLine($"Таймер \"{((Timer)sender).Title}\" закончился в {e.FinishTime:F}");
            };
        }
    }
}
