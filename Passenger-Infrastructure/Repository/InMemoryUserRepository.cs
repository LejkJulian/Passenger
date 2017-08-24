using Passengers.Core.Repositories;
using System;
using System.Collections.Generic;
using Passengers.Core.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace Passengers.Infrastructure.Repository
{
        public  class InMemoryUserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>
        {   new User("user1email@gmail.com","user1","password1","adsf213"),
            new User("user2email@gmail.com","user2","password2","adsf213"),
            new User("user3email@gmail.com","user3","password3","adsf213"),
        };
        //Lista użytkowników

        public async Task<User> GetAsync(string email)
             =>await Task.FromResult( _users.SingleOrDefault(x => x.Email.Equals(email,StringComparison.OrdinalIgnoreCase)));
        //=>await Task.FromResult(_users.SingleOrDefault(x => x.Email ==email.ToLowerInvariant()));

        public async Task<User> GetAsync(Guid Id)
            =>await Task.FromResult( _users.SingleOrDefault(x => x.ID == Id));

        public async Task AddAsync(User user)
            {
            _users.Add(user);
            await Task.CompletedTask;
            }

        public async Task RemoveAsync(Guid Id)
            {
                var user =await GetAsync(Id);//pobieramy użytkownika o ID= a następnie usuwamy go z listy
                _users.Remove(user);
                await Task.CompletedTask;
            }
        public async Task<IEnumerable<User>> GetAllAsync()
            
             =>await Task.FromResult(_users);

        public async Task UpdateAsync(User user)
            {
            await Task.CompletedTask;
            }
    }
}
