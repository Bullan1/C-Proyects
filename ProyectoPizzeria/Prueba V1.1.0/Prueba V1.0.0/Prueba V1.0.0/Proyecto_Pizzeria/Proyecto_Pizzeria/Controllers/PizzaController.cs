using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
// Referencio la carpeta Models para instanciar la conexion de BDD
using Proyecto_Pizzeria.Controllers;
using Proyecto_Pizzeria.Models;

namespace Proyecto_Pizzeria.Controllers
{
    public class PizzasController : Controller
    {
        // Instancio la conexion BDD
        GestionPizzeriaEntities conexion = new GestionPizzeriaEntities();
        // GET: Pizzas
        public ActionResult ListaPizza()
        {
            // guardo en un viewbag el rol administrador para manipular la navegacion
            ViewBag.rolusuario = 1;
            var pizzas = conexion.Pizzas.ToList();
            return View(pizzas);
        }
        // Metodo get para cargar la pagina 
        public ActionResult CrearPizza()
        {
            // guardo en un viewbag el rol administrador para manipular la navegacion
            ViewBag.rolusuario = 1;
            return View();
        }

        [HttpPost]
        public ActionResult CrearPizza([Bind(Include = "IdPizza, NombreP, Descripcion, Precio, TamañoPizza, Disponible")] Pizzas pizza)
        {
            if (ModelState.IsValid)
            {
                conexion.Pizzas.Add(pizza);
                conexion.SaveChanges();
                return RedirectToAction("ListaPizza");
            }
            return View(pizza);
        }
        public ActionResult EditarPizza(int? id) 
        {
            ViewBag.rolusuario = 1;

            if (id == null) 
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pizzas pizzas = conexion.Pizzas.Find(id);
            if (pizzas == null)
            { 
                return HttpNotFound();
            }
            return View(pizzas);
        }
        [HttpPost]
        public ActionResult EditarPizza([Bind(Include = "IdPizza, NombreP, Descripcion, Precio, TamañoPizza, Disponible")] Pizzas pizzas)
        {
            if (ModelState.IsValid)
            {
                conexion.Entry(pizzas).State = System.Data.Entity.EntityState.Modified;
                conexion.SaveChanges();

                return RedirectToAction("ListaPizza");
            }
            return View(pizzas);
        }
        public ActionResult DetallePizza(int? id) 
        {
            ViewBag.rolusuario = 1;
            if (id == null) 
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);            
            }
            Pizzas pizzas = conexion.Pizzas.Find(id);
            if (pizzas == null)
            {
                return HttpNotFound();
            }
            return View(pizzas);
        }
        public ActionResult BorrarPizza(int? id)
        {
            ViewBag.rolusuario = 1;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pizzas pizzas = conexion.Pizzas.Find(id);
            if (pizzas == null)
            {
                return HttpNotFound();
            }
            return View(pizzas);
        }
        [HttpPost, ActionName("BorrarPizza")]
        public ActionResult BorrarPizza(int id)
        {
            Pizzas pizzas = conexion.Pizzas.Find(id);
            conexion.Pizzas.Remove(pizzas);
            conexion.SaveChanges();
            return RedirectToAction("ListaPizza");
        }
    }
}