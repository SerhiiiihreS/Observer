using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Observer.OBS
{
    public class ObserV
    {
        public class Run
        {
            ConcreteObserver observer1 = new ConcreteObserver("Jon", "rain");
            ConcreteObserver observer2 = new ConcreteObserver("Bill", "snow");
            
        }
        interface IObservableWeather
        {
            void AddObserver(Meteorologist o);
            void RemoveObserver(Meteorologist o);
            void NotifyObservers();
        }
        class ConcreteObservable : IObservableWeather
        {
            private List<Meteorologist> observers;
            public ConcreteObservable()
            {
                observers = new List<Meteorologist>();
            }
            public void AddObserver(Meteorologist o)
            {
                observers.Add(o);
            }

            public void RemoveObserver(Meteorologist o)
            {
                observers.Remove(o);
            }

            public void NotifyObservers()
            {
                foreach (Meteorologist observer in observers)
                    observer.Update();
            }
        }

        interface Meteorologist
        {
            void Update();
        }
        public class ConcreteObserver : Meteorologist
        {
            private string Name { get; set; } = null;
            private string Phenomenon { get; set; } = null;
            public ConcreteObserver(string name, string phenomenon)
            {
                Name = name;
                Phenomenon = phenomenon;
            }
            public override string ToString()
            {
                return $"Name" + " " + "Phenomenon";
            }

            public void Update()
            {
            }
        }
    }

}