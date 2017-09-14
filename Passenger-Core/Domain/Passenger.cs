using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Core.Domain
{
    public class Passenger
    {
        public Guid ID { get; protected set; }
        public Guid UserID { get; protected set; }
        public Node Address { get; protected set; }

    }
}
