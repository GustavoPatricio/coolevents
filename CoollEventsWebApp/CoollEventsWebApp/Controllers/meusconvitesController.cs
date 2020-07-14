using CoollEventsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoollEventsWebApp.Controllers
{
    public class meusconvitesController : Controller
    {
        // GET: meusconvites
        public ActionResult Index()
        {
            try
            {
                if (Session["idUsuario"] == null)
                    return RedirectToAction("Index", "Index");

                return View(Convites.RetornarConvites());
            }

            catch (Exception ex)
            {
                return RedirectToAction("Index", "Erro");
            }
            
        }
    }
}