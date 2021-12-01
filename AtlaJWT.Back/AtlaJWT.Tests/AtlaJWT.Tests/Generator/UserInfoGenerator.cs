using AtlaJWT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlaJWT.Tests.Generator
{
    public class UserInfoGenerator
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> GetDataUserInfoPass()
        {
            yield return new object[]
           {
                new UserInfo {Id = 11, UserName = "Carlos", Password = "nata"},
           };
            yield return new object[]
           {
                new UserInfo {Id = 12, UserName = "MArcos", Password = "nata"},
           };
            yield return new object[]
            {
                new UserInfo {Id = 13, UserName = "Camila", Password = "nata"},
            };
        }
    }
}
