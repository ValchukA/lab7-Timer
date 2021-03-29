using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Timer
{
    public class Timer
    {
        public string Title { get; set; }

        public event EventHandler<TimerStartedEventArgs> Started;

        public event EventHandler<TimerCountingDownEventArgs> CountingDown;

        public event EventHandler<TimerFinishedEventArgs> Finished;

        public Timer(string title) => Title = title;

        public void OnStarted(int time, int step)
        {
            if (time <= 0 && step <= 0)
            {
                throw new ArgumentException("Time and step can't be negative or equal to 0.");
            }

            Started?.Invoke(this, new TimerStartedEventArgs(DateTime.Now));

            while (time - step > 0)
            {
                time -= step;

                Thread.Sleep(step);

                CountingDown?.Invoke(this, new TimerCountingDownEventArgs(time));
            }

            Thread.Sleep(time);

            Finished?.Invoke(this, new TimerFinishedEventArgs(DateTime.Now));
        }
    }
}
