using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private NShopDbContext dbContext;

        public NShopDbContext Init()
        {
            return dbContext ?? (dbContext = new NShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
