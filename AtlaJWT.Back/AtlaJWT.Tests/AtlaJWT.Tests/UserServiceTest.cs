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
        private readonly IConfiguration _configuration;
        /// <summary>
        /// 
        /// </summary>
        public UserServiceTest()
        {
            _userInfoFactoryMethod = new UserInfoFactory();
            _userService = new UserService(_configuration, new Mock<IUserRepository>().Object, _userInfoFactoryMethod);
        }

        /// <summary>
        /// 
        /// </summary>
        [Theory]
        [MemberData(nameof(UserRegisteredGenerator.GetDataUserRegisteredPass), MemberType = typeof(UserRegisteredGenerator))]
        public void Post_RegisterNewUser(UserRegistered userRegistered)
        {
            var result = _userService.CreateUserInfo(userRegistered);
            Assert.IsType<UserInfo>(result);
        }

        /// <summary>
        /// 
        /// </summary>
        [Theory]
        [MemberData(nameof(UserInfoGenerator.GetDataUserInfoFail), MemberType = typeof(UserInfoGenerator))]
        public void Post_LoginUser(UserInfo userInfo)
        {
            var resut = Assert.ThrowsAsync<UserException>(() => _userService.Login(userInfo));
            Assert.IsType<UserException>(resut);

        }
    }
}
