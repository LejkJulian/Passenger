using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Core.Domain
{
   public  class Node//węzeł value object
    {
        public string Address { get; protected set; }
        public double Longitude { get; protected set; }
        public double Latitude { get; protected set; }
        public DateTime UpdateAt { get; protected set; }
        protected Node() { }
        protected Node(string addres,double longtitude,double latitude)
        {
            SetAddress(addres);
            SetLatitude(latitude);
            SetLongtitude(longtitude);
            //chyba do wyjebania
        }
        private void SetAddress(string address)
        {
            Address = address;
            UpdateAt = DateTime.UtcNow;
        }
        private void SetLatitude(double latitude)
        {
            Latitude = latitude;
            UpdateAt = DateTime.UtcNow;
        }
        private void SetLongtitude(double longtitude)
        {
            Longitude = longtitude;
            UpdateAt = DateTime.UtcNow;
        }
        public static Node CreateNode(string address, double longtitude, double latitude)
            => new Node(address, longtitude, latitude);
    }
}
