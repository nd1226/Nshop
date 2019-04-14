using N.Data.Infrastructure;
using N.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N.Data.Repository
{
    public interface IPostTagCategory : IRepository<PostTag>
    {

    }
   
    public class PostTagRepository : RepositoryBase<PostTag>, IPostTagCategory
    {
        public PostTagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
