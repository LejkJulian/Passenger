using Passengers.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Core.Repositories
{
    public interface IUserRepository//dodać repozytoria do drivera 
    {
        Task<User> GetAsync(string email);
        Task<User> GetAsync( Guid ID);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task RemoveAsync(Guid ID);
    }
}
