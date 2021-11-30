using AtlaJWT.Domain.Creator;
using AtlaJWT.Domain.Entities;
using AtlaJWT.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlaJWT.Domain.Factory
{
    public class UserInfoFactory : UserInfoFactoryMethod
    {

        protected override UserInfo CreateUserInfo(UserRegistered userRegistered)
        {
            return new UserInfo()
            {
                UserName = userRegistered.Name,
                Password = CryptPasword(userRegistered.Password),
                Role = "User"
            };
        }
        protected override string CryptPasword(string password)
        {
            if (password.Equals(""))
                throw new UserException("Senha em branco.");

            var encod = Encoding.ASCII.GetBytes(password);
            return Convert.ToBase64String(encod);
        }

        protected override bool ValidateName(string name) => name.Equals("") || name.Length <= 3 ? true : false;
    }
}
