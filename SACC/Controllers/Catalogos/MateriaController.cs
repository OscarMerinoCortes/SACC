using SACC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace SACC.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        public ActionResult Materia1Lista()
        {
            try
            {
                using (var db = new JEENContext())
                {
                    return View(db.ALMACEN1.ToList());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Materia2Lista()
        {
            try
            {
                using (var db = new JEENContext())
                {
                    return View(db.ALMACEN2.ToList());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Create()
        {
            LlenarViewDatas();
            return View();
        }

        public ActionResult CreateAlm2()
        {
            LlenarViewDatas();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ALMACEN1 a)
        {            
            try
            {
                if (!ModelState.IsValid)//ModelState es para validar que los datos sean los correctos.
                {
                    LlenarViewDatas();
                    return View();
                }
                else
                {
                    using (var db = new JEENContext())
                    {
                        HttpPostedFileBase FileBase = Request.Files[0];
                        if (FileBase.FileName != "")
                        {
                            WebImage image = new WebImage(FileBase.InputStream);
                            a.FOTO_FRENTE = image.GetBytes();
                            a.FOTO_LADO = image.GetBytes();
                        }
                        a.FECHA_MOD = DateTime.Now;
                        a.USR_MOD = 1;
                        a.GANANCIA = CalcularPorcentajeGanancia(a.PRECIO_COSTO, a.PRECIO_COSTO2);
                        a.PRECIO_COSTO = CalcularPrecioCompra(a.PRECIO_COSTO, a.GANANCIA, a.PRECIO_COSTO2);
                        a.PRECIO_COSTO2 = CalcularPrecioVenta(a.PRECIO_COSTO2, a.GANANCIA, a.PRECIO_COSTO);
                        db.ALMACEN1.Add(a);
                        db.SaveChanges();
                        return RedirectToAction("Materia1Lista");
                    }
                }                
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Error al registrar el producto - " + ex.Message);
                return View();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAlm2(ALMACEN2 a)
        {           
            try
            {
                if (!ModelState.IsValid)//ModelState es para validar que los datos sean los correctos.
                {
                    LlenarViewDatas();
                    return View();
                }
                else
                {
                    using (var db = new JEENContext())
                    {
                        HttpPostedFileBase FileBase = Request.Files[0];
                        if (FileBase.FileName != "")
                        {
                            WebImage image = new WebImage(FileBase.InputStream);
                            a.FOTO_FRENTE = image.GetBytes();
                            a.FOTO_LADO = image.GetBytes();
                        }
                        a.FECHA_MOD = DateTime.Now;
                        a.USR_MOD = 1;
                        a.GANANCIA = CalcularPorcentajeGanancia(a.PRECIO_COSTO, a.PRECIO_COSTO2);
                        a.PRECIO_COSTO = CalcularPrecioCompra(a.PRECIO_COSTO, a.GANANCIA, a.PRECIO_COSTO2);
                        a.PRECIO_COSTO2 = CalcularPrecioVenta(a.PRECIO_COSTO2, a.GANANCIA, a.PRECIO_COSTO);
                        db.ALMACEN2.Add(a);
                        db.SaveChanges();
                        return RedirectToAction("Materia2Lista");
                    }

                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Error al registrar el producto - " + ex.Message);
                return View();
            }

        }

        public ActionResult Editar(int id)
        {
            try
            {
                using (var db = new JEENContext())
                {
                    LlenarViewDatas();
                    //Alumnos al = db.Alumnos.Where(a => a.Id == id).FirstOrDefault();//Usar en todos los casos en claves compuestas
                    ALMACEN1 alm1 = db.ALMACEN1.Find(id);//Cuando se tiene un id unico.
                    alm1.ID_PRODUCTO = (alm1.ID_PRODUCTO == null) ? alm1.ID_PRODUCTO = "" : alm1.ID_PRODUCTO.Trim();
                    alm1.DESCRIPCION = (alm1.DESCRIPCION == null) ? alm1.DESCRIPCION = "" : alm1.DESCRIPCION.Trim();
                    alm1.ID_DESCUENTO = (alm1.ID_DESCUENTO == null) ? alm1.ID_DESCUENTO = "" : alm1.ID_DESCUENTO.Trim();
                    alm1.TIPO = (alm1.TIPO == null) ? alm1.TIPO = "" : alm1.TIPO.Trim();
                    alm1.VENTA_WEB = (alm1.VENTA_WEB == null) ? alm1.VENTA_WEB = "" : alm1.VENTA_WEB.Trim();
                    alm1.MARCA = (alm1.MARCA == null) ? alm1.MARCA = "" : alm1.MARCA.Trim();
                    alm1.MATERIAL = (alm1.MATERIAL == null) ? alm1.MATERIAL = "" : alm1.MATERIAL.Trim();
                    alm1.COLOR = (alm1.COLOR == null) ? alm1.COLOR = "" : alm1.COLOR.Trim();
                    alm1.LOCALIZACION = (alm1.LOCALIZACION == null) ? alm1.LOCALIZACION = "" : alm1.LOCALIZACION.Trim();
                    alm1.PRECIO_EN = (alm1.PRECIO_EN == null) ? alm1.PRECIO_EN = "" : alm1.PRECIO_EN.Trim();
                    alm1.CATEGORIA = (alm1.CATEGORIA == null) ? alm1.CATEGORIA = "" : alm1.CATEGORIA.Trim();
                    alm1.ESPECIE = (alm1.ESPECIE == null) ? alm1.ESPECIE = "" : alm1.ESPECIE.Trim();                    
                    return View(alm1);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult EditarAlm2(int id)
        {
            try
            {
                using (var db = new JEENContext())
                {
                    LlenarViewDatas();
                    //Alumnos al = db.Alumnos.Where(a => a.Id == id).FirstOrDefault();//Usar en todos los casos en claves compuestas
                    ALMACEN2 alm2 = db.ALMACEN2.Find(id);//Cuando se tiene un id unico.
                    alm2.ID_PRODUCTO = (alm2.ID_PRODUCTO == null) ? alm2.ID_PRODUCTO = "" : alm2.ID_PRODUCTO.Trim();
                    alm2.DESCRIPCION = (alm2.DESCRIPCION == null) ? alm2.DESCRIPCION = "" : alm2.DESCRIPCION.Trim();
                    alm2.ID_DESCUENTO = (alm2.ID_DESCUENTO == null) ? alm2.ID_DESCUENTO = "" : alm2.ID_DESCUENTO.Trim();
                    alm2.TIPO = (alm2.TIPO == null) ? alm2.TIPO = "" : alm2.TIPO.Trim();
                    alm2.VENTA_WEB = (alm2.VENTA_WEB == null) ? alm2.VENTA_WEB = "" : alm2.VENTA_WEB.Trim();
                    alm2.MARCA = (alm2.MARCA == null) ? alm2.MARCA = "" : alm2.MARCA.Trim();
                    alm2.MATERIAL = (alm2.MATERIAL == null) ? alm2.MATERIAL = "" : alm2.MATERIAL.Trim();
                    alm2.COLOR = (alm2.COLOR == null) ? alm2.COLOR = "" : alm2.COLOR.Trim();
                    alm2.LOCALIZACION = (alm2.LOCALIZACION == null) ? alm2.LOCALIZACION = "" : alm2.LOCALIZACION.Trim();
                    alm2.PRECIO_EN = (alm2.PRECIO_EN == null) ? alm2.PRECIO_EN = "" : alm2.PRECIO_EN.Trim();                    
                    alm2.ESPECIE = (alm2.ESPECIE == null) ? alm2.ESPECIE = "" : alm2.ESPECIE.Trim();
                    return View(alm2);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(ALMACEN1 a)
        {                                           
            try
            {
                using (var db = new JEENContext())
                {
                    //a.TIPO = a.TIPO.Trim();
                    if (!ModelState.IsValid)//ModelState es para validar que los datos sean los correctos.
                    {
                        LlenarViewDatas();
                        return View();
                    }
                    else
                    {
                        HttpPostedFileBase FileBase = Request.Files[0];
                        if (FileBase.FileName != "")
                        {
                            WebImage image = new WebImage(FileBase.InputStream);
                            a.FOTO_FRENTE = image.GetBytes();
                            a.FOTO_LADO = image.GetBytes();
                        }
                        ALMACEN1 alm1 = db.ALMACEN1.Find(a.ID);
                        a.FECHA_ALTA = alm1.FECHA_ALTA;//No se modifica la fecha de registro  
                        a.USR_MOD = 1;//Se pone usuario por default
                        /*a.FECHA_MOD = DateTime.Now;*/ //Se pone la fecha del dia para el usuario actualizacion       
                        ////////////////////////////////////////////////////////////////////////////////////     
                        alm1.ID_PRODUCTO = a.ID_PRODUCTO;
                        alm1.DESCRIPCION = a.DESCRIPCION;
                        alm1.ID_DESCUENTO = a.ID_DESCUENTO;
                        alm1.C_MINIMA = a.C_MINIMA;
                        alm1.C_MAXIMA = a.C_MAXIMA;
                        alm1.TIPO = a.TIPO;
                        alm1.VENTA_WEB = a.VENTA_WEB;
                        alm1.MARCA = a.MARCA;
                        alm1.MATERIAL = a.MATERIAL;
                        alm1.COLOR = a.COLOR;
                        alm1.FOTO_FRENTE = a.FOTO_FRENTE;//No se modifica la imagen
                        alm1.FOTO_LADO = a.FOTO_LADO;//No se modifica la imagen
                        alm1.GANANCIA = CalcularPorcentajeGanancia(a.PRECIO_COSTO, a.PRECIO_COSTO2);
                        alm1.PRECIO_COSTO = CalcularPrecioCompra(a.PRECIO_COSTO, alm1.GANANCIA, a.PRECIO_COSTO2);
                        alm1.PRECIO_COSTO2 = CalcularPrecioVenta(a.PRECIO_COSTO2, alm1.GANANCIA, a.PRECIO_COSTO);
                        alm1.PRECIO_VENTA = 0;
                        alm1.LOCALIZACION = a.LOCALIZACION;
                        alm1.PRECIO_EN = a.PRECIO_EN;
                        alm1.USR_ALTA = a.USR_ALTA;
                        alm1.FECHA_ALTA = alm1.FECHA_ALTA;//No se modifica la fecha de registro
                        alm1.USR_MOD = 1;//Se pone usuario por default
                        alm1.FECHA_MOD = DateTime.Now;//Se pone la fecha del dia para el usuario actualizacion
                        alm1.CATEGORIA = a.CATEGORIA;
                        alm1.ESPECIE = a.ESPECIE;
                        db.SaveChanges();
                        return RedirectToAction("Materia1Lista");
                    }                    
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Error al registrar el producto - " + ex.Message);
                throw;
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarAlm2(ALMACEN2 a)
        {            
            try
            {
                if (!ModelState.IsValid)//ModelState es para validar que los datos sean los correctos.
                {
                    LlenarViewDatas();
                    return View();
                }
                else
                {
                    using (var db = new JEENContext())
                    {
                        HttpPostedFileBase FileBase = Request.Files[0];
                        if (FileBase.FileName != "")
                        {
                            WebImage image = new WebImage(FileBase.InputStream);
                            a.FOTO_FRENTE = image.GetBytes();
                            a.FOTO_LADO = image.GetBytes();
                        }                       
                        ALMACEN2 alm2 = db.ALMACEN2.Find(a.ID);
                        a.FECHA_ALTA = alm2.FECHA_ALTA;//No se modifica la fecha de registro  
                        a.USR_MOD = 1;//Se pone usuario por default
                        /*a.FECHA_MOD = DateTime.Now;*///Se pone la fecha del dia para el usuario actualizacion       
                        ////////////////////////////////////////////////////////////////////////////////////     
                        alm2.ID_PRODUCTO = a.ID_PRODUCTO;
                        alm2.DESCRIPCION = a.DESCRIPCION;
                        alm2.ID_DESCUENTO = a.ID_DESCUENTO;
                        alm2.C_MINIMA = a.C_MINIMA;
                        alm2.C_MAXIMA = a.C_MAXIMA;
                        alm2.TIPO = a.TIPO;
                        alm2.VENTA_WEB = a.VENTA_WEB;
                        alm2.MARCA = a.MARCA;
                        alm2.MATERIAL = a.MATERIAL;
                        alm2.COLOR = a.COLOR;
                        alm2.FOTO_FRENTE = a.FOTO_FRENTE;//No se modifica la imagen
                        alm2.FOTO_LADO = a.FOTO_LADO;//No se modifica la imagen
                        alm2.GANANCIA = CalcularPorcentajeGanancia(a.PRECIO_COSTO, a.PRECIO_COSTO2);
                        alm2.PRECIO_COSTO = CalcularPrecioCompra(a.PRECIO_COSTO, alm2.GANANCIA, a.PRECIO_COSTO2);
                        alm2.PRECIO_COSTO2 = CalcularPrecioVenta(a.PRECIO_COSTO2, alm2.GANANCIA, a.PRECIO_COSTO);
                        alm2.PRECIO_VENTA = 0;
                        alm2.LOCALIZACION = a.LOCALIZACION;
                        alm2.PRECIO_EN = a.PRECIO_EN;
                        alm2.USR_ALTA = a.USR_ALTA;
                        alm2.FECHA_ALTA = alm2.FECHA_ALTA;//No se modifica la fecha de registro
                        alm2.USR_MOD = 1;//Se pone usuario por default
                        alm2.FECHA_MOD = DateTime.Now;//Se pone la fecha del dia para el usuario actualizacion
                        alm2.ESPECIE = a.ESPECIE;
                        db.SaveChanges();
                        return RedirectToAction("Materia2Lista");
                    }
                }                
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Error al registrar el producto - " + ex.Message);
                throw;
            }

        }

        public ActionResult Detalles(int id)
        {

            using (var db = new JEENContext())
            {

                ALMACEN1 alm1 = db.ALMACEN1.Find(id);
                if (alm1.FOTO_FRENTE != null)
                {
                    String img = Convert.ToBase64String(alm1.FOTO_FRENTE);
                    string imageDataURL = string.Format("data:image/png;base64,{0}", img);
                    ViewBag.ImageData = imageDataURL;
                }
                return View(alm1);
            }

        }

        public ActionResult DetallesAlm2(int id)
        {

            using (var db = new JEENContext())
            {

                ALMACEN2 alm2 = db.ALMACEN2.Find(id);
                if (alm2.FOTO_FRENTE != null)
                {
                    String img = Convert.ToBase64String(alm2.FOTO_FRENTE);
                    string imageDataURL = string.Format("data:image/png;base64,{0}", img);
                    ViewBag.ImageData = imageDataURL;
                }
                return View(alm2);
            }

        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new JEENContext())
                {
                    ALMACEN1 alm1 = db.ALMACEN1.Find(id);
                    db.ALMACEN1.Remove(alm1);
                    db.SaveChanges();
                    return RedirectToAction("Materia1Lista");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult DeleteAlm2(int id)
        {
            try
            {
                using (var db = new JEENContext())
                {
                    ALMACEN2 alm2 = db.ALMACEN2.Find(id);
                    db.ALMACEN2.Remove(alm2);
                    db.SaveChanges();
                    return RedirectToAction("Materia2Lista");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void LlenarViewDatas()
        {
            using (var db = new JEENContext())
            {
                //llenar el combo de Marcas
                var mar = db.MARCA.ToList();
                var listaMarcas = new SelectList(mar, "DESCRIPCION", "DESCRIPCION");
                ViewData["MarcasAP"] = listaMarcas;
                //llenar el combo de Clasificaciones
                var cla = db.CLASIFICACIONES.ToList();
                var listaClasificaciones = new SelectList(cla, "CLASIFICACION", "CLASIFICACION");
                ViewData["clasificaciones"] = listaClasificaciones;
                //llenar el combo de Presentacion
                var pre = db.PRESENTACION.ToList();
                var listaPresentaciones = new SelectList(pre, "DESCRIPCION", "DESCRIPCION");
                ViewData["presentaciones"] = listaPresentaciones;
                //llenar el combo de Categorias
                var cat = db.CATEGORIAS.ToList();
                var listaCategorias = new SelectList(cat, "DESCRIPCION", "DESCRIPCION");
                ViewData["categorias"] = listaCategorias;
                //llenar el combo de Especies
                var esp = db.ESPECIE.ToList();
                var listaEspecies = new SelectList(esp, "DESCRIPCION", "DESCRIPCION");
                ViewData["especies"] = listaEspecies;
                //FECHA ACTUAL
                //ViewData["fechaActual"] = DateTime.Now.ToString();
            }
        }

        public double CalcularPorcentajeGanancia(double PrecioCompra, double PrecioVenta)
        {
            double Ganancia = 0;
            if (PrecioCompra != 0 && PrecioVenta != 0) //&& PrecioVenta > PrecioCompra)
            {
                Ganancia = (((PrecioVenta / PrecioCompra) - 1) * 100);
            }
            else
            {
                Ganancia = 20;
            }
            return Ganancia;
        }

        public double CalcularPrecioCompra(double PrecioCompraCal, double PorcGanancia, double PrecioVentaCal)
        {
            double PrecioCompra1 = 0;
            if (PrecioVentaCal != 0)
            {
                PrecioCompra1 = PrecioVentaCal / ((PorcGanancia / 100) + 1);
            }
            else
            {
                PrecioCompra1 = PrecioCompraCal;
            }
            return PrecioCompra1;
        }

        public double CalcularPrecioVenta(double PrecioVentaCal, double PorcGanancia, double PrecioCompraCal)
        {
            double PrecioVenta1 = 0;
            if (PrecioCompraCal != 0)
            {
                PrecioVenta1 = (((PorcGanancia / 100) + 1) * PrecioCompraCal);
            }
            else
            {
                PrecioVenta1 = PrecioVentaCal;
            }
            return PrecioVenta1;
        }
    }
}