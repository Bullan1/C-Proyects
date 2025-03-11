using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
//Referencia del Modelo
using GestionCineAPP.Models;

namespace GestionCineAPP.Controllers
{
    public class AccesoController : Controller
    {
        //Instancio la conexion BDD
        GestionCineEntities conexion = new GestionCineEntities();

        //Metodo GET de la Vista o pagina de AccesoUsuario
        public ActionResult AccesoUsuario()
        {
            return View();
        }
        //Metodo POST para enviar los datos del usuario y valida
        [HttpPost]
        public ActionResult AccesoUsuario(Usuarios datos)
        {
            //Valido si el usuario envia los datos
            if(ModelState.IsValid)
            {
                //Verificamos las credenciales del usuario
                var usuario = conexion.Usuarios.FirstOrDefault(u => u.CorreoElectronico == datos.CorreoElectronico && u.Clave == datos.Clave);
                //Si el usuario existe redirecciono a las diferentes pagianas
                if (usuario != null)
                {
                    //Autenticar al usuario
                    FormsAuthentication.SetAuthCookie(usuario.CorreoElectronico, false);
                    //Redirigimos al usuario a la pagina correspondiente dependiendo del ROL
                    if(usuario.IdRol == 1)
                    {
                        //Si el usuario es administrador me llevara a la pagina de "GestionAdministrador"
                        return RedirectToAction("GestionAdministrador", "Gestion");

                    }else if (usuario.IdRol == 2)
                    {
                        //Si el usuario es usuario normal me llevara a la pagina de "GestionUsuario"
                        return RedirectToAction("GestionUsuario", "Gestion");
                    }
                    else
                    {
                        //Si el Rol es desconocido me dara error
                        return RedirectToAction("Error", "Gestion");
                    }
                }
                else
                {
                    ModelState.AddModelError("Error", "Usuario o Contraseña son Incorrectos");
                }
            }
            return View(datos);
        }
        //Metodo para Cerrar Sesion
        public ActionResult CerrarSesion()
        {
            //Cerramos la sesion del usurio
            FormsAuthentication.SignOut();
            //Redirige al usuario a la pagina de inicio
            return RedirectToAction("Index", "Home");
        }

    }
}