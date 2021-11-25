using RestWithASP_NET5.Models;
using System.Collections.Generic;

namespace RestWithASP_NET5.Business.Implementations
{
    public interface IPersonBusiness
    {
        Person Create(Person person);
        Person Update(Person person);
        void Delete(long id);
        Person FindById(long id);
        List<Person> FindAll();
    }
}
