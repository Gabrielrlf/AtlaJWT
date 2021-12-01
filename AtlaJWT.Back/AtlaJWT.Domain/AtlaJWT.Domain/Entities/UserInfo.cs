using AtlaJWT.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AtlaJWT.Domain.Entities
{
    public class UserInfo : Entity
    {
        public UserInfo()
        {
        }

        public UserInfo(UserInfo userInfo) => IsValid(userInfo);
        public string Role { get; set; }

        public override void IsValid(Entity user)
        {
            if (this.UserName == null)
                throw new UserException("Usuário ou senha inválido!");

            if (this.Password == "" || this.Password == null)
                throw new UserException("Não é possível salvar uma senha nula ou em branco!");
        }
    }
}
