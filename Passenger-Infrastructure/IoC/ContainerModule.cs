using Autofac;
using Microsoft.Extensions.Configuration;
using Passengers.Infrastructure.Extensions;
using Passengers.Infrastructure.IoC.Modules;
using Passengers.Infrastructure.Mappers;
using Passengers.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Infrastructure.IoC
{
    public class ContainerModule :Autofac.Module
    {
        private IConfiguration _configuration;
        public ContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void Load(ContainerBuilder builder)
        {//rejestracja wstrzykiwań interfejsów  
            builder.RegisterInstance(AutoMapperConfig.Initialize())
                .SingleInstance();
            builder.RegisterModule<CommandModule>();
            builder.RegisterModule(new SettingsModule(_configuration));
        
        }
    }
}
