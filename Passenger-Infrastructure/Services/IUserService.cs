using Passengers.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Infrastructure.Services
{
    public interface IUserService
    {
         Task<UserDto> GetAsync(string email);
         Task RegisterAsync(string email,string username, string password);
    }
}
