using AtlaJWT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlaJWT.Tests.Generator
{
    public class UserRegisteredGenerator
    {
        /// <summary>
        /// Retorna objetos do UserRegistered
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> GetDataUserRegisteredPass()
        {
            yield return new object[]
           {
                new UserRegistered {Id = 11, Age = 10, IdUserInfo = 11, UserName = "Name", Password = "321"},
           };

            yield return new object[]
           {
                new UserRegistered {Id = 12, Age = 10, IdUserInfo = 12, UserName = "Carlos", Password = "3214"},
           };

            yield return new object[]
           {
                new UserRegistered {Id = 13, Age = 11, IdUserInfo = 13, UserName = "Gabriel", Password = "3211"},
           };

            yield return new object[]
           {
                new UserRegistered {Id = 14, Age = 12, IdUserInfo = 14,  UserName = "Lacerda", Password = "3212"},
           };
        }

        /// <summary>
        /// Deve retornar usuário falho
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> GetDataUserRegisteredFailed()
        {
            yield return new object[]
           {
                new UserRegistered {Id = 11, IdUserInfo = 11, Age = 10, UserName = "", Password = ""},
           };
        }
    }
}
