using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace CoollEventsWebApp.Controllers
{
    public class AtualizarAvatarController : Controller
    {
        // GET: AtualizarAvatar
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase imagem) 
        {
             return RedirectToAction("Index", "Perfil");
        }
    }
}