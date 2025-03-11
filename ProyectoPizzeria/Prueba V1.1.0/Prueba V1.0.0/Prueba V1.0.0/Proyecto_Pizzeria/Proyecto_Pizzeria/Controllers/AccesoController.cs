using Proyecto_Pizzeria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Proyecto_Pizzeria.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        GestionPizzeriaEntities conexion = new GestionPizzeriaEntities();
        public ActionResult AccesoUsuario()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AccesoUsuario(Usuarios datos)
        {
            var usuario = conexion.Usuarios.FirstOrDefault(u => u.CorreoElectronico == datos.CorreoElectronico && u.Clave == datos.Clave);
            if (usuario != null)
            {
                if(usuario.IdRol == 1)
                {
                    return RedirectToAction("GestionAdministrador", "Gestion");
                } else if (usuario.IdRol == 2)
                {
                    return RedirectToAction("GestionCliente", "Gestion");
                } else
                {
                    return RedirectToAction("Error", "Gestion");
                }
            }
            return View();
        }

    }  
}