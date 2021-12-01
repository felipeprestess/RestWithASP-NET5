using RestWithASP_NET5.Models;
using System.Collections.Generic;

namespace RestWithASP_NET5.Business.Implementations
{
    public interface IBookBusiness
    {
        Book Create(Book book);
        Book Update(Book book);
        void Delete(long id);
        Book FindById(long id);
        List<Book> FindAll();
    }
}
