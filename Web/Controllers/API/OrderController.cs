using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Controllers
{
    using System.Web.Mvc;
    using Infrastructure;
    using Models;

    public class OrderController : ApiController
    {
        [HttpGet]
        public object GetOrders(int id = 1)
        {
            try
            {
                var data = new OrderService();
               
                return Json (new { Data = data.GetOrdersForCompany(id), Error= "" });
            }
            catch(Exception ex)
            {
                return Json(new { Data = new object(), Error = ex.ToString() });
            }
           

            
        }
    }
}
