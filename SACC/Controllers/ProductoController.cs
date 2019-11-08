using SACC.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Routing;

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
                    return View(db.ALMACEN3.ToList());
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
                      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ALMACEN3 a)
        {
            HttpPostedFileBase FileBase = Request.Files[0];
            if (FileBase.FileName != "")
            {
                WebImage image = new WebImage(FileBase.InputStream);
                a.FOTO_FRENTE = image.GetBytes();
                a.FOTO_LADO = image.GetBytes();
            }
            if (!ModelState.IsValid)//ModelState es para validar que los datos sean los correctos.
            {
                LlenarViewDatas();
                return View();
            }
            try
            {
                                              
                using (var db = new JEENContext())
                {
                    a.FECHA_MOD = DateTime.Now;
                    a.USR_MOD = 1;
                    a.GANANCIA = CalcularPorcentajeGanancia(a.PRECIO_COSTO, a.PRECIO_COSTO2);
                    a.PRECIO_COSTO = CalcularPrecioCompra(a.PRECIO_COSTO, a.GANANCIA, a.PRECIO_COSTO2);
                    a.PRECIO_COSTO2 = CalcularPrecioVenta(a.PRECIO_COSTO2, a.GANANCIA, a.PRECIO_COSTO);
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

        public ActionResult Editar(int id)
        {
            try
            {
                using (var db = new JEENContext())
                {
                    LlenarViewDatas();
                    //Alumnos al = db.Alumnos.Where(a => a.Id == id).FirstOrDefault();//Usar en todos los casos en claves compuestas
                    ALMACEN3 alm3 = db.ALMACEN3.Find(id);//Cuando se tiene un id unico.                
                    return View(alm3);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(ALMACEN3 a)
        {
            HttpPostedFileBase FileBase = Request.Files[0];
            if (FileBase.FileName != "")
            {           
                WebImage image = new WebImage(FileBase.InputStream);
                a.FOTO_FRENTE = image.GetBytes();
                a.FOTO_LADO = image.GetBytes();                
            }
            //WebImage image = new WebImage(FileBase.InputStream);          
            if (!ModelState.IsValid)//ModelState es para validar que los datos sean los correctos.
            {
                LlenarViewDatas();
                return View();
            }                
            try
            {
                using (var db = new JEENContext())
                {                   
                    ALMACEN3 alm3 = db.ALMACEN3.Find(a.NUM);
                    //a.FECHA_ALTA = alm3.FECHA_ALTA;//No se modifica la fecha de registro  
                    //a.USR_MOD = 1;//Se pone usuario por default
                    /*a.FECHA_MOD = DateTime.Now;*///Se pone la fecha del dia para el usuario actualizacion       
                    ////////////////////////////////////////////////////////////////////////////////////     
                    alm3.ID_PRODUCTO = a.ID_PRODUCTO;
                    alm3.DESCRIPCION = a.DESCRIPCION;
                    alm3.ID_DESCUENTO = a.ID_DESCUENTO;
                    alm3.C_MINIMA = a.C_MINIMA;
                    alm3.C_MAXIMA = a.C_MAXIMA;
                    alm3.TIPO = a.TIPO;
                    alm3.VENTA_WEB = a.VENTA_WEB;
                    alm3.MARCA = a.MARCA;
                    alm3.MATERIAL = a.MATERIAL;
                    alm3.COLOR = a.COLOR;
                    alm3.FOTO_FRENTE = a.FOTO_FRENTE;//No se modifica la imagen
                    alm3.FOTO_LADO = a.FOTO_LADO;//No se modifica la imagen
                    alm3.GANANCIA = CalcularPorcentajeGanancia(a.PRECIO_COSTO, a.PRECIO_COSTO2);
                    alm3.PRECIO_COSTO = CalcularPrecioCompra(a.PRECIO_COSTO,alm3.GANANCIA,a.PRECIO_COSTO2);
                    alm3.CLASIFICACION = a.CLASIFICACION;
                    alm3.PRECIO_COSTO2 = CalcularPrecioVenta(a.PRECIO_COSTO2,alm3.GANANCIA,a.PRECIO_COSTO);
                    alm3.LOCALIZACION = a.LOCALIZACION;
                    alm3.PRECIO_EN = a.PRECIO_EN;
                    alm3.USR_ALTA = a.USR_ALTA;
                    alm3.FECHA_ALTA = alm3.FECHA_ALTA;//No se modifica la fecha de registro
                    alm3.USR_MOD = 1;//Se pone usuario por default
                    alm3.FECHA_MOD = DateTime.Now;//Se pone la fecha del dia para el usuario actualizacion
                    alm3.CATEGORIA = a.CATEGORIA;
                    alm3.PRESENTACION = a.PRESENTACION;                                    
                    db.SaveChanges();
                    return RedirectToAction("ProductosLista");
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

                ALMACEN3 alm3 = db.ALMACEN3.Find(id);
                if (alm3.FOTO_FRENTE != null)
                {
                    String img = Convert.ToBase64String(alm3.FOTO_FRENTE);
                    string imageDataURL = string.Format("data:image/png;base64,{0}", img);
                    ViewBag.ImageData = imageDataURL;
                }                
                return View(alm3);
            }

        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new JEENContext())
                {   
                    ALMACEN3 alm3 = db.ALMACEN3.Find(id);
                    db.ALMACEN3.Remove(alm3);
                    db.SaveChanges();
                    return RedirectToAction("ProductosLista");
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
            else {
                PrecioCompra1 = PrecioCompraCal;
            }
            return PrecioCompra1;
        }

        public double CalcularPrecioVenta(double PrecioVentaCal, double PorcGanancia, double PrecioCompraCal) {
            double PrecioVenta1 = 0;
            if (PrecioCompraCal != 0)
            {
                PrecioVenta1 = (((PorcGanancia / 100) + 1) * PrecioCompraCal);
            }else
            {
                PrecioVenta1 = PrecioVentaCal;
            }
            return PrecioVenta1;
        }        
    }
}