using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class RaceGame
    {
        public event RaceDelegate RaceInfo;

        public void StartRace(Car[] cars)
        {
            Random rand = new Random();

            while (true)
            {
                foreach (var car in cars)
                {
                    car.Move();
                    if (car.Distance >= 100)
                    {
                        OnRaceInfo($"{car.Name} пришел к финишу!");
                        return;
                    }
                }
            }
        }

        protected virtual void OnRaceInfo(string message)
        {
            RaceInfo?.Invoke(message);
        }
    }
}
