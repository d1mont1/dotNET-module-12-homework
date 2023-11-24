using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public delegate void RaceDelegate(string message);
    public abstract class Car
    {
        public string Name { get; }
        public int Speed { get; protected set; }
        public int Distance { get; private set; }

        public event RaceDelegate RaceEvent;

        public Car(string name, int speed)
        {
            Name = name;
            Speed = speed;
        }

        public virtual void Move()
        {
            Distance += Speed;
            OnRaceEvent($"{Name} на расстоянии {Distance} к финишу.");
        }

        protected virtual void OnRaceEvent(string message)
        {
            RaceEvent?.Invoke(message);
        }
    }
}
