using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Infrastructure.Commands.User
{
    public class commandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;
        public commandDispatcher(IComponentContext context)
        {
            _context = context;
        }
        public async  Task DispatchAsync<T>(T command) where T : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException();
            }
            var handler = _context.Resolve<ICommandHandler<T>>();
            await handler.HandleAsync(command);
        }
    }
}
