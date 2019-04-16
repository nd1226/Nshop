using AutoMapper;
using N.Model.Models;
using N.Service;
using NShop.Web.Infrastructure.Core;
using NShop.Web.Models;
using NShop.Web.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace NShop.Web.Api
{
    [RoutePrefix("api/productcategory")]
    public class ProductCategoryController : ApiControllerBase
    {
        #region Initialize
        private readonly IProductCategoryService _productCategoryService;
        public ProductCategoryController(IErrorService errorService, IProductCategoryService productCategoryService)
            : base(errorService)
        {
            _productCategoryService = productCategoryService;
        }

        #endregion

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpRespone(request, () =>
            {
                int totalRow = 0;
                var model = _productCategoryService.GetAll(keyword);
                totalRow = model.Count();

                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);

                var responeData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(query);

                var paginationSet = new PaginationSet<ProductCategoryViewModel>()
                {
                    Items = responeData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };

                var respone = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return respone;
            });
        }

        [Route("getallparents")]
        [HttpGet]
        public HttpResponseMessage GetAllByParentId(HttpRequestMessage request)
        {
            return CreateHttpRespone(request, () =>
            {
                var model = _productCategoryService.GetAll();

                var responeData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);


                var respone = request.CreateResponse(HttpStatusCode.OK, model);
                return respone;
            });
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpRespone(request, () =>
            {
                var model = _productCategoryService.GetById(id);

                var responeData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(model);

                var respone = request.CreateResponse(HttpStatusCode.OK, model);
                return respone;
            });
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, ProductCategoryViewModel productCategoryVm)
        {
            return CreateHttpRespone(request, () =>
             {
                 HttpResponseMessage respone = null;
                 if (!ModelState.IsValid)
                 {
                     respone = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                 }
                 else
                 {
                     var newProductCategory = new ProductCategory();
                     newProductCategory.UpdateProductCategory(productCategoryVm);
                     newProductCategory.CreatedDate = DateTime.Now;
                     _productCategoryService.Add(newProductCategory);
                     _productCategoryService.Save();

                     var responseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(newProductCategory);
                     respone = request.CreateResponse(HttpStatusCode.Created, responseData);
                 }
                 return respone;
             });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductCategoryViewModel productCategoryVm)
        {
            return CreateHttpRespone(request, () =>
            {
                HttpResponseMessage respone = null;
                if (!ModelState.IsValid)
                {
                    respone = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var productCategoryId = _productCategoryService.GetById(productCategoryVm.ID);
                    productCategoryId.UpdateProductCategory(productCategoryVm);
                    productCategoryId.UpdatedDate = DateTime.Now;

                    _productCategoryService.Update(productCategoryId);
                    _productCategoryService.Save();

                    var responseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(productCategoryId);
                    respone = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return respone;
            });
        }

        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, int id)
        {
            return CreateHttpRespone(request, () =>
            {
                HttpResponseMessage respone = null;
                if (!ModelState.IsValid)
                {
                    respone = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var oldProductCategory = _productCategoryService.Delete(id);
                    _productCategoryService.Save();

                    var responseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(oldProductCategory);
                    respone = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return respone;
            });
        }

        [Route("deletemulti")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage request, string checkedProductCategories)
        {
            return CreateHttpRespone(request, () =>
            {
                HttpResponseMessage respone = null;
                if (!ModelState.IsValid)
                {
                    respone = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {

                    var lstProductCategory = new JavaScriptSerializer().Deserialize<List<int>>(checkedProductCategories);

                    foreach (var item in lstProductCategory)
                    {
                       _productCategoryService.Delete(item);
                    }
                    
                    _productCategoryService.Save();

                    respone = request.CreateResponse(HttpStatusCode.OK, lstProductCategory.Count);
                }
                return respone;
            });
        }
    }
}
