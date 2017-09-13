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
    [RoutePrefix("api/orders")]
    public class OrderController : ApiController
    {
        private OrderRepository _repo = null;
        public OrderController()
        {
            _repo = new OrderRepository();
        }
        
        [Route("page/{pageNum}")]
        [HttpGet]
        public DataPortion<OrderDetails> Get(int pageNum = 1, [FromUri]int pageSize = 10)
        {
            if (pageNum < 1)
                throw new Exception("Invalid page number");

            return _repo.GetMany(pageNum, pageSize, null);
        }

        // implement http response with grant/failure and data inside
        // if token is ok, grant user permission
        // if user is admin, grant permission
        [Route("{id}")]
        [HttpGet]
        public OrderDetails Get(int id)
        {
            return _repo.GetById(id);            
        }

        [AllowAnonymous]
        [Route("proceed")]
        [HttpPost]
        public void Post([FromBody]OrderDetails orderDetails)
        {
            // ALERT: Generate token here!

            //var token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

            // user message: attention! You can use this access token before the order is completed

            foreach (var item in orderDetails.Cart)
                item.Order = orderDetails;
            _repo.Add(orderDetails);

            // call mailservice here!
            var mailService = new MailService();
            mailService.SendEmail("TEST_SUBJECT", "TEST_ORDER", "SHOPNAME", "demaskinas@yandex.ua");
        }

        [Route("update")]
        public void Put([FromBody]OrderDetails newOrderDetails)
        {
            if (!_repo.Exists(newOrderDetails))
                throw new Exception("No such items were found in the store");
            _repo.Update(newOrderDetails);
        }

        [Route("{id}/delete")]
        [AcceptVerbs("DELETE", "POST")]
        public void Delete(int id)
        {
            if (!_repo.Exists(new OrderDetails() { Id = id }))
                throw new Exception("No items with such ID were found in the store");
            var item2del = _repo.GetById(id);
            _repo.Delete(item2del);
        }

        [Route("search/customer/{name}/page/{pageNum}")]
        [HttpGet]
        public DataPortion<OrderDetails> SearchByName(string q, int pageNum = 1, [FromUri]int pageSize = 10)
        {
            if (q == string.Empty || q == null)
                throw new Exception("Name was empty");

            if (pageNum < 1)
                throw new Exception("Invalid page number");

            return _repo.GetByCustomerName(q, pageNum, pageSize);
        }
    }
}
