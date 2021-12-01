using AtlaJWT.Domain.Creator;
using AtlaJWT.Domain.Entities;
using AtlaJWT.Domain.Exception;
using AtlaJWT.Domain.Factory;
using AtlaJWT.Infra.Interfaces;
using AtlaJWT.Service;
using AtlaJWT.Tests.Generator;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AtlaJWT.Tests
{
    public class UserServiceTest
    {
        private readonly UserInfoFactoryMethod _userInfoFactoryMethod;
        private readonly UserService _userService;
        private readonly Mock<IUserRepository> _userRepository;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// No construtor eu adiciono um token em memória e faço instância do mock das classes que irei utilizar.
        /// </summary>
        public UserServiceTest()
        {
            _configuration = new ConfigurationBuilder().AddInMemoryCollection
                (new Dictionary<string, string>()
                { 
                    { "JWT:key", "984932487328979d_@879r78273897f.928913@" } 
                }).Build();
            _userInfoFactoryMethod = new UserInfoFactory();
            _userRepository = new Mock<IUserRepository>();
            _userService = new UserService(_configuration, _userRepository.Object, _userInfoFactoryMethod);
        }

        private UserInfo ReturnUserInfoType()
        => new UserInfo { Id = 11, UserName = "Gabriel", Role = "User", Password = "testea123" };


        /// <summary>
        /// Deve retornar um token válido
        /// <paramref name="userInfo"/>
        /// </summary>
        [Theory]
        [MemberData(nameof(UserInfoGenerator.GetDataUserInfoPass), MemberType = typeof(UserInfoGenerator))]
        private void Post_Login_ShouldReturnTokenJWT(UserInfo userInfo)
        {
            _userRepository.Setup(x => x.GetUser(It.IsAny<UserInfo>())).Returns(ReturnUserInfoType());
            var result = _userService.Login(userInfo);

            Assert.IsType<UserToken>(result.Result);

            Assert.NotNull(result.Result.Token);
        }

        /// <summary>
        /// deve estourar uma exceção ao perceber que o usuário existe.
        /// <paramref name="userRegistered"/>
        /// </summary>
        [Theory]
        [MemberData(nameof(UserRegisteredGenerator.GetDataUserRegisteredPass), MemberType = typeof(UserRegisteredGenerator))]
        public void Post_RegisterNewUser_ShouldReturnExceptionByUserExisting(UserRegistered userRegistered)
        {
            _userRepository.Setup(x => x.GetUserByUserName(It.IsAny<string>())).Returns(ReturnUserInfoType());
            var result = Assert.ThrowsAsync<UserException>(() => _userService.CreateUserInfo(userRegistered));
            Assert.IsType<UserException>(result.Result);
        }


        /// <summary>
        /// Deve retornar um usuário do tipo UserInfo ao registar.
        /// <paramref name="userRegistered"/>
        /// </summary>
        [Theory]
        [MemberData(nameof(UserRegisteredGenerator.GetDataUserRegisteredPass), MemberType = typeof(UserRegisteredGenerator))]
        public void Post_RegisterNewUser_ShouldReturnUserInfoType(UserRegistered userRegistered)
        {
            _userRepository.Setup(x => x.SaveUser(It.IsAny<UserInfo>())).Returns(ReturnUserInfoType());
            var result = _userService.CreateUserInfo(userRegistered);
            Assert.IsType<UserInfo>(result.Result);
        }

        /// <summary>
        /// Retorna um userInfo 
        /// </summary>
        /// <param name="userRegistered"></param> 
        [Theory]
        [MemberData(nameof(UserRegisteredGenerator.GetDataUserRegisteredPass), MemberType = typeof(UserRegisteredGenerator))]
        public void Put_Update_ShouldReturnUserInfoType(UserRegistered userRegistered)
        {
            _userRepository.Setup(x => x.GetUserInfoById(It.IsAny<int>())).Returns(ReturnUserInfoType());

            Assert.IsType<UserInfo>(_userService.UpdateUserInfo(userRegistered).Result);

        }

        /// <summary>
        /// 
        /// </summary>
        [Theory]
        [MemberData(nameof(UserInfoGenerator.GetDataUserInfoFail), MemberType = typeof(UserInfoGenerator))]
        public void Post_Login_ShouldReturnException(UserInfo userInfo)
        {
            var result = Assert.ThrowsAsync<UserException>(() => _userService.Login(userInfo));
            Assert.IsType<UserException>(result.Result);

        }
    }
}
