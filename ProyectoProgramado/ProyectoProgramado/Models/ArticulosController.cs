using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoProgramado;

namespace ProyectoProgramado.Models
{
    public class ArticulosController : Controller
    {
        private ObjetosPerdidosEntities db = new ObjetosPerdidosEntities();

        // GET: Articulos
        public ActionResult Index()
        {
            var articulo = db.Articulo.Include(a => a.SubCategoria1).Include(a => a.Usuario);
            return View(articulo.ToList());
        }

        // GET: Articulos/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulo articulo = db.Articulo.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo);
        }

        // GET: Articulos/Create
        public ActionResult Create()
        {
            ViewBag.SubCategoria = new SelectList(db.SubCategoria, "IdSubCategoria", "NombreSubCategoria");
            ViewBag.IngresadoPor = new SelectList(db.Usuario, "IdUser", "Nombre");
            return View();
        }

        // POST: Articulos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdArticulo,SubCategoria,Descripcion,FechaRecibido,Estado,FechaEntrega,NombreDueno,IngresadoPor")] Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                db.Articulo.Add(articulo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubCategoria = new SelectList(db.SubCategoria, "IdSubCategoria", "NombreSubCategoria", articulo.SubCategoria);
            ViewBag.IngresadoPor = new SelectList(db.Usuario, "IdUser", "Nombre", articulo.IngresadoPor);
            return View(articulo);
        }

        // GET: Articulos/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulo articulo = db.Articulo.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubCategoria = new SelectList(db.SubCategoria, "IdSubCategoria", "NombreSubCategoria", articulo.SubCategoria);
            ViewBag.IngresadoPor = new SelectList(db.Usuario, "IdUser", "Nombre", articulo.IngresadoPor);
            return View(articulo);
        }

        // POST: Articulos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdArticulo,SubCategoria,Descripcion,FechaRecibido,Estado,FechaEntrega,NombreDueno,IngresadoPor")] Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articulo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubCategoria = new SelectList(db.SubCategoria, "IdSubCategoria", "NombreSubCategoria", articulo.SubCategoria);
            ViewBag.IngresadoPor = new SelectList(db.Usuario, "IdUser", "Nombre", articulo.IngresadoPor);
            return View(articulo);
        }

        // GET: Articulos/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulo articulo = db.Articulo.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo);
        }

        // POST: Articulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            Articulo articulo = db.Articulo.Find(id);
            db.Articulo.Remove(articulo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
