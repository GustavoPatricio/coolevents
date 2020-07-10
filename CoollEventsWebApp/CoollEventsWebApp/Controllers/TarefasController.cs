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

            Tarefas tarefa = new Tarefas();
            tarefa.Tarefa = Tarefa;
            tarefa.Cadastrar();

            return View();
        }
    }
}