using SACC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SACC.Controllers
{
    public class ClasificacionController : Controller
    {
        // GET: Clasificacion
        public ActionResult ClasificacionLista()
        {
            try
            {
                using (var db = new JEENContext())
                {
                    //List<Alumnos> lista = db.Alumnos.Where(a => a.Edad > 18).ToList();
                    //return View(lista);
                    return View(db.CLASIFICACIONES.ToList());
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
        public ActionResult Create(CLASIFICACIONES a)
        {
            if (!ModelState.IsValid)//ModelState es para validar que los datos sean los correctos.

                return View();

            try
            {
                using (var db = new JEENContext())
                {
                    //a.FechaRegistro = DateTime.Now;
                    db.CLASIFICACIONES.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("ClasificacionLista");
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Error al registrar la clasificacion - " + ex.Message);
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
                    CLASIFICACIONES cla = db.CLASIFICACIONES.Find(id);//Cuando se tiene un id unico.
                    return View(cla);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(CLASIFICACIONES a)
        {
            if (!ModelState.IsValid)//ModelState es para validar que los datos sean los correctos.

                return View();
            try
            {
                using (var db = new JEENContext())
                {
                    CLASIFICACIONES cla = db.CLASIFICACIONES.Find(a.ID);                    
                    cla.CLASIFICACION = a.CLASIFICACION;
                    db.SaveChanges();
                    return RedirectToAction("ClasificacionLista");
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

                CLASIFICACIONES cla = db.CLASIFICACIONES.Find(id);
                return View(cla);
            }

        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new JEENContext())
                {
                    CLASIFICACIONES cla = db.CLASIFICACIONES.Find(id);
                    db.CLASIFICACIONES.Remove(cla);
                    db.SaveChanges();
                    return RedirectToAction("ClasificacionLista");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}