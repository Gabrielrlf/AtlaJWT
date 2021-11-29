using AtlaJWT.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtlaJWT.Domain.Entities
{
    public class UserInfo : Entity
    {
        public UserInfo()
        {
        //    IsValid(this);
        }

        public UserInfo(UserInfo userInfo) => IsValid(userInfo);
        public string UserName { get; set ; }
        public string Role { get; set; }
        public string Password { get; set; }

        public override void IsValid(Entity user)
        {
            if (this.UserName == null)
                throw new UserException("Usuário ou senha inválido!");
        }
    }
}
