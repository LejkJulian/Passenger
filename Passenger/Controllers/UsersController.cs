using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Services;
using Passenger.Infrastructure.DTO;

namespace Passenger.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        // GET api/email
        [HttpGet("{email}")]
        public UserDto Get(string email)
        => _userService.Get(email);

       
    }
}
