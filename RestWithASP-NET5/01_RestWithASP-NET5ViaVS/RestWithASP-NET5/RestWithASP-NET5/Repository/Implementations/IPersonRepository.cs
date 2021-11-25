using RestWithASP_NET5.Models;
using System.Collections.Generic;

namespace RestWithASP_NET5.Repository.Implementations
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person Update(Person person);
        void Delete(long id);
        Person FindById(long id);
        List<Person> FindAll();
        bool Exists(long id);
    }
}
