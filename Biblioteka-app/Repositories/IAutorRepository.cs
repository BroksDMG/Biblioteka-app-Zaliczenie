using Biblioteka_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka_app.Repositories
{
    public interface IAutorRepository
    {
        AuthorModel Get(int authorId);
        IQueryable<AuthorModel> GetAllActive { get; }

        void Add(AuthorModel author);
        void Update(int authorId, AuthorModel author);
        void Delete(int authorId);
    }
}
