using Autofac;
using Microsoft.Extensions.Configuration;
using Passengers.Infrastructure.Extensions;
using Passengers.Infrastructure.Settings;


namespace Passengers.Infrastructure.IoC.Modules
{
    public class SettingsModule :Autofac.Module
    {
        private IConfiguration _configuration;
        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void Load(ContainerBuilder builder)
        {//rejestracja wstrzykiwań interfejsów  
            builder.RegisterInstance(_configuration.GetSettings<GeneralSettings>())
                .SingleInstance();
        }
    }
}
