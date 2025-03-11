using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
//Defino que la palabra Roles hara referencia a la Clase Roles
using Roles = GestionCineAPP.Models.Roles;
//Referencio la Carpeta Models para traer Entity Framework
using GestionCineAPP.Models;

namespace GestionCineAPP.Controllers
{
    public class RegistroController : Controller
    {
        //Instancio la Conexion de BDD
        GestionCineEntities conexion = new GestionCineEntities();
        //Metodo GET para la vista registro
        public ActionResult Registro()
        {
            //Inserto los roles automaticamente si no existen en la BDD
            if (!conexion.Roles.Any())
            {
                //Creo una lista de los roles predefinidos
                var roles = new List<Roles>
                {
                    new Roles {NombreRol = "Administrador"},
                    new Roles {NombreRol = "Usuario" }
                };
                //Agrego los roles a la BDD y guardo los cambios
                conexion.Roles.AddRange(roles);
                conexion.SaveChanges();
            }
            //Obtener los roles de la BDD
            var rolesList = conexion.Roles.ToList();
            //Convierto la lista de roles en un SelectList (DropDownList)
            ViewBag.Roles = new SelectList(rolesList, "IdRol", "NombreRol");
            return View();
        }
        //Metodo POST para registrar el usuario a traves de un formulario
        [HttpPost]
        //Agregamos los parametros para registrar el usuaro e ingresar el rol
        public ActionResult Registro(Usuarios usuario, int idRol)
        {
            if (ModelState.IsValid)
            {
                //Asignamos el Id del rol al usuario
                usuario.IdRol = idRol;
                //Definimos que el usuario quedara Activo
                usuario.Activo = true;
                //Guardamos todos los datos del usuario en la BDD
                conexion.Usuarios.Add(usuario);
                conexion.SaveChanges();
                //Autentico el usuario
                FormsAuthentication.SetAuthCookie(usuario.CorreoElectronico, false);
                //Redireccionar a la pagina de Acceso
                return RedirectToAction("AccesoUsuario", "Acceso");
            }
            return View(usuario);
        }

    }
}



       