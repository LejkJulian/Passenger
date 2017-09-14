using System;
using System.Collections.Generic;
using System.Text;
using Passengers.Core.Domain;
namespace Passengers.Core.Repositories
{
    public interface IPassengerRepository
    {
        Passenger GetID(Guid Id);
        Passenger GetAdress(Node node);
        void Add(Passenger passenger);
        void Update(Passenger passenger);
        void Remove(Passenger passenger);
    }
}
