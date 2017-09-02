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
        public TobaccoController()
        {
            _repo = new TobaccoRepository();
        }
        // GET api/values
        [AllowAnonymous]
        [Route("page/{pageNum}")]
        public DataPortion<ProductInfo> Get(int pageNum = 1, int pageSize = 10)
        {
            var data = _repo.GetMany(pageNum, pageSize);

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
        public void Post([FromBody]List<ProductInfo> list)
        {
            var collection = list;
            foreach (var tobacco in list)
                _repo.Add(tobacco);
        }

        // PUT api/values/5
        //[Authorize]
        [AllowAnonymous]
        [Route("update")]
        public void Put([FromBody]ProductInfo item)
        {
            if (!_repo.Exists(item))
                throw new Exception("No such items were found in the store");
            _repo.Update(item);
        }

        // DELETE api/values/5
        [AllowAnonymous]
        [Route("{id}/delete")]
        [AcceptVerbs("GET","POST", "DELETE")]
        public void Delete(int id)
        {
            if (!_repo.Exists(new ProductInfo() { Id = id }))
                throw new Exception("No items with such ID were found in the store");
            _repo.Delete(id);
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
    }
}
