using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer
{
    public class EliminationGame : ICutDownNotifier
    {
        public List<Person> Participants { get; private set; }

        public EliminationGame(IEnumerable<Person> participants)
            => Participants = participants.ToList();

        public void Initialize(Timer timer)
        {
            timer.Started += (sender, e) =>
            {
                if (Participants.Count == 0)
                {
                    throw new Exception("Noone is left.");
                }

                Console.WriteLine("Игра началась! Количество участников: " +
                    $"{Participants.Count}. Название таймера: {((Timer)sender).Title}.");
            };

            timer.CountingDown += (sender, e) =>
            {
                if (Participants.Count == 0)
                {
                    throw new Exception("Noone is left.");
                }

                if (Participants.Count > 1)
                {
                    Participants.RemoveAt(Participants.Count - 1);
                }

                Console.WriteLine($"Осталось участников: {Participants.Count}. " +
                    $"Название таймера: {((Timer)sender).Title}.");
            };

            timer.Finished += (sender, e) =>
            {
                if (Participants.Count == 0)
                {
                    throw new Exception("Noone is left.");
                }

                Console.WriteLine($"Победителем является {Participants[0]}. " +
                    $"Название таймера: {((Timer)sender).Title}.");
            };
        }
    }
}
