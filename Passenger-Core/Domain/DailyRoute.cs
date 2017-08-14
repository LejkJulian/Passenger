using System;
using System.Collections.Generic;
using System.Text;

namespace Passenger.Core.Domain
{
   public class DailyRoute
    {
        public Guid ID { get; protected set; }
        public Route Route { get; protected set; }
        public IEnumerable<PassengerNode> PassengerNode { get; protected set; }
    }
}
