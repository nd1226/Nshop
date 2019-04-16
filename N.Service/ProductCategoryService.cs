using N.Data.Infrastructure;
using N.Data.Repository;
using N.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N.Service
{
    public interface IProductCategoryService
    {
        ProductCategory Add(ProductCategory ProductCategory);
        void Update(ProductCategory ProductCategory);
        ProductCategory Delete(int id);
        IEnumerable<ProductCategory> GetAll();
        IEnumerable<ProductCategory> GetAll(string keyword);
        IEnumerable<ProductCategory> GetAllByParentId(int parentId);
        ProductCategory GetById(int id);
        void Save();
    }
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _ProductCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProductCategoryService(IProductCategoryRepository ProductCategoryRepository, IUnitOfWork unitOfWork)
        {
            _ProductCategoryRepository = ProductCategoryRepository;
            _unitOfWork = unitOfWork;
        }
        public ProductCategory Add(ProductCategory ProductCategory)
        {
            return _ProductCategoryRepository.Add(ProductCategory);
        }
        public void Update(ProductCategory ProductCategory)
        {
            _ProductCategoryRepository.Update(ProductCategory);
        }

        public ProductCategory Delete(int id)
        {
            return _ProductCategoryRepository.Delete(id);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _ProductCategoryRepository.GetAll();
        }

        public IEnumerable<ProductCategory> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _ProductCategoryRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            return _ProductCategoryRepository.GetAll();
        }

        public IEnumerable<ProductCategory> GetAllByParentId(int parentId)
        {
            return _ProductCategoryRepository.GetMulti(x => x.Status && x.ParentId == parentId);
        }

        public ProductCategory GetById(int id)
        {
            return _ProductCategoryRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
