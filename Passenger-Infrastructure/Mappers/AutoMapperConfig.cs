using AutoMapper;
using Passengers.Core.Domain;
using Passengers.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()//automatyczne tworzenie DTo
           => new MapperConfiguration(cfg =>
           {
               cfg.CreateMap<User, UserDto>();
               cfg.CreateMap<Driver, DriverDto>()
                    .ForMember(x => x.MyVehicle, m => m.MapFrom(p => p.Vehicle));//mozna dać takze domyslną wartosc
           })
            .CreateMapper();
    }
}
