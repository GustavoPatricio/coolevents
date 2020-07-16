using CoollEventsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoollEventsWebApp.Controllers
{
    public class EnqueteController : Controller
    {
        // GET: Enquete

        public ActionResult Index(int? e)
        {
            try
            {
                if (e == null) return RedirectToAction("index", "Index");

                if (Session["idUsuario"] == null)
                    return RedirectToAction("Index", "Index");

                Enquete enquete = new Enquete();
                enquete.GetEnqueteById((int)e);

                return View(enquete);
            }
            catch (Exception)
            {
                return RedirectToAction("index", "Erro");

            }

        }

        [HttpPost]
        public ActionResult Index(Enquete enquete, int idEnquete, int Pontuacao) {
            try
            {
                enquete.Resposta.Pontuacao = Pontuacao;
                enquete.Resposta.Id_Enquete = idEnquete;

                enquete.Resposta.Submit();

                return RedirectToAction("Index", "Enquetes");
            }
            catch (Exception ex)
            {
                return RedirectToAction("index", "Erro");

            }
           
        }
    }
}