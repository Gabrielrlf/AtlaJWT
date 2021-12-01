using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlaJWT.Domain.Entities
{
    public class UserRegistered : Entity
    {
        [ForeignKey("UserInfo")]
        public int IdUserInfo { get; set; }
        public int Age { get; set; }
        public override void IsValid(Entity user)
        {
            throw new NotImplementedException();
        }
    }
}
