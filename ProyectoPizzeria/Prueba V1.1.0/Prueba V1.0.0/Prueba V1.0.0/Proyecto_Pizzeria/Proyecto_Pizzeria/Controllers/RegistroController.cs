using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Roles = Proyecto_Pizzeria.Models.Roles;
using Proyecto_Pizzeria;
using Proyecto_Pizzeria.Models;
using System.Web.Security;

namespace Proyecto_Pizzeria.Controllers
{
    public class RegistroController : Controller
    {
        GestionPizzeriaEntities conexion = new GestionPizzeriaEntities(); 

        // GET: Registro
        public ActionResult Registro()
        {
            if (!conexion.Roles.Any())
            {
                var roles = new List<Roles>
                {
                    new Roles {NombreRol = "Administrador"},
                    new Roles {NombreRol = "Cliente"}
                };

                conexion.Roles.AddRange(roles);
                conexion.SaveChanges();
            }
            var rolesList = conexion.Roles.ToList();
            ViewBag.Roles= new SelectList(rolesList,"IdRol","NombreRol");
            return View();
        }
        [HttpPost]
        public ActionResult Registro(Usuarios usuario, int idRol)
        {
            if (ModelState.IsValid)
            {
                usuario.IdRol = idRol;
                usuario.Activo = true;
                conexion.Usuarios.Add(usuario);
                conexion.SaveChanges();

                FormsAuthentication.SetAuthCookie(usuario.CorreoElectronico, false);
                return RedirectToAction("AccesoUsuario", "Acceso");
            }
            return View(usuario);
        }
    }
}