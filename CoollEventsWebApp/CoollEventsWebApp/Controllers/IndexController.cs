using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoollEventsWebApp.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index

        [Route("/")]
        [Route("/index")]
        [Route("/home")]
        public ActionResult Index()
        {
            return View();
        }
    }
}