using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ClassLibrary
{
    public class Timerr
    {
        public event EventHandler Tick;

        private bool isRunning;

        public void Start()
        {
            isRunning = true;

            while (isRunning)
            {
                Thread.Sleep(1000); // Подождать 1 секунду
                OnTick(EventArgs.Empty);
            }
        }

        public void Stop()
        {
            isRunning = false;
        }

        protected virtual void OnTick(EventArgs e)
        {
            Tick?.Invoke(this, e);
        }
    }
}
