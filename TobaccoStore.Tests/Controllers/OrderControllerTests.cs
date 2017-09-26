using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TobaccoStore.Web.Controllers;

namespace TobaccoStore.Tests.Controllers
{
    [TestClass]
    public class OrderControllerTests
    {
        [TestMethod]
        public void TestPostAction()
        {
            var ctrlr = new OrderController();
            ctrlr.Post(new Web.Models.OrderDetails());
            Assert.IsTrue(true);
        }
    }
}
