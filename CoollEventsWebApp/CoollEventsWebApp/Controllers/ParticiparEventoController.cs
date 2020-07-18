using CoollEventsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoollEventsWebApp.Controllers
{
    public class ParticiparEventoController : Controller
    {
        // GET: ParticiparEvento
        public ActionResult Index(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Eventos");

            if (Session["idUsuario"] == null) return RedirectToAction("Index", "Entrar");

            try
            {
                Convites.ConfirmarPresenca((int) id);

                return RedirectToAction("Index", "ConviteAceito");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Erro");
            }
        }
    }
}