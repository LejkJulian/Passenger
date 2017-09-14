using Microsoft.AspNetCore.Mvc;
using Passengers.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Passenger.Api.Controllers 
{
    [Route("[controller]")]
    public abstract class APIControllerBase:Controller
    {
        protected readonly ICommandDispatcher _commandDispatcher;
        
        protected APIControllerBase(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }
    }
}
