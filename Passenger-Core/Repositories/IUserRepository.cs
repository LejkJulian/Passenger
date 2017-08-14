using Passenger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passenger.Core.Repositories
{
    public interface IUserRepository//dodać repozytoria do drivera 
    {
        User Get(string email);
        User Get( Guid ID);
        IEnumerable<User> GetAll();
        void Add(User user);
        void Update(User user);
        void Remove(Guid ID);
    }
}
