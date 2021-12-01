using AtlaJWT.Domain.Creator;
using AtlaJWT.Domain.Entities;
using AtlaJWT.Domain.Exception;
using AtlaJWT.Domain.Factory;
using AtlaJWT.Infra.Interfaces;
using AtlaJWT.Service;
using AtlaJWT.Service.Interfaces;
using AtlaJWT.Tests.Generator;
using Moq;
using System;
using Xunit;

namespace AtlaJWT.Tests
{
    /// <summary>
    /// Classe para testar os m�todos do Creator.
    /// </summary>
    public class UserInfoCreatorTest
    {
        private UserService _userService;
        private UserInfoFactoryMethod _userInfoFactoryMethod;
       /// <summary>
       /// Moco o _userService para n�o fazer a requisi��o ao banco e testar somente as valida��es.
       /// </summary>
        public UserInfoCreatorTest()
        {
            _userInfoFactoryMethod = new UserInfoFactory();
            _userService = new UserService(null, new Mock<IUserRepository>().Object, _userInfoFactoryMethod);
        }


        /// <summary>
        /// Deve retornar erro caso a string seja nulo/em branco.
        /// </summary>
        /// <param>not contains</param>
        [Fact]
        public void ShouldReturnErrorByNameInvalid()
        {
            string userName = "";
            _userInfoFactoryMethod.ValidatingUserName(userName);

            Assert.True(_userInfoFactoryMethod.ValidatingUserName(userName));
        }

        /// <summary>
        /// Deve retornar uma exception ao tentar encriptar a senha
        /// </summary>
        /// <param name="userRegistered"></param>
        [Theory]
        [MemberData(nameof(UserRegisteredGenerator.GetDataUserRegisteredFailed), MemberType = typeof(UserRegisteredGenerator))]
        public void Should_ThrowException_EncryptPassword(UserRegistered userRegistered)
        {
            var resut = Assert.Throws<UserException>(() => _userInfoFactoryMethod.EncryptPassword(userRegistered.Password));
            Assert.IsType<UserException>(resut);
        }


        /// <summary>
        /// Deve retornar um objeto do tipo UserInfo.
        /// </summary>
        /// <param name="userRegistered"></param>
        [Theory]
        [MemberData(nameof(UserRegisteredGenerator.GetDataUserRegisteredPass), MemberType = typeof(UserRegisteredGenerator))]
        public void Post_CreateNewUserInfo(UserRegistered userRegistered)
        {
            var userInfo = _userInfoFactoryMethod.MakeUserInfo(userRegistered);

            Assert.IsType<UserInfo>(userInfo);

        }
    }
}
