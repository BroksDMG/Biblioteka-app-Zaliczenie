using Biblioteka_app.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteka_app.Repositories;
using Biblioteka_app.Interfaces;

namespace Biblioteka_app.Controllers
{
    [Route("api/books")]
    [ApiController]
     public class ApiBookController : ControllerBase
    {
        private IBookRepository books;

        public ApiBookController(IBookRepository books)
        {
            this.books = books;
        }

        //deklaracja zmiennej repozytorium
        [HttpGet]

        public IList<BookModel> GetBooks()
        {
            var allMovies = books.GetAllActive();
            return allMovies;
        }

        [HttpPost]
        public ActionResult<BookModel> AddBook([FromBody] BookModel book)
        {
            books.Add(book);
            return new CreatedResult($"/api/books/{book.BookId}", book);
        }


        [HttpGet("{id}")]
        
        public ActionResult<BookModel> GetBook(int id)
        {
            BookModel book = books.Get(id);
            if (book != null)
            {
                return new OkObjectResult(book);
            }
            else
            {
                return new NotFoundResult();
            }
        }

        [HttpPut("{id}")]
        public ActionResult<BookModel> EditBook(int id, [FromBody] BookModel bookModel)
        {
            //wywołanie metody z repozytorium zmieniającej wartości w obiekcie
            //testujemy, czy obiekt jest różny od null
            if (id < 5 && id > 0)
            {
                books.Update(id, bookModel);
                bookModel.BookId = id;
                return new OkObjectResult(bookModel);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id, BookModel bookModel)
        {
            //usunięcie z repozytorium obiektu o podanym id
            //jeśli nie ma obiektu do usunięcia to zwracamy NotFound
            if (id < 5 && id > 0)
            {
                books.Delete(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
