using SACC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SACC.Controllers
{
    public class SucursalController : Controller
    {
        // GET: Sucursal
        public ActionResult SucursalLista()
        {
            try
            {
                using(var db = new JEENContext())
                {
                    return View(db.SUCURSALES.ToList());
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
    public ActionResult Create(SUCURSALES a)
    {
        if (!ModelState.IsValid)//ModelState es para validar que los datos sean los correctos.

            return View();

        try
        {
            using (var db = new JEENContext())
            {
                //a.FechaRegistro = DateTime.Now;
                db.SUCURSALES.Add(a);
                db.SaveChanges();
                return RedirectToAction("SucursalLista");
            }

        }
        catch (Exception ex)
        {

            ModelState.AddModelError("", "Error al registrar la sucursal - " + ex.Message);
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
                SUCURSALES suc = db.SUCURSALES.Find(id);//Cuando se tiene un id unico.
                return View(suc);
            }
        }
        catch (Exception)
        {

            throw;
        }

    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Editar(SUCURSALES a)
    {
        if (!ModelState.IsValid)//ModelState es para validar que los datos sean los correctos.

            return View();
        try
        {
            using (var db = new JEENContext())
            {
                SUCURSALES suc = db.SUCURSALES.Find(a.ID_SUCURSAL);
                    suc.NOMBRE = a.NOMBRE;
                    suc.CALLE = a.CALLE;
                    suc.COLONIA = a.COLONIA;
                    suc.CIUDAD = a.CIUDAD;
                    suc.ESTADO = a.ESTADO;
                    suc.TELEFONO = a.TELEFONO;
                    suc.ELIMINADO = a.ELIMINADO;
                    suc.DISTINTIVO = a.DISTINTIVO;
                    suc.IVA = a.IVA;
                    suc.CP = a.CP;
                    suc.APLICA_PROMO = a.APLICA_PROMO;
                    db.SaveChanges();
                return RedirectToAction("SucursalLista");
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

            SUCURSALES suc = db.SUCURSALES.Find(id);
            return View(suc);
        }

    }

    public ActionResult Delete(int id)
    {
        try
        {
            using (var db = new JEENContext())
            {
                SUCURSALES suc = db.SUCURSALES.Find(id);
                db.SUCURSALES.Remove(suc);
                db.SaveChanges();
                return RedirectToAction("SucursalLista");
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
}
}