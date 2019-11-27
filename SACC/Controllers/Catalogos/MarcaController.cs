using SACC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SACC.Controllers
{
    public class MarcaController : Controller
    {
        // GET: Marca
        public ActionResult MarcasLista()
        {
            try
            {
                using (var db = new JEENContext())
                {
                    //List<Alumnos> lista = db.Alumnos.Where(a => a.Edad > 18).ToList();
                    //return View(lista);
                    return View(db.MARCA.ToList());
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
        public ActionResult Create(MARCA a)
        {
            if (!ModelState.IsValid)//ModelState es para validar que los datos sean los correctos.

                return View();

            try
            {
                using (var db = new JEENContext())
                {
                    //a.FechaRegistro = DateTime.Now;
                    db.MARCA.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("MarcasLista");
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Error al registrar la marca - " + ex.Message);
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
                    MARCA mar = db.MARCA.Find(id);//Cuando se tiene un id unico.
                    return View(mar);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(MARCA a)
        {
            if (!ModelState.IsValid)//ModelState es para validar que los datos sean los correctos.

                return View();
            try
            {
                using (var db = new JEENContext())
                {
                    MARCA mar = db.MARCA.Find(a.ID_MARCA);
                    mar.DESCRIPCION = a.DESCRIPCION;
                    db.SaveChanges();
                    return RedirectToAction("MarcasLista");
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

                MARCA mar = db.MARCA.Find(id);
                return View(mar);
            }

        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new JEENContext())
                {
                    MARCA mar = db.MARCA.Find(id);
                    db.MARCA.Remove(mar);
                    db.SaveChanges();
                    return RedirectToAction("MarcasLista");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}