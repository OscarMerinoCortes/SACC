using SACC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SACC.Controllers
{
    public class BodegaUSAController : Controller
    {
        // GET: BodegaUSA
        public ActionResult BodegaLista()
        {
            try
            {
                using (var db = new JEENContext())
                {
                    List<DIREIMPOR> lista = db.DIREIMPOR.Where(a => a.STATUS == "A").ToList();
                    return View(lista);
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
        public ActionResult Create(DIREIMPOR a)
        {
            if (!ModelState.IsValid)//ModelState es para validar que los datos sean los correctos.
            {
                return View();
            }
              else
            {
                try
                {
                    using (var db = new JEENContext())
                    {
                        db.DIREIMPOR.Add(a);
                        db.SaveChanges();
                        return RedirectToAction("BodegaLista");
                    }

                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("", "Error al registrar la bodega - " + ex.Message);
                    return View();
                }
            }           
        }

        public ActionResult Editar(int id)
        {
            try
            {
                using (var db = new JEENContext())
                {
                    //Alumnos al = db.Alumnos.Where(a => a.Id == id).FirstOrDefault();//Usar en todos los casos en claves compuestas
                    DIREIMPOR dir = db.DIREIMPOR.Find(id);//Cuando se tiene un id unico.
                    return View(dir);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(DIREIMPOR a)
        {
            if (!ModelState.IsValid)//ModelState es para validar que los datos sean los correctos.

                return View();
            try
            {
                using (var db = new JEENContext())
                {                                      
                    DIREIMPOR dir = db.DIREIMPOR.Find(a.ID);
                    dir.NOMBRE = a.NOMBRE;
                    dir.DIRECCION = a.DIRECCION;
                    dir.CD = a.CD;
                    dir.TEL1 = a.TEL1;
                    dir.TEL2 = a.TEL2;
                    dir.STATUS = a.STATUS;
                    db.SaveChanges();
                    return RedirectToAction("BodegaLista");
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

                DIREIMPOR dir = db.DIREIMPOR.Find(id);
                return View(dir);
            }

        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new JEENContext())
                {
                    DIREIMPOR dir = db.DIREIMPOR.Find(id);
                    db.DIREIMPOR.Remove(dir);
                    db.SaveChanges();
                    return RedirectToAction("BodegaLista");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }                     
    }
}

