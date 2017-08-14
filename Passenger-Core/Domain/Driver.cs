using System;
using System.Collections.Generic;
using System.Text;

namespace Passenger.Core.Domain
{
    public class Driver
    {
        public Guid ID { get; protected set; }
        public Guid UserID { get; protected set; }
        public Vehicle Vehicle { get; protected set; }
        public IEnumerable<Route> Routes { get; protected set; }
        public IEnumerable<DailyRoute> DailyRoutes { get; protected set; }

    }
}
