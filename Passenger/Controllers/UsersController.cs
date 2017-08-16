using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passengers.Infrastructure.Services;
using Passengers.Infrastructure.DTO;

namespace Passengers.Controllers
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
