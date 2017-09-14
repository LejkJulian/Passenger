using Passengers.Infrastructure.Commands;
using Passengers.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Passengers.Infrastructure.Commands.User;
using Microsoft.AspNetCore.Mvc;

namespace Passenger.Api.Controllers
{
    public class AccountController: APIControllerBase
    {
        

        public AccountController( ICommandDispatcher commandDispatcher) :base(commandDispatcher)
        {
        }


        [HttpPut("")]
        [Route("password")]
        public async Task<IActionResult> ChangeUserPassword([FromBody]CreateUser command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return NoContent();
        }
    }
}
