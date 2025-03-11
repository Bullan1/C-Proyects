using GestionCineAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionCineAPP.Controllers
{
    public class GestionController : Controller
    {
        GestionCineEntities conexion = new GestionCineEntities();
        // GET: Gestion
        public ActionResult GestionAdministrador()
        {
            var usuarios = conexion.Usuarios.ToList();
            return View();
        }

        public ActionResult GestionUsuarios()
        {
            var usuarios = conexion.Usuarios.ToList();
            return View();
        }

    }
}