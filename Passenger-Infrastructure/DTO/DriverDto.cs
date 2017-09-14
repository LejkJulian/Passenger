using Passengers.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Infrastructure.DTO
{
   public class DriverDto
    {
        public Guid UserId { get; set; }
        public string DriverName { get; set; }
        public Vehicle MyVehicle { get;  set; }
        public IEnumerable<Route> Routes { get;  set; }
        public IEnumerable<DailyRoute> DailyRoutes { get;  set; }
        
    }
}
