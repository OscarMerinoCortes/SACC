using SACC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SACC.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult CategoriasLista()
        {
            try
            {
                using (var db = new JEENContext())
                {
                    List<CATEGORIAS> lista = db.CATEGORIAS.Where(a => a.IdEstatus == 1).ToList();               
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
            //LlenarViewDatas();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CATEGORIAS a)
        {
            if (!ModelState.IsValid)//ModelState es para validar que los datos sean los correctos.

                return View();

            try
            {
                using (var db = new JEENContext())
                {
                    //a.FechaRegistro = DateTime.Now;
                    db.CATEGORIAS.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("CategoriasLista");
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Error al registrar la categoria - " + ex.Message);
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
                    CATEGORIAS cat = db.CATEGORIAS.Find(id);//Cuando se tiene un id unico.
                    return View(cat);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(CATEGORIAS a)
        {
            if (!ModelState.IsValid)//ModelState es para validar que los datos sean los correctos.

                return View();
            try
            {
                using (var db = new JEENContext())
                {
                    CATEGORIAS cat = db.CATEGORIAS.Find(a.IdCategoria);
                    cat.Descripcion = a.Descripcion;
                    cat.Fecha = a.Fecha;
                    cat.IdEstatus = a.IdEstatus;
                    db.SaveChanges();
                    return RedirectToAction("CategoriasLista");
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

                CATEGORIAS cat = db.CATEGORIAS.Find(id);
                return View(cat);
            }

        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new JEENContext())
                {
                    CATEGORIAS cat = db.CATEGORIAS.Find(id);
                    db.CATEGORIAS.Remove(cat);
                    db.SaveChanges();
                    return RedirectToAction("CategoriasLista");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public void LlenarViewDatas()
        //{
        //    //FECHA ACTUAL
        //    ViewData["fechaActual"] = DateTime.Now;
        //}
    }
}