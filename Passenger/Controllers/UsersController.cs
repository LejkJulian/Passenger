using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passengers.Infrastructure.Services;
using Passengers.Infrastructure.DTO;
using Passengers.Infrastructure.Commands.User;

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
        public async Task <IActionResult> GetAsync(string email)
        {
            var user = await _userService.GetAsync(email);
            if(user==null)
            { return NotFound(); }
            return Json(user);
        }
        
        
       [HttpPost("")]
       public async Task<IActionResult> Post([FromBody]CreateUser user)
        {
           await  _userService.RegisterAsync(user.Email, user.UserName, user.Password);
            return Created($"/users/{user.Email}",user.UserName);
        }
    }
}
