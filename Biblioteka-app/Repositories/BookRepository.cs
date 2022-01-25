using Biblioteka_app.Interfaces;
using Biblioteka_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka_app.Repositories
{
    public class BookRepository : IBookRepository
    {
        private LibraryManagerContext _context;
        public BookRepository(LibraryManagerContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<BookModel>> GetAllActive()
        {
            var resul = await _context.Books.Include(am=>am.AuthorModel).Include(cm=>cm.CategoryModel).Include(pm=>pm.PublisherModel).ToListAsync();
            return resul;
        }
        public BookModel Get(int bookId)=>_context.Books.SingleOrDefault(x => x.BookId == bookId);
        

        public void Add(BookModel book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Delete(int bookId)
        {
            var result = _context.Books.SingleOrDefault(x => x.BookId == bookId);
            if (result != null)
            {
                _context.Books.Remove(result);
                _context.SaveChanges();
            }
        }

        public void Update(int bookId, BookModel book)
        {
            var result = _context.Books.SingleOrDefault(x => x.BookId == bookId);
            if (result != null)
            {
                result.BookName = book.BookName;
                result.Pages = book.Pages;
                result.Edition = book.Edition;
                result.Cat_id = book.Cat_id;
                result.A_id = book.A_id;
                result.P_id = book.P_id;
                result.Price = book.Price;
                result.ProfilePictureURL = book.ProfilePictureURL;

                _context.SaveChanges();
            }
        }
    }
}
