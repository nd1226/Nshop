using Microsoft.VisualStudio.TestTools.UnitTesting;
using N.Data.Infrastructure;
using N.Data.Repository;

namespace N.UnitTest
{
    [TestClass]
    public class PostCategoryServiceTest
    {
        IDbFactory dbFactory;
        IPostCategoryRepository objRepository;
        IUnitOfWork unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            objRepository = new PostCategoryRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }
    }
}
