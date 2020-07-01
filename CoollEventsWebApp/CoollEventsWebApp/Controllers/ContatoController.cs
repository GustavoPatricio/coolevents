using CoollEventsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoollEventsWebApp.Controllers
{
    public class ContatoController : Controller
    {
        // GET: Contato
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Nome, string Email, string Assunto, string Mensagem) {
            try
            {
                CoolEventsMailer mailer = new CoolEventsMailer();

                mailer.AdicionarEmail("coollevents@gmail.com");
                mailer.Assunto = Assunto;
                mailer.SetBody(Nome, Email, Mensagem);
                mailer.Enviar();


                return RedirectToAction("Index", "Index");
               
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Erro");
            }
        }
    }
}