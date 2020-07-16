using CoollEventsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoollEventsWebApp.Controllers
{
    public class EnquetesController : Controller
    {
        // GET: Enquetes
        public ActionResult Index()
        {
            try
            {
                if (Session["idUsuario"] == null)
                    return RedirectToAction("Index", "Index");

                return View(Enquetes.GetAll());
            }

            catch (Exception ex)
            {
                return RedirectToAction("Index", "Erro");
            }
        }
    }
}