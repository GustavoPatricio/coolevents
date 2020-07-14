using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoollEventsWebApp.Controllers
{
    public class EventoController : Controller
    {
        // GET: Evento
        public ActionResult Index(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Eventos");




            return View();
        }
    }
}