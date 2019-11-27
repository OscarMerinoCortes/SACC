using SACC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SACC.Controllers
{
    public class PresentacionController : Controller
    {
        // GET: Presentacion
        public ActionResult PresentacionesLista()
        {
            try
            {
                using (var db = new JEENContext())
                {
                    //List<Alumnos> lista = db.Alumnos.Where(a => a.Edad > 18).ToList();
                    //return View(lista);
                    return View(db.PRESENTACION.ToList());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PRESENTACION a)
        {
            if (!ModelState.IsValid)//ModelState es para validar que los datos sean los correctos.

                return View();

            try
            {
                using (var db = new JEENContext())
                {
                    //a.FechaRegistro = DateTime.Now;
                    db.PRESENTACION.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("PresentacionesLista");
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Error al registrar la presentacion - " + ex.Message);
                return View();
            }

        }

        public ActionResult Editar(int id)
        {
            try
            {
                using (var db = new JEENContext())
                {
                    //Alumnos al = db.Alumnos.Where(a => a.Id == id).FirstOrDefault();//Usar en todos los casos en claves compuestas
                    PRESENTACION pre = db.PRESENTACION.Find(id);//Cuando se tiene un id unico.
                    return View(pre);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(PRESENTACION a)
        {
            if (!ModelState.IsValid)//ModelState es para validar que los datos sean los correctos.

                return View();
            try
            {
                using (var db = new JEENContext())
                {
                    PRESENTACION pre = db.PRESENTACION.Find(a.IdPresentacion);
                    pre.Descripcion = a.Descripcion;
                    pre.Fecha = a.Fecha;
                    pre.IdEstatus = a.IdEstatus;
                    db.SaveChanges();
                    return RedirectToAction("PresentacionesLista");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult Detalles(int id)
        {

            using (var db = new JEENContext())
            {

                PRESENTACION pre = db.PRESENTACION.Find(id);
                return View(pre);
            }

        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new JEENContext())
                {
                    PRESENTACION pre = db.PRESENTACION.Find(id);
                    db.PRESENTACION.Remove(pre);
                    db.SaveChanges();
                    return RedirectToAction("PresentacionesLista");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}