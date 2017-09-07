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
    [RoutePrefix("api/orders")]
    public class OrderController : ApiController
    {
        private OrderRepository _repo = null;
        public OrderController()
        {
            _repo = new OrderRepository();
        }
        [AllowAnonymous]
        [Route("page/{pageNum}")]
        // GET: api/Order
        public DataPortion<OrderDetails> Get(int pageNum = 1, [FromUri]int pageSize = 10)
        {
            if (pageNum < 1)
                throw new Exception("Invalid page number");

            return _repo.GetMany(pageNum, pageSize, null);
        }

        [AllowAnonymous]
        [Route("{id}")]
        // GET: api/Order/5
        public OrderDetails Get(int id)
        {
            return _repo.GetById(id);            
        }

        // POST: api/Order
        [AllowAnonymous]
        [Route("proceed")]
        //public void Post([FromBody]OrderDetails orderDetails, [FromBody]IEnumerable<OrderItem> cart)
        //{
        //    var test = orderDetails;
        //}
        public void Post([FromBody]OrderDetails orderDetails)
        {
            foreach (var item in orderDetails.Cart)
                item.Order = orderDetails;
            _repo.Add(orderDetails);

            // call mailservice here!
        }

        [AllowAnonymous] 
        [Route("update")]
        // PUT: api/Order/5
        public void Put([FromBody]OrderDetails newOrderDetails)
        {
            if (!_repo.Exists(newOrderDetails))
                throw new Exception("No such items were found in the store");
            _repo.Update(newOrderDetails);
        }

        [AllowAnonymous]
        [Route("{id}/delete")]
        // DELETE: api/Order/5
        public void Delete(int id)
        {
            if (!_repo.Exists(new OrderDetails() { Id = id }))
                throw new Exception("No items with such ID were found in the store");
            var item2del = _repo.GetById(id);
            _repo.Delete(item2del);
        }
        [AllowAnonymous]
        [Route("search/customer/{name}/page/{pageNum}")]
        public DataPortion<OrderDetails> SearchByName(string q, int pageNum = 1, [FromUri]int pageSize = 10)
        {
            if (q == string.Empty || q == null)
                throw new Exception("Name was empty");

            if (pageNum < 1)
                throw new Exception("Invalid page number");

            return _repo.GetByCustomerName(q, pageNum, pageSize);
            //return _repo.Ge
        }
    }
}
