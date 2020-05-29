using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoollEventsWebApp.Models;

namespace CoollEventsWebApp.Controllers
{
    public class EntrarController : Controller
    {
        // GET: Entrar

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login login)
        {
            if(!login.DoIt())
            {
                Response.Write("<script> alert('Usuário e/ou senha incorretos') </script>");
                return View();
            }
            else
            {
                Response.Write("<script> alert('Sucesso!') </script>");
                return View();
            }
        }
    }
}