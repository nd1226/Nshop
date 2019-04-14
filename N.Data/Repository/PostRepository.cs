using N.Data.Infrastructure;
using N.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N.Data.Repository
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow);
    }
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow)
        {
            var queries = from p in DbContext.Posts
                          join pt in DbContext.PostTags
                          on p.ID equals pt.PostID
                          where pt.TagID == tag && p.Status
                          orderby p.CreatedDate descending
                          select p;
            totalRow = queries.Count();

            queries = queries.Skip((pageIndex - 1) * pageSize);

            return queries;
        }
    }
}
