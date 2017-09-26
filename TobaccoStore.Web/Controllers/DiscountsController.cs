using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using System.Web.Mvc;
using TobaccoStore.Web.Models;

namespace TobaccoStore.Web.Controllers
{
    [RoutePrefix("api/discounts")]
    public class DiscountsController : ApiController
    {
        private DiscountRepository _repo = null;
        public DiscountsController()
        {
            _repo = new DiscountRepository();
        }
        // GET: api/Discounts
        [AllowAnonymous]
        [Route("page/{pageNum}")]
        public DataPortion<Discount> Get(int pageNum = 1, int pageSize = 10)
        {
            if (pageNum < 1)
                throw new Exception("Invalid page number");

            var data = _repo.GetMany(pageNum, pageSize);

            return data;
        }

        [AllowAnonymous]
        [Route("{id}")]
        //[ValidateAntiForgeryToken]
        // GET: api/Discounts/5
        public Discount Get(int id)
        {
            return _repo.GetById(id);
        }

        // POST: api/Discounts
        [AllowAnonymous]
        [Route("add")]
        public void Post([FromBody]IEnumerable<Discount> list)
        {
            var collection = list;
            foreach (var tobacco in list)
                _repo.Add(tobacco);
        }

        // PUT: api/Discounts/5
        [AllowAnonymous]
        [Route("update")]
        public void Put([FromBody]Discount item)
        {
            if (!_repo.Exists(item))
                throw new Exception("No such items were found in the store");
            _repo.Update(item);
        }

        // DELETE: api/Discounts/5
        [AcceptVerbs("GET", "POST", "DELETE")]
        public void Delete(int id)
        {
            if (!_repo.Exists(new Discount() { Id = id }))
                throw new Exception("No items with such ID were found in the store");
            var item = _repo.GetById(id);
            _repo.Delete(item);
        }
        public DataPortion<Discount> Search(string q, int page = 1)
        {
            if (q == null || q == "")
                throw new ArgumentException("query string is empty", "q");

            return _repo.FindByProductName(q, page);
        }
    }
}
