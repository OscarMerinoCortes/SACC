using SACC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SACC.Controllers
{
    public class ProveedorController : Controller
    {
        // GET: Proveedor
        public ActionResult ProveedorLista()
        {
            try
            {
                using (var db = new JEENContext())
                {
                    //List<Alumnos> lista = db.Alumnos.Where(a => a.Edad > 18).ToList();
                    //return View(lista);
                    return View(db.PROVEEDOR.ToList());
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
        public ActionResult Create(PROVEEDOR a)
        {
            if (!ModelState.IsValid)//ModelState es para validar que los datos sean los correctos.

                return View();

            try
            {
                using (var db = new JEENContext())
                {
                    a.ELIMINADO = "N";
                    db.PROVEEDOR.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("ProveedorLista");
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Error al registrar al proveedor - " + ex.Message);
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
                    PROVEEDOR pro = db.PROVEEDOR.Find(id);//Cuando se tiene un id unico.
                    return View(pro);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(PROVEEDOR a)
        {
            if (!ModelState.IsValid)//ModelState es para validar que los datos sean los correctos.

                return View();
            try
            {
                using (var db = new JEENContext())
                {
                    PROVEEDOR pro = db.PROVEEDOR.Find(a.ID_PROVEEDOR);
                    pro.NOMBRE = a.NOMBRE;
                    pro.DIRECCION = a.DIRECCION;
                    pro.COLONIA = a.COLONIA;
                    pro.CIUDAD = a.CIUDAD;
                    pro.CP = a.CP;
                    pro.RFC = a.RFC;
                    pro.TELEFONO1 = a.TELEFONO1;
                    pro.TELEFONO2 = a.TELEFONO2;
                    pro.TELEFONO3 = a.TELEFONO3;
                    pro.NOTAS = a.NOTAS;
                    pro.ESTADO = a.ESTADO;
                    pro.PAIS = a.PAIS;
                    pro.TRANS_BANCO = a.TRANS_BANCO;
                    pro.TRANS_DIRECCION = a.TRANS_DIRECCION;
                    pro.TRANS_CIUDAD = a.TRANS_CIUDAD;
                    pro.TRANS_ROUTING = a.TRANS_ROUTING;
                    pro.TRANS_CUENTA = a.TRANS_CUENTA;
                    pro.TRANS_CLAVE_SWIFT = a.TRANS_CLAVE_SWIFT;
                    pro.ELIMINADO = a.ELIMINADO;
                    pro.ALMACEN1 = a.ALMACEN1;
                    pro.ALMACEN2 = a.ALMACEN2;
                    pro.ALMACEN3 = a.ALMACEN3;                    
                    db.SaveChanges();
                    return RedirectToAction("ProveedorLista");
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

                PROVEEDOR cli = db.PROVEEDOR.Find(id);
                return View(cli);
            }

        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new JEENContext())
                {
                    PROVEEDOR pro = db.PROVEEDOR.Find(id);
                    db.PROVEEDOR.Remove(pro);
                    db.SaveChanges();
                    return RedirectToAction("ProveedorLista");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}