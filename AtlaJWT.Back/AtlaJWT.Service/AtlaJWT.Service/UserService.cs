using AtlaJWT.Domain.Creator;
using AtlaJWT.Domain.Entities;
using AtlaJWT.Domain.Exception;
using AtlaJWT.Domain.Factory;
using AtlaJWT.Infra.Interfaces;
using AtlaJWT.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AtlaJWT.Service
{
    public class UserService : IUserService
    {
        private IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly UserInfoFactoryMethod _userInfoFactoryMethod;

        public UserService(
        IConfiguration configuration,
        IUserRepository userRepository,
        UserInfoFactoryMethod userInfoFactoryMethod)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _userInfoFactoryMethod = userInfoFactoryMethod;
        }

        public async Task<IQueryable<UserRegistered>> GetAllUserRegistered()
        {
            try
            {
                var userList = await _userRepository.GetAll();
                userList.ToList().ForEach(x => x.Password = "");

                return userList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool IsExistingUserName(string userName)
        {
            if (_userRepository.GetUserByUserName(userName) != null)
                return true;

            return false;
        }

        public Task<bool> RemoveUser(int id) => _userRepository.RemoveUser(id);

        public Task<UserRegistered> UpdateUserRegistered(UserRegistered userRegistered, UserInfo oldUser)
        {
            var result = _userRepository.UpdateUserRegistered(userRegistered);
            return Task.FromResult(result);
        }


        public Task<UserInfo> UpdateUserInfo(UserRegistered userRegistered)
        {
            if (IsExistingUserName(userRegistered.Name))
                throw new UserException("Nome de usuário já existente!");

            var oldUser = _userRepository.GetUserInfoById(userRegistered.IdUserInfo);
            UpdatePropertyUserInfo(oldUser, userRegistered);

            _userRepository.UpdateUserInfo(oldUser);

            return Task.FromResult(oldUser);
        }

        public Task<UserToken> Login(UserInfo userInfo)
        {

            userInfo.Password = _userInfoFactoryMethod.EncryptPassword(userInfo.Password);
            var user = _userRepository.GetUser(userInfo);

            if (user == null)
                throw new UserException("Usuário ou senha inválida!");

            user.Password = string.Empty;
            return Task.FromResult(new UserToken()
            {
                Token = GenerateToken(user),
                User = user,
                Expiration = DateTime.UtcNow.AddHours(1)
            });

        }

        public Task<UserRegistered> CreateUserRegistered(UserRegistered userRegistered)
        {
            _userRepository.SaveUserRegistered(userRegistered);
            userRegistered.Password = string.Empty;

            return Task.FromResult(userRegistered);
        }

        public Task<UserInfo> CreateUserInfo(UserRegistered userRegistered)
        {
            var userInfo = _userInfoFactoryMethod.MakeUserInfo(userRegistered);

            if (_userRepository.GetUserByUserName(userInfo.UserName) != null)
                throw new UserException("Usuário já cadastrado na base!");

            var user = _userRepository.SaveUser(userInfo);

            userRegistered.IdUserInfo = user.Id;
            userRegistered.Password = user.Password;

            return Task.FromResult(user);
        }

        private string GenerateToken(UserInfo user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:key"]);
            var tokenDesc = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDesc));
        }

        private void UpdatePropertyUserInfo(UserInfo userInfo, UserRegistered userRegistered) => userInfo.UserName = userRegistered.Name;

        public void ValidateUserName(string name)
        {
            if (_userInfoFactoryMethod.ValidatingUserName(name))
                throw new UserException("Nome de usuário inválido ou pequeno demais!");
        }
    }
}
