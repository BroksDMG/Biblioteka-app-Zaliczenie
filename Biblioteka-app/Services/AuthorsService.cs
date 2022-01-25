using Biblioteka_app.Models;
using Biblioteka_app.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka_app.Services
{
    public class AuthorsService : EntityBaseRepository<AuthorModel>, IAuthorsService
    {
        public AuthorsService(LibraryManagerContext context) : base(context) { }
    }
  
}
