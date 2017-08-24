﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passengers.Infrastructure.Services;
using Passengers.Infrastructure.DTO;

namespace Passengers.Controllers
{
    [Route("[controller]")]
    public class DriverController : Controller
    {
        private readonly IDriverService _driverService;
        public DriverController(IDriverService driverservice)
        {
            _driverService = driverservice;
        }
        // GET api/id
        [HttpGet("{id}")]
        public async Task<DriverDto> GetAsync(Guid id)
        => await _driverService.GetAsync(id);
        // GET api/id
      


    }
}