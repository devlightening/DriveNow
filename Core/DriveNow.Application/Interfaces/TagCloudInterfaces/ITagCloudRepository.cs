using DriveNow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Interfaces.TagCloudInterfaces
{
    public interface ITagCloudRepository
    {
        Task<List<TagCloud>> GetAllTagCloudsAsync(); 
        Task<List<TagCloud>> GetTagCloudsByBlogIdAsync(Guid blogId);
    }
}
