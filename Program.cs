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
            //Instantiate an object ls with LicenseService Type
            LicenseService ls = new LicenseService();

            //Instantiate an object sport with Sport Type
            Sport sport = new Sport(ls);

            //Instantiate an object city with City Type
            City city = new City(ls);

            city.OnBuy();

            //Console.ReadLine();

            sport.OnBuy();

            Console.ReadLine();
        }
    }

    internal delegate void CarBuyHandler(Car car);

    internal class Car
    {
        internal string CarName;

        internal virtual void SetName()
        {
            this.CarName = "Car";
        }

        private event CarBuyHandler Buy;

        internal event CarBuyHandler BuyAccessor
        {
            add
            {
                lock (this)
                {
                    Buy += value;
                }
            }
            remove
            {
                lock (this)
                {
                    Buy -= value;
                }
            }
        }

        internal virtual void OnBuy()
        {
            Buy?.Invoke(this);
        }
    }

    internal class Sport : Car
    {
        LicenseService m_ls;
        internal Sport(LicenseService ls)
        {
            this.m_ls = ls;
            this.BuyAccessor += ls.GenerateLicense;
            SetName();
        }

        internal override void SetName()
        {
            this.CarName = "Sport";
        }

    }

    internal class City : Car
    {
        LicenseService m_ls;
        internal City(LicenseService ls)
        {
            this.m_ls = ls;
            this.BuyAccessor += ls.GenerateLicense;
            SetName();
        }

        internal override void SetName()
        {
            this.CarName = "City";
        }

    }

    internal class LicenseService
    {
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();

        internal void GenerateLicense(object sender, EventArgs args)
        {
            //Getting Sender Type
            string vehicleType = sender.GetType().ToString();

            //Generate Random License
            string licenseNumber = "";
            for (int i = 0; i < 5; i++)
            {
                lock (syncLock)
                { // synchronize
                    licenseNumber += random.Next(0, 9);
                }

                //licenseNumber += rnd.Next(0, 9).ToString();
            }

            //Print output of Random License with type car
            Console.WriteLine("{1} Car has been bought, this is the license number: {0}", licenseNumber, vehicleType);
        }

        internal void GenerateLicense(Car sender)
        {
            //Getting Sender Type
            string carType = sender.GetType().ToString();

            //Generate Random License
            string licenseNumber = "";
            for (int i = 0; i < 5; i++)
            {
                lock (syncLock)
                { // synchronize
                    licenseNumber += random.Next(0, 9);
                }

                //licenseNumber += rnd.Next(0, 9).ToString();
            }

            //Print output of Random License with type car
            Console.WriteLine("{1} Car has been bought, this is the license number: {0}", licenseNumber, carType);
        }
    }


}
