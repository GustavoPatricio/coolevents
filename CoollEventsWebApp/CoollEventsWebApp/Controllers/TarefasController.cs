using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using CoollEventsWebApp.Models;

namespace CoollEventsWebApp.Controllers
{
    public class TarefasController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Tarefa) {

            try
            {
                var evento = (Evento)Session["evento"];
                Tarefas tarefa = new Tarefas();
                tarefa.Tarefa = Tarefa;
                tarefa.Id_evento = evento.Id;
                tarefa.Cadastrar();
                Response.Write("<script> alert('Tarefa cadastrada com sucesso :)') </script>");
                return View();
            }

            catch (Exception ex)
            {
                return RedirectToAction("Index", "Erro");
            }

        }
    }
}