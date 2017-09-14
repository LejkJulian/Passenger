using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Passengers.Infrastructure.DTO;
using Passengers.Infrastructure.Handlers.User;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Passengers.Tests.EndToEnd.ControllersTest
{
    public class AccountControllerTest :ControllerTestBase
    {
        
        
        [Fact]
        public async Task given_valid_current_and_new_password_it_should_be_changed()
        {
            // Act
            //utworzyć nowego usera/ post async/sprawdzamy statuscode i header//jsonconvert.serializableobject

            var command = new ChangeUserPassword
            {
                
                CurrentPassword = "secrfsdf",
                NewPassword = "secret22"
                
            };
            var payload = GetPayLoad(command);
            var response = await _client.PostAsync("account/password", payload);
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NoContent);
            

            // Assert
           

        }
    }
  
}
