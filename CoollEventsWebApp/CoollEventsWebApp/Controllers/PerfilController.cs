using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoollEventsWebApp.Models;

namespace CoollEventsWebApp.Controllers
{
    public class PerfilController : Controller
    {
        // GET: Perfil
        public ActionResult Index()
        {

            if (Session["idUsuario"] == null)
                return RedirectToAction("Index", "Index");

            Usuario usuario = new Usuario().GetUser(Convert.ToInt32(Session["idUsuario"]));

            return View();
        }
    }
}