using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer
{
    public class TimerStartedEventArgs : EventArgs
    {
        public DateTime StartTime { get; private set; }

        public TimerStartedEventArgs(DateTime startTime) => StartTime = startTime;
    }

    public class TimerFinishedEventArgs : EventArgs
    {
        public DateTime FinishTime { get; private set; }

        public TimerFinishedEventArgs(DateTime finishTime) => FinishTime = finishTime;
    }

    public class TimerCountingDownEventArgs : EventArgs
    {
        public int TimeLeft { get; private set; }

        public TimerCountingDownEventArgs(int timeLeft) => TimeLeft = timeLeft;
    }
}
