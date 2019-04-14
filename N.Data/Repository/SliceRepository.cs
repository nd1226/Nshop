using N.Data.Infrastructure;
using N.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N.Data.Repository
{
    public interface ISliceRepository : IRepository<Slice>
    {

    }
    public class SliceRepository : RepositoryBase<Slice>, ISliceRepository
    {
        public SliceRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
    
}
