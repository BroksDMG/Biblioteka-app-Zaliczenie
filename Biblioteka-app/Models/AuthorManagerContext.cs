using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka_app.Models
{
    public class AuthorManagerContext:DbContext
    {
        public AuthorManagerContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<AuthorModel> Authors { get; set; }

        
    }
}
