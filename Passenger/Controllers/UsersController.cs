using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passengers.Infrastructure.Services;
using Passengers.Infrastructure.Commands.User;
using Passengers.Infrastructure.Commands;
using Passenger.Api.Controllers;
using Passengers.Infrastructure.Settings;

namespace Passengers.Controllers
{
    [Route("[controller]")]
    public class UsersController : APIControllerBase
    {
        private readonly IUserService _userService;
        
        public UsersController(IUserService userService, ICommandDispatcher commandDispatcher,GeneralSettings settings) :base(commandDispatcher)
        {
            _userService = userService;
            
            
        }
        // GET api/email
        [HttpGet("{email}")]
        public async Task <IActionResult> GetAsync(string email)
        {
            var user = await _userService.GetAsync(email);
            if (user == null)
            { return NotFound("gdfgfdg"); }
            return Json(user);
        }


        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Created($"users/{command.Email}", new object());
        }

    }
}
