using AtlaJWT.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlaJWT.Infra.Interfaces
{
    public interface IUserRepository
    {
        Task<IQueryable<UserRegistered>> GetAll();

        UserRegistered SaveUserRegistered(UserRegistered userRegistered);
        
        UserInfo SaveUser(UserInfo userInfo);

        UserInfo GetUser(UserInfo userInfo);
        
        UserRegistered GetUserRegistered(UserInfo userInfo);

        Task<bool> RemoveUser(int id);
        
        UserRegistered UpdateUserRegistered(UserRegistered userRegistered);

        UserInfo UpdateUserInfo(UserInfo userInfo);

        UserInfo GetUserInfoById(int id);

        UserInfo GetUserByUserName(string userName);

    }
}
    