using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
//Referencio la carpeta Models
using GestionCineAPP.Models;

namespace GestionCineAPP.Controllers
{
    public class CinesController : Controller
    {
        //Instancias la conexion de BDD
        GestionCineEntities conexion = new GestionCineEntities();

        //Metodo GET para traer la lista de los cines
        public ActionResult ListaCine()
        {
            //Metodo Para Listar datos
            var cines = conexion.Cines.ToList();
            ViewBag.rolusuario = 1;
            return View(cines);
        }
        //Metodo Get para la pagina crear cine
        public ActionResult CrearCine()
        {
            return View();
        }
        //Metodo Post Crear Cines
        [HttpPost]
        public ActionResult CrearCine([Bind(Include = "IdCine, Nombre, Direccion, Comuna, Ciudad, Activo")] Cines cine)
        {
            if (ModelState.IsValid)
            {
                conexion.Cines.Add(cine);
                conexion.SaveChanges();
                return RedirectToAction("ListaCine");
            }
            return View(cine);
        }
        // Metodo GEt Para Detalles
        public ActionResult DetalleCine(int? id)
        {
            //Si el parametro id es nulo me retorna una pagina de error
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cines cines = conexion.Cines.Find(id);
            if (cines == null)
            {
                return HttpNotFound();
            }
            return View(cines);
        }

        public ActionResult BorrarCine(int? id)
        {
            //Si el parametro id es nulo me retorna una pagina de error
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cines cines = conexion.Cines.Find(id);
            if (cines == null)
            {
                return HttpNotFound();
            }
            return View(cines);
        }
        [HttpPost, ActionName("BorrarCine")]
        public ActionResult BorrarCine(int id)
        {
            Cines cines = conexion.Cines.Find(id);
            conexion.Cines.Remove(cines);
            conexion.SaveChanges();
            return RedirectToAction("ListaCine");
        }

        public ActionResult EditarCine(int? id)
        {
            //Si el parametro id es nulo me retorna una pagina de error
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cines cines = conexion.Cines.Find(id);
            if (cines == null)
            {
                return HttpNotFound();
            }
            return View(cines);
        }
        [HttpPost, ActionName("EditarCine")]
        public ActionResult EditarCine(int id)
        {
            conexion.Cines.Add(cine);
            conexion.SaveChanges();
            return RedirectToAction("ListaCine");
        }
    }
}