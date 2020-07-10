using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoollEventsWebApp.Models;

namespace CoollEventsWebApp.Controllers
{
    public class ConvidadosController : Controller
    {
        // GET: Convidados
        public ActionResult Index()
        {
            //if (Session["idUsuario"] == null)
            //    return RedirectToAction("Index", "Index");

            //if (Session["evento"] == null)
            //    return RedirectToAction("Index", "Index");

            return View();
        }

        [HttpPost]
        public ActionResult Index(string convidado) {
            try
            {

                var evento = (Evento)Session["evento"];

                Convidado.Cadastrar(convidado, evento.Id);

                return View();

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Erro");
            }
        }
    }
}