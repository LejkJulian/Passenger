using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Passengers.Tests.EndToEnd.ControllersTest
{
    public abstract class ControllerTestBase
    {
        protected readonly TestServer _server;
        protected readonly HttpClient _client;

        public ControllerTestBase()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }
        protected static StringContent GetPayLoad(object data)
        {
            //konwersja data do json
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
