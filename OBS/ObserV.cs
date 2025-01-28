using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace Observer.OBS
{
    public class ObserV
    {
        public void Run()
        {
            Weather weather = new Weather();
            ConcreteObserver observer1 = new ("Jon", 32);
            ConcreteObserver observer2 = new("Bill", 41);
            ConcreteObserver observer3 = new("Anna", 51);
            weather.AddObserver(observer1);
            weather.AddObserver(observer2);
            weather.AddObserver(observer3);
            weather.NotifyObservers();
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("-----------------------------------------");
            weather.RemoveObserver(observer1);
            weather.NotifyObservers();
        }
        interface IObservableWeather
        {
            void AddObserver(Meteorologist o);
            void RemoveObserver(Meteorologist o);
            void NotifyObservers();
        }
        class Weather : IObservableWeather
        {
            private List<Meteorologist> observers;
            public Weather()
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
                {
                    
                    Console.WriteLine(observer);
                    observer.Update();
                    Console.WriteLine("-----------------------------------------");
                }
                    
            }
        }

        interface Meteorologist
        {
            void Update();
        }
        public class ConcreteObserver : Meteorologist
        {
            private string Name { get; set; } = null;
            private int Age { get; set; }
            public ConcreteObserver(string name, int age)
            {
                Name = name;
                Age = age;
            }
            public override string ToString() => $"{Name}\r\n {Age}\r\n";

            public void Update()
            {
                Console.WriteLine("It's going to rain from 2 to 6 today! You should take an umbrella!");
            }
        }
    }
}