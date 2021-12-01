using AtlaJWT.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtlaJWT.Service.Interfaces
{
    public interface IUserService
    {
        Task<UserToken> Login(UserInfo userInfo);
        
        Task<UserRegistered> CreateUserRegistered(UserRegistered userRegistered);
        
        Task<UserInfo> CreateUserInfo(UserRegistered userRegistered);
        
        Task<IQueryable<UserRegistered>> GetAllUserRegistered();

        Task<bool> RemoveUser(int id);
        
        Task<UserRegistered> UpdateUserRegistered(UserRegistered userRegistered, UserInfo userInfo);
        
        Task<UserInfo> UpdateUserInfo(UserRegistered userRegistered);

        void ValidateUserName(string name);

    }
}
