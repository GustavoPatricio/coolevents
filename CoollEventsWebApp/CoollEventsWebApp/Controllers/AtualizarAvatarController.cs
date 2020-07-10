using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using CoollEventsWebApp.Models;

namespace CoollEventsWebApp.Controllers
{
    public class AtualizarAvatarController : Controller
    {
        // GET: AtualizarAvatar
        public ActionResult Index()
        {
            if (Session["idUsuario"] == null)
                return RedirectToAction("Index", "Index");

            Usuario usuario = new Usuario().GetUser(Convert.ToInt32(Session["idUsuario"]));

            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase userImagem) 
        {
            string fileId = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(userImagem.FileName);

            bool ok = Usuario.SaveUserImageById(Convert.ToInt32(Session["idUsuario"]), fileId);

            if (!ok)
            {
                return RedirectToAction("Index", "Erro");
            }

            try
            {
                var path = (@"C:\ImageProvider\public\userImagens\" +  fileId);
                userImagem.SaveAs(path);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Erro");
            }
           

            Response.Write("<script> alert('Imagem atualizada com sucesso!') </script>");
            return RedirectToAction("Index", "Perfil");
   
        }
    }
}