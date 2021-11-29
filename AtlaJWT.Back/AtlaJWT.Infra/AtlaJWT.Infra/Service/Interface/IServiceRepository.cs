using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlaJWT.Infra.Service.Interface
{
    public interface IServiceRepository<T> 
        where T : class
    {
        IQueryable<T> List();
        void Create(T obj);
        void Update(T obj);
        void Delete(T obj);
        T FindByUserName(string userName, string password);
        T FindById(int? id);

    }
}
