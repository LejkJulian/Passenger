using System;
using System.Collections.Generic;
using System.Text;
using Passengers.Infrastructure.DTO;
using Passengers.Core.Repositories;

namespace Passengers.Infrastructure.Services
{
    class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }
        public DriverDto Get(Guid userID)
        {
            var driver = _driverRepository.GetID(userID);
            return new DriverDto
            {
                UserId = driver.UserID,
                DriverName = driver.DriverName,
                Vehicle = driver.Vehicle,
                Routes = driver.Routes,
                DailyRoutes = driver.DailyRoutes,

            };
        }
        public void SetVehicle(Guid userID, string brand, string name)
        {

        }
    }
}
