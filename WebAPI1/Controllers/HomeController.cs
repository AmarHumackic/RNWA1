using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using WebAPI1.Models;

namespace WebAPI1.Controllers
{
    public class HomeController : ApiController
    {
        private classicmodelsEntities db = new classicmodelsEntities();

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/GetOrdersByID/{userId?}")]
        public IHttpActionResult GetOrdersByID(int userId)
        {
            List<Orders_Result> vm = db.uspGetOrdersByID(userId).ToList();
            return Ok(vm);
        }
    }
}
