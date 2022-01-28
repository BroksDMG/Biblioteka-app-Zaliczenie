using Biblioteka_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka_app.Interfaces
{
     public interface IBookRepository
    {
        BookModel Get(int bookId);
        IList<BookModel> GetAllActive();

        void Add(BookModel book);
        void Update(int bookId, BookModel book);
        void Delete(int bookId);
    }
}
