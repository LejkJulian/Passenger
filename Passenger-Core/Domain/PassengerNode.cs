using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Core.Domain
{
   public  class PassengerNode//droga pasażera
    {
        public  Node Node{ get;protected set;}
        public  Passenger Passenger { get; protected set; }
        private PassengerNode()  { }
        
        public PassengerNode(Passenger passenger,Node node)
        {
            Node = node;
            Passenger = passenger;
        }
        public PassengerNode CreatePassengerNode(Node node, Passenger passenger)
            => new PassengerNode(passenger,node );  
    }
}
