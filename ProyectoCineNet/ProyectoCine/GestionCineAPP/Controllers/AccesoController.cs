using GestionCineAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GestionCineAPP.Controllers
{
    public class AccesoController : Controller
    {
        //Conexion a bdd
        GestionCineEntities conexion = new GestionCineEntities();
        // GET: Acceso Usuario
        public ActionResult AccesoUsuario()
        {
            return View();
        }
        //metodo post para validar el usuario
        [HttpPost]
        public ActionResult AccesoUsuario(Usuarios datos)
        {
            //Valido datos dependiendo de la clase
            if (ModelState.IsValid)
            {
                //Verifico credenciales
                var usuario = conexion.Usuarios.FirstOrDefault(u => u.CorreoElectronico == datos.CorreoElectronico && u.Clave == datos.Clave);
                if (usuario != null)
                {
                    FormsAuthentication.SetAuthCookie(usuario.CorreoElectronico, false);
                    if (usuario.IdRol == 1)
                    {
                        return RedirectToAction("GestionAdministrador", "Gestion");
                    }
                    else if (usuario.IdRol == 2)
                    {
                        return RedirectToAction("GestionUsuarios", "Gestion");
                    }
                    else
                    {
                        return RedirectToAction("Error", "Gestion");
                    }
                }
            }
            else
            {
                //Si las credenciales son invalidas me marca un error
                ModelState.AddModelError("Error", "Usuario o contraseñas incorrectos");
            }
            return View(datos);
        }
        //metodo GET: Vista Cierre de Sesion
        
        public ActionResult CierreSesion()
        {
            //Cierra la Sesion
            FormsAuthentication.SignOut();
            //Redirige a Home
            return RedirectToAction("Index", "Home");
        }

    }

}