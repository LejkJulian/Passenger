using Passengers.Core.Domain;
using Passengers.Core.Repositories;
using System;
using Passengers.Infrastructure.DTO;

namespace Passengers.Infrastructure.Services
{
        public class UserServices : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)//iuserrepository został dodany jak argument konstruktora
        {
            _userRepository = userRepository;
        }

        public UserDto Get(string email)
        {
            var User = _userRepository.Get(email);
            return new UserDto
            {
                ID = User.ID,
                Email = User.Email,
                UserName = User.UserName,
                LastName = User.LastName,
            
            };
        }

        public void Register(string email,string username,string password)
        {
            var user = _userRepository.Get(email);
            if(user != null)
            {
                throw new Exception($"User with email{email} already exist");
            }
            string salt = Guid.NewGuid().ToString("N");
            user = new User(email,username,password,salt);
            _userRepository.Add(user);
        }
    }
}
