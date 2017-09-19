using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TobaccoStore.Web.Models;

namespace TobaccoStore.Web.Controllers
{
    [Authorize]
    [RoutePrefix("api/tobacco")]
    public class TobaccoController : ApiController
    {
        private TobaccoRepository _repo = null;
        private ManufacturerRepository _manufacturerRepo = null;
        public TobaccoController()
        {
            _repo = new TobaccoRepository();
            _manufacturerRepo = new ManufacturerRepository();
        }
        // GET api/values
        [AllowAnonymous]
        [Route("page/{pageNum}")]
        public DataPortion<ProductInfo> Get([FromUri]int manufacturerId, int pageNum = 1, [FromUri]int pageSize = 8)
        {
            if (pageNum< 1)
                throw new Exception("Invalid page number");

            var data = _repo.FilterByManufacturer(manufacturerId, pageNum, pageSize);

            return data;
        }

        // GET api/values/5
        [AllowAnonymous]
        [Route("{id}")]
        public ProductInfo Get(int id)
        {
            return _repo.GetById(id);
        }

        // POST api/values
        [AllowAnonymous]
        [Route("add")]
        public void Post([FromBody]object rawItem)
        {
            var json = rawItem.ToString();
            var settings = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };

            var productInfo = JsonConvert.DeserializeObject<ProductInfo>(json, settings);
            if (_repo.Exists(productInfo.Id))
                throw new Exception("There is already item with such id in the store");

            var base64photo = JsonConvert.DeserializeAnonymousType(json, new { Photo = "" }, settings);
            //if ()
            //productInfo.Photo = (base64photo.Photo == null) ? new byte[1] : Convert.FromBase64String(base64photo.Photo);
            productInfo.Photo = Convert.FromBase64String((base64photo.Photo == null) ? "" : base64photo.Photo);

            foreach (var item in productInfo.PackageInfoes)
                item.ProductInfo = productInfo;

            _repo.Add(productInfo);
        }

        // PUT api/values/5
        //[Authorize]
        [AllowAnonymous]
        [Route("update")]
        public void Put([FromBody]object rawItem)
        {
            var json = rawItem.ToString();
            var settings = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };

            var productInfo = JsonConvert.DeserializeObject<ProductInfo>(json, settings);
            if (!_repo.Exists(productInfo.Id))
                throw new Exception("No such items were found in the store");

            var base64photo = JsonConvert.DeserializeAnonymousType(json, new { Photo = "" }, settings);
            productInfo.Photo = Convert.FromBase64String((base64photo.Photo == null) ? "" : base64photo.Photo);
            //productInfo.Photo = Convert.FromBase64String(base64photo.Photo);

            foreach (var item in productInfo.PackageInfoes)
                item.ProductInfo = productInfo;

            _repo.Update(productInfo);
        }

        // DELETE api/values/5
        [AllowAnonymous]
        [Route("{id}/delete")]
        [AcceptVerbs("GET","POST", "DELETE")]
        public void Delete(int id)
        {
            if (!_repo.Exists(new ProductInfo() { Id = id }))
                throw new Exception("No items with such ID were found in the store");
            var item = _repo.GetById(id);
            _repo.Delete(item);
        }

        [AllowAnonymous]
        [Route("search/{q}/page/{page}")]
        [HttpGet]
        public DataPortion<ProductInfo> Search(string q, int page = 1)
        {
            if (q == null || q == "")
                throw new ArgumentException("query string is empty", "q");

            return _repo.FindByName(q, page);
        }

        #region Manufacturer access functions

        [AllowAnonymous]
        [HttpGet]
        [Route("manufacturers/{id}")]
        public ProductManufacturer Manufacturer(int id)
        {
            if (id < 1)
                throw new Exception("Invalid ManufacturerId");

            return _manufacturerRepo.GetById(id);
        }

        #endregion
    }
}
