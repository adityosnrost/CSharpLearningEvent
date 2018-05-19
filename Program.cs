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
            //Instantiate an object car with Car Type
            Car car = new Car();

            //Instantiate an object sport with Sport Type
            Sport sport = new Sport();

            //Instantiate an object city with City Type
            City city = new City();

            //Instantiate an object ls with LicenseService Type
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
            Buy?.Invoke(this, EventArgs.Empty);
        }
    }

    internal class Sport: Car
    {
        internal string name = "Sport";

        internal override void Name()
        {
            Console.WriteLine("Sport");
        }
    }

    internal class City: Car
    {
        internal string name = "City";

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

            string carType = sender.GetType().ToString();

            string licenseNumber = "";

            for(int i = 0; i < 5; i++)
            {
                licenseNumber += rnd.Next(0, 9).ToString();
            }

            Console.WriteLine("{1} Car has been bought, this is the license number: {0}", licenseNumber, carType);
        } 
    }
}
