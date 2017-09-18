using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Passengers.Infrastructure.Commands.User;
using Passengers.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Passengers.Tests.EndToEnd.ControllersTest
{
   public  class UsersControllersTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public UsersControllersTest()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()//utworzenie Api  w pamięci
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }
        [Fact]
        public async Task given_valid_email_user_should_exist()
        {
            // Act
            var useremail = "user1email@gmail.com";
            var user =await GetUserAsync(useremail);

            // Assert
            user.Email.ShouldBeEquivalentTo(useremail);
        }
        [Fact]
        public async Task given_valid_email_user_should_not_exist()
        {
            // Act
            var useremail = "user143email@gmail.com";
            var response = await _client.GetAsync($"/users/{useremail}");

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NotFound);
        }
        [Fact]
        public async Task given_unique_email_user_should_be_created()
        {
            // Act
            //utworzyć nowego usera/ post async/sprawdzamy statuscode i header//jsonconvert.serializableobject

            var request = new CreateUser
            {
                Email = "test@mail",
                Password = "secrfsdf",
                UserName = "tabaluga"
                
            };
            var payload = GetPayLoad(request);
            var response = await _client.PostAsync("users",payload);
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Created);
            response.Headers.Location.ToString().ShouldBeEquivalentTo($"/users/{request.Email}");
            var user = await GetUserAsync(request.Email);

            // Assert
            user.Email.ShouldBeEquivalentTo(request.Email);

        }
        private async Task <UserDto> GetUserAsync(string email)// Sprawdzenie czy uzytkownik o danym email istnieje w bazie. zwraca obiekt USerDTO
        {
            var response = await _client.GetAsync($"/users/{email}");
            var responseString = await response.Content.ReadAsStringAsync();
            return  JsonConvert.DeserializeObject<UserDto>(responseString);
        }
        private static StringContent GetPayLoad(object data)
        {
            //konwersja data do json
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8,"application/json");
        }
    }
}
