using Passengers.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Core.Repositories
{
    public interface IDriverRepository
    {

        Task<Driver> GetNameAsync(string driverName);
        Task<IEnumerable<Driver>> GetAllAsync();
        Task AddAsync(Driver driver);
        Task UpdateAsync(Driver driver);
        Task RemoveAsync(Driver driver);

        //chyba nie wiem jak on działa
        //Driver GetUserID(Guid UserID);
        //IEnumerable<Driver> GetAll();
        //Vehicle Get(string Name);
        //IEnumerable<Route> GetRoute();
        //IEnumerable<DailyRoute> GetDailyRoute();
    }
}

