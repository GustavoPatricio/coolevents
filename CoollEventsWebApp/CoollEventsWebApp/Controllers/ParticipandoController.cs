using CoollEventsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoollEventsWebApp.Controllers
{
    public class ParticipandoController : Controller
    {
        // GET: Participando
        public ActionResult Index()
        {
            try
            {

                if (Session["idUsuario"] == null)
                    return RedirectToAction("Index", "Index");


                return View(EventoTemplate.GetEventsImIn());
            }
            catch (Exception)
            {
                return RedirectToAction("index", "Erro");

            }
        }
    }
}