using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passengers.Infrastructure.Services;
using Passengers.Infrastructure.Commands.User;
<<<<<<< HEAD
=======
using Passengers.Infrastructure.Commands;
using Passenger.Api.Controllers;
using Passengers.Infrastructure.Settings;
>>>>>>> Develop

namespace Passengers.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
<<<<<<< HEAD
        public UsersController(IUserService userService)
        {
            _userService = userService;
=======
        
        public UsersController(IUserService userService, ICommandDispatcher commandDispatcher,GeneralSettings settings) :base(commandDispatcher)
        {
            _userService = userService;
            
            
>>>>>>> Develop
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
