using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoollEventsWebApp.Models;

namespace CoollEventsWebApp.Controllers
{
    public class EventosController : Controller
    {
        // GET: Eventos
        public ActionResult Index(string q = "")
        {
            List<EventoTemplate> eventos = new List<EventoTemplate>();

            try
            {
                if (string.IsNullOrWhiteSpace(q))
                {
                    eventos = EventoTemplate.GetAll();
                }
                else
                {
                    eventos = EventoTemplate.GetEventosByName(q);
                }

                return View(eventos);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Erro");
                
            }    
        }
    }
}