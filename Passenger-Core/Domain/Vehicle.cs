using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Core.Domain
{
   public  class Vehicle//value object
    {
        public string Brand { get; protected set; }
        public string Name { get; protected set; }
        public int Seats { get; protected set; }
        protected Vehicle() { }
        protected Vehicle(string Brand,string Name, int Seats)
        {
            SetBrand(Brand);
            SetName(Name);
            SetSeats(Seats);

        }
        private void SetBrand(string brand)
        {
            Brand = brand;
        }
        private void SetName(string name)
        {
            Name = name;
        }
        private void SetSeats(int seats)
        {
            Seats = seats;
        }
        //zastępuje konstruktor. wzorzec factoryczy builder?
        public static Vehicle Create(string Brand, string Name, int Seats)
            => new Vehicle(Brand, Name, Seats);
    }

    
}
