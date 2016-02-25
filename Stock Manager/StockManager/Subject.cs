using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager
{
    public abstract class Subject
    {
        protected readonly List<IObserver> Observers;

        protected Subject()
        {
            Observers = new List<IObserver>();
        } 

        public void Attach(IObserver observer)
        {
            if (observer == null)
                throw new ArgumentNullException("observer");

            Observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            Observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in Observers)
            {
                observer.Update();
            }
        }
    }
}
