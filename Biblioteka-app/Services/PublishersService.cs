using Biblioteka_app.Models;
using Biblioteka_app.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Biblioteka_app.Services
{
    public class PublishersService : EntityBaseRepository<PublisherModel>, IPublishersService
    {
        public PublishersService(LibraryManagerContext context) : base(context) { }
    }
}
