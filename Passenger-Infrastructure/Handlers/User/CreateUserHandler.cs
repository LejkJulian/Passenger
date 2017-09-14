using Passengers.Infrastructure.Commands;
using Passengers.Infrastructure.Commands.User;
using Passengers.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Infrastructure.Handlers.User
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserService _userService;

        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task HandleAsync(CreateUser command)
        {
            await _userService.RegisterAsync(command.Email, command.UserName, command.Password);
        }
    }
}
