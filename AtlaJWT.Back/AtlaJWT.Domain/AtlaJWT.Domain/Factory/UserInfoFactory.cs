using AtlaJWT.Domain.Creator;
using AtlaJWT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlaJWT.Domain.Factory
{
    public class UserInfoFactory : UserInfoFactoryMethod
    {

        protected override UserInfo CreateUserInfo(UserRegistered userInfo)
        {
            return new UserInfo()
                {
                    Password = userInfo.Password,
                    UserName = userInfo.Name,
                    Role = "User"
                };
        }
        protected override string CryptPasword(string password)
        {
            var encod = Encoding.ASCII.GetBytes(password);
            return Convert.ToBase64String(encod);
        }

        protected override bool ValidateName(string name) => name.Equals("") || name.Length <= 3 ? true : false; 
    }
}
