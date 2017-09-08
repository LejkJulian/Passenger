using Passengers.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Passengers.Core.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace Passengers.Infrastructure.Repository
{
    class InMemoryDriverRepositories : IDriverRepository
    {
        private ISet<Driver> _drivers = new HashSet<Driver>();

        public async Task AddAsync(Driver driver)
        {
            _drivers.Add(driver);
            await Task.CompletedTask;
        }

        public async Task <IEnumerable<Driver>> GetAllAsync()

            => await Task.FromResult(_drivers);

        public async Task<Driver> GetNameAsync(string userName)
        {
            return await Task.FromResult( _drivers.SingleOrDefault(x => x.DriverName == userName));
           
        }

        public async Task RemoveAsync(Driver driver)
        {
            _drivers.Remove(driver);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Driver driver)
        {
            await Task.CompletedTask;

        }
    }
}

