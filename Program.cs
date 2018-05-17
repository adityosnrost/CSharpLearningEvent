using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            Sport sport = new Sport();
            City city = new City();

            //car.Name();
            //sport.Name();
            //city.Name();

            Console.ReadLine();

            LicenseService ls = new LicenseService();

            city.Buy += ls.GenerateLicense;

            city.OnBuy();

            Console.ReadLine();
        }
    }

    internal class Car
    {
        internal virtual void Name()
        {
            Console.WriteLine("Car");
        }

        internal event EventHandler Buy;

        internal virtual void OnBuy()
        {
            EventHandler handler = Buy;
            if (null != handler)
            {
                handler(this, EventArgs.Empty);
            }
        }

    }

    internal class Sport: Car
    {
        internal override void Name()
        {
            Console.WriteLine("Sport");
        }

    }

    internal class City: Car
    {
        internal override void Name()
        {
            Console.WriteLine("City");
        }
    }

    internal class LicenseService
    {
        internal void GenerateLicense(object sender, EventArgs args)
        {
            Random rnd = new Random();
            Console.WriteLine(sender.GetType());

            string carType = "Sport";

            if(sender.GetType() == typeof(City))
            {
                carType = "City";
            }

            Console.WriteLine("{1} Car has been bought, this is the license number: {0}", rnd.Next(1, 13), carType);
        } 
    }
}
