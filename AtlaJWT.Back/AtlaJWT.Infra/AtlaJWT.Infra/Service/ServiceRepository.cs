using AtlaJWT.Infra.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlaJWT.Infra.Service
{
    public class ServiceRepository<T> : IDisposable, IServiceRepository<T> where T : class
    {
        protected readonly AppDbContext dbContext = new AppDbContext();
        public void Create(T obj)
        {
            dbContext.Set<T>().Add(obj);

            dbContext.SaveChanges();
        }

        public void Delete(T obj)
        {
            dbContext.Remove(obj);
            dbContext.SaveChanges();
        }

        public void Dispose() => dbContext.Dispose();
        public T FindById(int? id) => dbContext.Find<T>(id);
        public T FindByUserName(string userName, string password)
        {
           return dbContext.Find<T>(userName, password);
        }

        public IQueryable<T> List() => dbContext.Set<T>();

        public void Update(T obj)
        {
            dbContext.Entry(obj).State = EntityState.Modified;

            dbContext.SaveChanges();
        }
    }
}
