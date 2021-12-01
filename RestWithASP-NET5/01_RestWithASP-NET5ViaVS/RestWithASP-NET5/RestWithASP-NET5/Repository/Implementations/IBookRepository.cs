using RestWithASP_NET5.Models;
using System.Collections.Generic;

namespace RestWithASP_NET5.Repository.Implementations
{
    public interface IBookRepository
    {
        Book Create(Book book);
        Book Update(Book book);
        void Delete(long id);
        Book FindById(long id);
        List<Book> FindAll();
        bool Exists(long id);
    }
}
