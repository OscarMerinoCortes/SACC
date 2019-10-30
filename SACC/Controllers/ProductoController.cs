using SACC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SACC.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult ProductosLista()
        {
            try
            {
                using (var db = new JEENContext())
                {                    
                    //List<Alumnos> lista = db.Alumnos.Where(a => a.Edad > 18).ToList();
                    //return View(lista);
                    return View(db.ALMACEN3.ToList());
                }
            }
            catch (Exception)
            {

                throw;
            }       
        }

        public ActionResult Create()
        {      //Aquí consultas los usuarios
            using (var db = new JEENContext())
            {
                var mar = db.MARCA.ToList();
                var listaMarcas = new SelectList(mar, "ID_MARCA", "MARCA1");
                ViewData["marcas"] = listaMarcas;
                return View();           
            }
            
        }
      
                
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ALMACEN3 a)
        {
            
            if (!ModelState.IsValid)//ModelState es para validar que los datos sean los correctos.

                return View();
            try
            {
                                              
                using (var db = new JEENContext())
                {                                         
                    db.ALMACEN3.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("ProductosLista");
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Error al registrar el producto - " + ex.Message);
                return View();
            }

        }
    }
}