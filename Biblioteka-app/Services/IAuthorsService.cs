using Biblioteka_app.Services;
using Biblioteka_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteka_app.Interfaces;

namespace Biblioteka_app.Services
{
    public interface IAuthorsService : IEntityBaseRepository<AuthorModel>
    {
        
    }
}
