using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Passengers.Core.Domain
{
    public class Driver
    {
        
        public Guid UserID { get; protected set; }
        public string DriverName { get;protected set; }
        public Vehicle Vehicle { get; protected set; }
        public DateTime UpdateAt { get; protected set; }
        public IEnumerable<Route> Routes
        {
            get { return _routes; }
            set
            {
                _routes = new HashSet<Route>(value);
            }
        }
        
        public ISet<Route> _routes = new HashSet<Route>();
        public ISet<DailyRoute> _dailyRoutes = new HashSet<DailyRoute>();
        public IEnumerable<DailyRoute> DailyRoutes
        { get { return _dailyRoutes; }
          set
          {
                _dailyRoutes = new HashSet<DailyRoute>(value);
          }
        }
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
        public void AddRoute(string name, Node start, Node end, double lenght)
        {
            var route = Routes.SingleOrDefault(x => x.Name == name);
            if( route== null)
            {
                throw new Exception($"Route with name {name} already exist for driver{DriverName}.");
            }
            _routes.Add(Route.CreateRoute(name, start, end, lenght));
            UpdateAt = DateTime.UtcNow;
        }
        public void RemoveRoute(string name)
        {
           var route =_routes.SingleOrDefault(x => x.Name == name);
            if(route== null)
            {
                throw new Exception($"Route {name} for driver{DriverName} not found.");
            }
            _routes.Remove(route);
            UpdateAt = DateTime.UtcNow;
        }
         
    }
}
