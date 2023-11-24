using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Counter
    {
        public event EventHandler ThresholdReached;

        private int threshold;
        private int count;

        public Counter(int thresholdValue)
        {
            threshold = thresholdValue;
            count = 0;
        }

        public void Increment()
        {
            count++;
            Console.WriteLine($"Текущее значение счётчика: {count}");

            if (count == threshold)
            {
                OnThresholdReached(EventArgs.Empty);
            }
        }

        protected virtual void OnThresholdReached(EventArgs e)
        {
            ThresholdReached?.Invoke(this, e);
        }
    }
}
