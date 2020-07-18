using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoollEventsWebApp.Models;

namespace CoollEventsWebApp.Controllers
{
    public class MeusEventosController : Controller
    {
        // GET: MeusEventos
        public ActionResult Index()
        {
            try
            {
                if (Session["idUsuario"] == null)
                    return RedirectToAction("Index", "Index");

                 

                return View(EventoTemplate.GetMyEvents());
            }

            catch (Exception ex)
            {
                return RedirectToAction("Index", "Erro");
            }
        }
    }
}