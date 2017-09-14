using Passengers.Infrastructure.Commands;
using Passengers.Infrastructure.Commands.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Infrastructure.Handlers.User
{
    public class ChangeUserPasswordHandler : ICommandHandler<ChangeUserPassword>
    {

        public async Task HandleAsync(ChangeUserPassword command)
        {
            await Task.CompletedTask;
        }
    }
}
