using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Core.Domain
{
    public class Driver
    {
        
        public Guid UserID { get; protected set; }
        public string DriverName { get;protected set; }
        public Vehicle Vehicle { get; protected set; }
        public DateTime UpdateAt { get; protected set; }
        public IEnumerable<Route> Routes { get; protected set; }
        public IEnumerable<DailyRoute> DailyRoutes { get; protected set; }
        protected Driver() { }
        public Driver(Guid id,string Name)
        {
            DriverName = Name;
            UserID = id;
        }
        public void AddVehicle(Vehicle vehicle)
        {
            Vehicle = vehicle;
            UpdateAt = DateTime.UtcNow;
        }
       public void AddRoute(string name, Node start,Node end,double lenght)
        {
            
        }
    }
}
