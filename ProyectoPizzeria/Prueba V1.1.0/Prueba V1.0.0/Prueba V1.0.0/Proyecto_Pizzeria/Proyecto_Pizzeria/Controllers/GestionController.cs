using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Proyecto_Pizzeria.Controllers
{
    public class GestionController : Controller
    {
        // GET: Gestion administrador
        public ActionResult GestionAdministrador()
        {
            // Guardamos en un ViewBag el rol del usuario Administrador para manipular la  barra de navegacion
            ViewBag.rolusuario = 1;
            return View();
        }
        // Get: Gestion usuarios
        public ActionResult GestionCliente()
        {
            // Guardamos en un ViewBag el rol del usuario Administrador para manipular la  barra de navegacion
            ViewBag.rolusuario = 2;
            return View();
        }
        // Cerrar Sesion
        public ActionResult CerrarSesion()
        {
            // Cerramos sesion del usuario y redirecciona al inicio de la APP
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}