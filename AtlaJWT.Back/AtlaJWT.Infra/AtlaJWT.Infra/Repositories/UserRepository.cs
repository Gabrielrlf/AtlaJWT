using AtlaJWT.Domain.Entities;
using AtlaJWT.Infra.Interfaces;
using AtlaJWT.Infra.Service;
using AtlaJWT.Infra.Service.Interface;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlaJWT.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<IQueryable<UserRegistered>> GetAll()
        {
            try
            {
                ServiceRepository<UserRegistered> req = new ServiceRepository<UserRegistered>();

                var result = req.List();
                return Task.FromResult(result);
            }
            catch (SqliteException ex)
            {
                throw ex;
            }
        }

        public UserInfo GetUser(UserInfo userInfo)
        {
            try
            {
                using (ServiceRepository<UserInfo> req = new ServiceRepository<UserInfo>())
                {
                    return req.List().Where(x => x.UserName == userInfo.UserName && x.Password == userInfo.Password).FirstOrDefault();
                }
            }
            catch (SqliteException ex)
            {
                throw ex;
            }
        }

        public UserInfo GetUserByUserName(string userName)
        {
            try
            {
                using (ServiceRepository<UserInfo> req = new ServiceRepository<UserInfo>())
                {
                    return req.List().Where(x => x.UserName == userName).FirstOrDefault();
                }
            }
            catch (SqliteException ex)
            {
                throw ex;
            }
        }

        public UserInfo GetUserInfoById(int id)
        {
            try
            {
                using (ServiceRepository<UserInfo> req = new ServiceRepository<UserInfo>())
                {
                    return req.FindById(id);
                }
            }
            catch (SqliteException ex)
            {
                throw ex;
            }
        }

        public UserRegistered GetUserRegistered(UserInfo userInfo)
        {
            try
            {
                using (ServiceRepository<UserRegistered> req = new ServiceRepository<UserRegistered>())
                {
                    return req.List().Where(x => x.Name == userInfo.UserName && x.Password == userInfo.Password).FirstOrDefault();
                }
            }
            catch (SqliteException ex)
            {
                throw ex;
            }
        }

        public Task<bool> RemoveUser(int id)
        {
            try
            {
                dynamic user;
                using (ServiceRepository<UserRegistered> req = new ServiceRepository<UserRegistered>())
                {
                    user = req.FindById(id);
                    req.Delete(user);
                }

                using (ServiceRepository<UserInfo> req = new ServiceRepository<UserInfo>())
                {
                    user = req.FindById(user.IdUserInfo);
                    req.Delete(user);
                }
                return Task.FromResult(true);
            }
            catch (SqliteException ex)
            {
                throw ex;
            }
        }

        public UserInfo SaveUser(UserInfo userInfo)
        {
            try
            {
                using (ServiceRepository<UserInfo> req = new ServiceRepository<UserInfo>())
                {
                    req.Create(userInfo);
                    return userInfo;
                }
            }
            catch (SqliteException ex)
            {
                throw ex;
            }
        }

        public UserRegistered SaveUserRegistered(UserRegistered userRegistered)
        {

            try
            {
                using (ServiceRepository<UserRegistered> req = new ServiceRepository<UserRegistered>())
                {
                    req.Create(userRegistered);
                    return userRegistered;
                }
            }
            catch (SqliteException ex)
            {
                throw ex;
            }
        }

        public UserInfo UpdateUserInfo(UserInfo userInfo)
        {
            try
            {
                using (ServiceRepository<UserInfo> req = new ServiceRepository<UserInfo>())
                {
                    req.Update(userInfo);
                    return userInfo;
                }
            }
            catch (SqliteException ex)
            {
                throw ex;
            }
        }

        public UserRegistered UpdateUserRegistered(UserRegistered userRegistered)
        {
            try
            {
                using (ServiceRepository<UserRegistered> req = new ServiceRepository<UserRegistered>())
                {
                    req.Update(userRegistered);
                    return userRegistered;
                }
            }
            catch (SqliteException ex)
            {
                throw ex;
            }
        }
    }
}
