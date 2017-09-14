using Passengers.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passengers.Infrastructure.Services
{
    public interface IDriverService
    {
        Task<DriverDto> GetAsync(string DriverName);
        Task SetVehicleAsync(Guid userID, string brand, string name);

        //Task<DriverDetailsDto> GetAsync(Guid userId);
        //Task<IEnumerable<DriverDto>> BrowseAsync();
        //Task CreateAsync(Guid userId);
        //Task SetVehicle(Guid userId, string brand, string name);
        //Task DeleteAsync(Guid userId);


    }
}
