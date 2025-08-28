using DriveNow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Interfaces.BlogInterfaces
{
    public interface IBlogRepository
    {
        public Task<List<Blog>> GetLast3BlogWithAuthors();

    }
}
