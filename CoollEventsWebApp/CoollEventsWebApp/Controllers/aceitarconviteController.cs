using CoollEventsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoollEventsWebApp.Controllers
{
    public class aceitarconviteController : Controller
    {
        // GET: aceitarconvite
        public ActionResult Index(string evento)
        {

            if(string.IsNullOrWhiteSpace(evento)) return RedirectToAction("index", "Index");

            if (Session["idUsuario"] == null)  return RedirectToAction("Index", "Index");

            try
            {
                Convites.ConfirmarPresenca(Convert.ToInt32(evento));
                return RedirectToAction("index", "ConviteAceito");
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Erro");
            }

            
        }
    }
}