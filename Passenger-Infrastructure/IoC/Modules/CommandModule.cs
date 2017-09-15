using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using System.Reflection;
using Passengers.Infrastructure.Commands;
using Passengers.Infrastructure.Commands.User;
using Microsoft.Extensions.Configuration;

namespace Passengers.Infrastructure.IoC.Modules
{
    public class CommandModule :Autofac.Module
    {
       
        protected override void Load(ContainerBuilder builder)
            {//rejestracja wstrzykiwań interfejsów
                var assembly = typeof(CommandModule)
                    .GetTypeInfo()
                    .Assembly;

                builder.RegisterAssemblyTypes(assembly)
                    .AsClosedTypesOf(typeof(ICommandHandler<>))
                    .InstancePerLifetimeScope();

                builder.RegisterType<commandDispatcher>()
                    .As<ICommandDispatcher>()
                    .InstancePerLifetimeScope();
            }
    }
}
