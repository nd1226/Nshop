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
    public interface IPostService
    {
        void Add(Post post);
        void Update(Post post);
        void Delete(int id);
        IEnumerable<Post> GetAll();
        Post GetById(int id);
        IEnumerable<Post> GetAllPaging(int page,int pageSize,out int totalRow);
        IEnumerable<Post> GetAllPagingByTag(string tag,int page, int pageSize, out int totalRow);
        IEnumerable<Post> GetAllPagingByCategory(int categoryId,string tag,int page, int pageSize, out int totalRow);
        void SaveChanges();
    }
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;
        public PostService(IPostRepository postRepository,IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
        }
        public void Add(Post post)
        {
            _postRepository.Add(post);
        }

        public void Delete(int id)
        {
            _postRepository.Delete(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll(new string[] { "PostCategory" });
        }

        public IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            //TODO : Select all Post by Tag
            return _postRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public IEnumerable<Post> GetAllPagingByCategory(int categoryId, string tag, int page, int pageSize, out int totalRow)
        {
            return _postRepository.GetMultiPaging(x => x.Status && x.CategoryID == categoryId, out totalRow, page, pageSize,new string[] { "PostCategory" });
        }

        public IEnumerable<Post> GetAllPagingByTag(string tag, int page, int pageSize, out int totalRow)
        {
            //TODO : Select all Post by Tag
            return _postRepository.GetAllByTag(tag, page, pageSize,out totalRow);
        }

        public Post GetById(int id)
        {
            return _postRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
        }
    }
}
