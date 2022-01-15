using Biblioteka_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka_app.Repositories
{
    public class AuthorRepository : IAutorRepository
    {
        private  AuthorManagerContext _context;
        public AuthorRepository(AuthorManagerContext context)
        {
            _context = context;
        }
        public IQueryable<AuthorModel> GetAllActive => _context.Authors;

        public AuthorModel Get(int authorId) => _context.Authors.SingleOrDefault(x => x.AuthorId == authorId);
        public void Add(AuthorModel author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }
       



        public void Update(int authorId, AuthorModel author)
        {
            var result = _context.Authors.SingleOrDefault(x => x.AuthorId == authorId);
            if (result != null)
            {
                result.Name = author.Name;
                result.Surname = author.Surname;
                result.Address = author.Surname;
                result.phone = author.phone;
                _context.SaveChanges();
            }
        }

        public void Delete(int authorId)
        {
            var result = _context.Authors.SingleOrDefault(x => x.AuthorId == authorId);
            if (result != null)
            {
                _context.Authors.Remove(result);
                _context.SaveChanges();
            }
        }
    }





    
}
