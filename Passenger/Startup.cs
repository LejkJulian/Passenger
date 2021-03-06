﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Passengers.Infrastructure.Services;
using Passengers.Core.Repositories;
using Passengers.Infrastructure.Repository;
using Passengers.Infrastructure.Mappers;


using Passengers.Infrastructure.EF;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Passengers.Infrastructure.IoC.Modules;
using Passengers.Infrastructure.Commands.User;
using Passengers.Infrastructure.Commands;
using Passengers.Infrastructure.IoC;

namespace Passengers
{
    public class Startup
    {
       
        public IContainer ApplicationContainer { get; private set; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            //Konfigurujemy IoC wstrzykiwanie interfejsów do klas
            services.AddScoped<IUserService,UserServices>();
            services.AddScoped<IUserRepository, InMemoryUserRepository>();/////////
            
            services.AddEntityFrameworkInMemoryDatabase();
            services.AddDbContext<PassengerContext>();
            //dodane prze mnie
            services.AddScoped<IDriverService, DriverService>();
            services.AddSingleton<IDriverRepository, InMemoryDriverRepositories>();/////////
            services.AddMvc();
            /////Autofac

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule<CommandModule>();
            //builder.RegisterType<CommandDispatcher>()
            //    .As<ICommandDispatcher>();
            builder.RegisterModule(new ContainerModule(Configuration));
            
            ApplicationContainer = builder.Build();
            
            builder.RegisterType<commandDispatcher>().As<ICommandDispatcher>();
            return new AutofacServiceProvider(ApplicationContainer);
    
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime AppLifeTime)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseMvc();
            AppLifeTime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());
        }
    }
}
