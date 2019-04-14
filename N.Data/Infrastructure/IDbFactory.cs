using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N.Data.Infrastructure
{
    public interface IDbFactory
    {
        NShopDbContext Init();
    }
}
