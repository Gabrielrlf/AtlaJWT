using AtlaJWT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlaJWT.Domain.Creator
{
    public abstract class UserInfoFactoryMethod
    {
        public UserInfo MakeUserInfo(UserRegistered userRegistered)
        {
            return CreateUserInfo(userRegistered);
        }

        public string EncryptPassword(string password)
        {
            return CryptPasword(password);
        }

        public bool ValidatingUserName(string name) => ValidateName(name);

        protected abstract UserInfo CreateUserInfo(UserRegistered userInfo);
        protected abstract bool ValidateName(string name);
        protected abstract string CryptPasword(string password);
    }
}
