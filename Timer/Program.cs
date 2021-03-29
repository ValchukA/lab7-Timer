using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Timer
{
    class Program
    {
        static void Main()
        {
            Timer[] timers =
            {
                new Timer("таймер экзамена"),
                new Timer("таймер игры"),
                new Timer("Бессмысленный таймер")
            };

            Person[] participants = 
            { 
                new Person { FirstName = "Ivan", LastName = "Petrov" },
                new Person { FirstName = "Captain", LastName = "America" },
                new Person { FirstName = "Tim", LastName = "Corey" } 
            };

            ICutDownNotifier[] notifiers =
            {
                new Exam("математика"),
                new EliminationGame(participants),
                new TimerReporter()
            };

            Task[] tasks = new Task[notifiers.Length];            

            for (int i = 0; i < tasks.Length; i++)
            {
                notifiers[i].Initialize(timers[i]);

                ICutDownNotifier n = notifiers[i];
                Timer t = timers[i];

                tasks[i] = Task.Run(() => n.Run(t, 10000, 1000));
            }

            Task.WaitAll(tasks);
        }
    }
}
