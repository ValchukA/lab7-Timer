using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer
{
    public class Exam : ICutDownNotifier
    {
        public string Subject { get; private set; }

        public DateTime StartTime { get; private set; }

        public DateTime FinishTime { get; private set; }

        public Exam(string subject) => Subject = subject;

        private void TimerStartedHandler(object sender, TimerStartedEventArgs e)
        {
            StartTime = e.StartTime;

            Console.WriteLine($"Экзамен по предмету {Subject} начался {StartTime:F}. " +
                $"Название таймера: {((Timer)sender).Title}.");
        }

        private void TimerCountingDownHandler(object sender, TimerCountingDownEventArgs e)
            => Console.WriteLine($"Экзамен по предмету {Subject} закончится через {e.TimeLeft / 1000}. " +
                $"Название таймера: {((Timer)sender).Title}.");

        private void TimerFinishedHandler(object sender, TimerFinishedEventArgs e)
        {
            FinishTime = e.FinishTime;

            Console.WriteLine($"Экзамен по предмету {Subject} закончился {FinishTime:F}. " +
                $"Название таймера: {((Timer)sender).Title}.");
        }

        public void Initialize(Timer timer)
        {
            timer.Started += TimerStartedHandler;
            timer.CountingDown += TimerCountingDownHandler;
            timer.Finished += TimerFinishedHandler;
        }
    }
}
