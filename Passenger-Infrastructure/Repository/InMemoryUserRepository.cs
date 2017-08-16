using Passengers.Core.Repositories;
using System;
using System.Collections.Generic;
using Passengers.Core.Domain;
using System.Linq;

namespace Passengers.Infrastructure.Repository
{
        public  class InMemoryUserRepository : IUserRepository
    {
        private ISet<User> _users =new HashSet<User>
        {   new User("user1email@gmail.com","user1","password1","adsf213"),
            new User("user2email@gmail.com","user2","password2","adsf213"),
            new User("user3email@gmail.com","user3","password3","adsf213")
        };
        //Lista użytkowników
            public void Add(User user)
            {
            _users.Add(user);
            }

            public void Remove(Guid Id)
            {
            var user = Get(Id);//pobieramy użytkownika o ID= a następnie usuwamy go z listy
            _users.Remove(user);
            }

            public User Get(string email)
            =>_users.Single(x => x.Email==email.ToLowerInvariant());


            public User Get(Guid Id)
            =>_users.Single(x => x.ID == Id);

            public IEnumerable<User> GetAll()
             => _users;

            public void Update(User user)
            {
            throw new NotImplementedException();
            }
    }
}
