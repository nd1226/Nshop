using AutoMapper;
using N.Model.Models;
using N.Service;
using NShop.Web.Infrastructure.Core;
using NShop.Web.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NShop.Web.Infrastructure.Extensions;

namespace NShop.Web.Api
{
    [RoutePrefix("api/postcategory")]
    public class PostCategoryController : ApiControllerBase
    {
        IPostCategoryService _postCategoryService;
        public PostCategoryController
            (
            IErrorService errorService,
            IPostCategoryService postCategoryService
            ) 
            : base(errorService)
        {
            _postCategoryService = postCategoryService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpRespone(request, () =>
            {
                var listCategory = _postCategoryService.GetAll();

                var listPostCategoryVM = Mapper.Map<List<PostCategoryViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listPostCategoryVM);

                return response;
            });
        }

        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request,PostCategoryViewModel postCategoryVM)
        {
            return CreateHttpRespone(request, () =>
             {
                 HttpResponseMessage response = null;
                 if (ModelState.IsValid)
                 {
                     response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                 }
                 else
                 {
                     PostCategory newPostCategory = new PostCategory();
                     newPostCategory.UpdatePostCategory(postCategoryVM);
                     
                     _postCategoryService.Add(newPostCategory);
                     _postCategoryService.Save();
                     response = request.CreateResponse(HttpStatusCode.Created);
                 }
                 return response;
             });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, PostCategoryViewModel postCategoryVM)
        {
            return CreateHttpRespone(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var postCategoryId = _postCategoryService.GetById(postCategoryVM.ID);
                    postCategoryId.UpdatePostCategory(postCategoryVM);

                    _postCategoryService.Update(postCategoryId);
                    _postCategoryService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }

        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpRespone(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {

                    _postCategoryService.Delete(id);
                    _postCategoryService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }
    }
}