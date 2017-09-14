using Passengers.Core.Domain;
using Passengers.Core.Repositories;
using System;
using Passengers.Infrastructure.DTO;
using AutoMapper;
using System.Threading.Tasks;

namespace Passengers.Infrastructure.Services
{
        public class UserServices : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserServices(IUserRepository userRepository,IMapper mapper)//iuserrepository został dodany jak argument konstruktora
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDto> GetAsync(string email)
        {
            var User =await _userRepository.GetAsync(email);
            return  _mapper.Map<User, UserDto>(User);
            
        }

        public async Task RegisterAsync(string email,string username,string password)
        {
            var user = await _userRepository.GetAsync(email);
            if(user != null)
            {
                throw new Exception($"User with email{email} already exist");
            }
            string salt =  Guid.NewGuid().ToString("N");
            user = new User(email,username,password,salt);
               await  _userRepository.AddAsync(user);
        }
        
        
    }
}
