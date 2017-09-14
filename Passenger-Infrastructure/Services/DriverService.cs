using System;
using System.Collections.Generic;
using System.Text;
using Passengers.Infrastructure.DTO;
using Passengers.Core.Repositories;
using AutoMapper;
using Passengers.Core.Domain;
using System.Threading.Tasks;

namespace Passengers.Infrastructure.Services
{
    class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;
        public DriverService(IDriverRepository driverRepository, IMapper mapper)
        {
            _driverRepository = driverRepository;
            _mapper = mapper;
        }
        public async Task<DriverDto> GetAsync(string driverName)
        {
            var driver =await  _driverRepository.GetNameAsync(driverName);
            return _mapper.Map<Driver,DriverDto>(driver);
        }
        //return new DriverDto
        //{
        //    UserId = driver.UserID,
        //    DriverName = driver.DriverName,
        //    Vehicle = driver.Vehicle,
        //    Routes = driver.Routes,
        //    DailyRoutes = driver.DailyRoutes,

        //};

        public async Task SetVehicleAsync(Guid userID, string brand, string name)
        {
            await Task.CompletedTask;
        }
    }
}

