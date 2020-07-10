using CoollEventsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoollEventsWebApp.Controllers
{
    public class CriareventoController : Controller
    {
        // GET: Criarevento
        public ActionResult Index() 
        {
            if (Session["idUsuario"] == null)
                return RedirectToAction("Index", "Index");

            return View(Evento.GetTipos());
        }

        [HttpPost]
        public ActionResult Index(Evento evento) 
        {
            try
            {

                evento.Cadastrar();

                if (evento.Publico)
                {
                    return RedirectToAction("Index", "Eventos");
                }

                else
                {
                    Session["evento"] = evento;
                    return RedirectToAction("Index", "Convidados");
                }
            }

            catch (Exception ex)
            { 

                return RedirectToAction("Index", "Erro");
            }
            
        }
    }
}