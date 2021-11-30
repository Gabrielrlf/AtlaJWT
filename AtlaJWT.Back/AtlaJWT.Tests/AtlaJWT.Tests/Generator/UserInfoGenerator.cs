using AtlaJWT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlaJWT.Tests.Generator
{
    class UserInfoGenerator
    {

        /// <summary>
        /// Deve retornar usuário falho
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> GetDataUserInfoFail()
        {
            yield return new object[]
           {
                new UserInfo {Id = 11, UserName = "Adminsdw", Password = "testea123"},
           };
        }
    }
}
