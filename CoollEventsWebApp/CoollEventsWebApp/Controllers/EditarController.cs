using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoollEventsWebApp.Models;

namespace CoollEventsWebApp.Controllers
{
    public class EditarController : Controller
    {
        // GET: Editar
        public ActionResult Index()
        {
            if (Session["idUsuario"] == null)
                return RedirectToAction("Index", "Index");

            Usuario usuario = new Usuario().GetUser(Convert.ToInt32(Session["idUsuario"]));



            return View(usuario);
        }

        public ActionResult Update(Usuario usuario) 
        {
            usuario.Foto = ""; // apagar essa linha futuramente

            if(usuario.UpdateUser(usuario, (int)Session["idUsuario"]))
            {
                return RedirectToAction ("Index", "Perfil");
            }
            else
            {
                return RedirectToAction("index", "Erro");
            }
           
        }
    }
}