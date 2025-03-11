using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
//Referencia de la carpeta Models
using GestionCineAPP.Models;

namespace GestionCineAPP.Controllers
{
    public class GestionController : Controller
    {
        //Instancio la conexion de BDD 
        GestionCineEntities conexion = new GestionCineEntities();
        //Metodo GET para la vista o pagina del Administrador
        public ActionResult GestionAdministrador()
        {
            ViewBag.rolusuario = 1;
            var usuarios = conexion.Usuarios.ToList();
            return View(usuarios);
        }
        //Metodo GET para la vista o pagina del Usuario Normal
        public ActionResult GestionUsuario()
        {
            ViewBag.rolusuario = 2;
            var usuarios = conexion.Usuarios.ToList();
            return View(usuarios);
        }

        public ActionResult CerrarSesion()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}