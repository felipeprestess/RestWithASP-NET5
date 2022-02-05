using RestWithASP_NET5.Models.Base;
using System.Collections.Generic;

namespace RestWithASP_NET5.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T entity);
        T FindByID(long id);
        List<T> FindAll();
        T Update(T entity);
        void Delete(long id);
        bool Exists(long id);
    }
}
