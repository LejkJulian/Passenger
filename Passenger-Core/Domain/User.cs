using System;
using System.Collections.Generic;
using System.Text;

namespace Passenger.Core.Domain
{
    public class User
    {
        public Guid ID { get; protected set; }
        public string Email { get;protected set; }
        public string UserName { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string Name { get; protected set; }
        public string LastName { get; protected set; }    
        public DateTime CreatedAt { get; protected set; }

        protected User()
        {

        }
        public User(string email,string username, string pasword, string salt)
        {//zrobic walidacje danych
            ID = Guid.NewGuid();
            Email = email.ToLowerInvariant();
            UserName = username;
            Password = pasword;
            Salt = salt;
            CreatedAt = DateTime.UtcNow;

        }
    }
}
