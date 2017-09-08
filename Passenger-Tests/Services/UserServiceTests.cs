using AutoMapper;
using FluentAssertions;
using Moq;
using Passengers.Core.Domain;
using Passengers.Core.Repositories;
using Passengers.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Passengers.Tests.Services
{
    public class UserServiceTests //class must by public else test explorer doesn't saw a test case
    {
        private Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();//utworzenie mocka z Repo
        private Mock<IMapper> mapperMock = new Mock<IMapper>();//Utworzenie mocka z mappera do przeksztalcania
        [Fact]
        public async Task register_async_should_invoke_add_async_on_repository()
        {
            //Arrange
            var userService = new UserServices(userRepositoryMock.Object, mapperMock.Object);
            //Act
            await userService.RegisterAsync("user@email.com", "user", "secret");
            //Assert
            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }
        [Fact]
        public async Task when_calling_get_async_and_user_exist_it_should_invoke_user_repository_get_async()
        {
            //Arrange
            UserServices userService = new UserServices(userRepositoryMock.Object, mapperMock.Object); //utworzenie user service, któy będzie testowany
            var existemail = "user1email@gmail.com";
            var user = new User("user1email@gmail.com", "tabaluga", "sprytne", "salt");

            //Act
            await userService.GetAsync(existemail);//czekam na userservice i metode get
            userRepositoryMock.Setup(e => e.GetAsync(It.IsAny<string>())).ReturnsAsync(user);
            //setup wstawia do userrepo oniekt user, który odzwierciedla uzytkownika

            //Assert
            userRepositoryMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once);
        }
        [Fact]
        public async Task when_calling_get_async_and_user_NOT_exist_it_should_invoke_user_repository_get_async()
            //positiv invoking user repository get async method when get async and user not exist
        {
            //Arrange
            
            var userService = new UserServices(userRepositoryMock.Object, mapperMock.Object);
            //Act
            await userService.GetAsync("user1email@gmail.com");
            //czy w repouser jest dany email. nie ma bo return jest null
            userRepositoryMock.Setup(x => x.GetAsync("user1email@gmail.com")).ReturnsAsync(() => null);
            //Assets
            userRepositoryMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once);
        }
    }
}
