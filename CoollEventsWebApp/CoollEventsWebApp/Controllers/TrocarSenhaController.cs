using CoollEventsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoollEventsWebApp.Controllers
{
    public class TrocarSenhaController : Controller
    {
        // GET: TrocarSenha
        public ActionResult Index()
        {
            if(Session["idUsuario"] == null)
            {
                return RedirectToAction("Index", "Index");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(string SenhaAtual, string NovaSenha) {

            int rep = Usuario.TrocarSenha(Convert.ToInt32(Session["idUsuario"]), SenhaAtual, NovaSenha);

            if(rep == 0)
            {
                Response.Write("<script> alert('A senha atual não está correta') </script>");
                return View();
            }
            if(rep == 1)
            {
                Response.Write("<script> alert('Senha trocada com sucesso!') </script>");
                return View();
            }
            if(rep == 0)
            {
                return RedirectToAction("Index", "Erro");
            }

            return View();
        }
    }
}