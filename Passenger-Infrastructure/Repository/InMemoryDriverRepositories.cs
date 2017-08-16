using Passengers.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Passengers.Core.Domain;
using System.Linq;

namespace Passengers.Infrastructure.Repository
{
    class InMemoryDriverRepositories : IDriverRepository
    {
        private ISet<Driver> _drivers = new HashSet<Driver>();
        
        public void Add(Driver driver)
        {
            _drivers.Add(driver);
        }

        public IEnumerable<Driver> GetAll()
            =>_drivers;

        public Driver GetID(Guid UserID)
        {
           return _drivers.SingleOrDefault(x => x.UserID == UserID);
        }

        public void Remove(Driver driver)
        {
            _drivers.Remove(driver);
        }

        public void Update(Driver driver)
        {
           
        }
    }
}
