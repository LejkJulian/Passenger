using Passengers.Infrastructure.Commands.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Infrastructure.Handlers.User
{
    public class ChangeUserPassword:ICommand
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; } 
    }
}
