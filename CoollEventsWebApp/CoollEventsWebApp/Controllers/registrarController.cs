﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using CoollEventsWebApp.Models;

namespace CoollEventsWebApp.Controllers
{
    public class registrarController : Controller
    {
        // GET: registrar
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuario usuario) {

            bool ok = usuario.Cadastrar();

            if(!ok)
            {
                return RedirectToAction("Index", "Erro");
            }

            return RedirectToAction("Index", "Entrar");
        }

    }
}