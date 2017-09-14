using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Infrastructure.Commands.User
{
   public  class CreateUser:ICommand
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
