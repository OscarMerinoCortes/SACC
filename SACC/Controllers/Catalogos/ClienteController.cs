using SACC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SACC.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult ClientesLista()
        {
            try
            {
                using (var db = new JEENContext())
                {
                    //List<Alumnos> lista = db.Alumnos.Where(a => a.Edad > 18).ToList();
                    //return View(lista);
                    return View(db.CLIENTE.ToList());
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
        public ActionResult Create(CLIENTE a)
        {
            if (!ModelState.IsValid)//ModelState es para validar que los datos sean los correctos.
            {
                //LlenarViewDatas();
                return View();
            }
                
            try
            {
                using (var db = new JEENContext())
                {
                    //a.FechaRegistro = DateTime.Now;
                    db.CLIENTE.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("ClientesLista");
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Error al registrar al cliente - " + ex.Message);
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
                    CLIENTE cli = db.CLIENTE.Find(id);//Cuando se tiene un id unico.
                    //LlenarViewDatas();
                    return View(cli);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(CLIENTE a)
        {
            if (!ModelState.IsValid)//ModelState es para validar que los datos sean los correctos.
            {
                //LlenarViewDatas();
                return View();
            }
                
            try
            {
                using (var db = new JEENContext())
                {
                    CLIENTE cli = db.CLIENTE.Find(a.ID_CLIENTE);
                    cli.NOMBRE = a.NOMBRE;
                    cli.NOMBRE_COMERCIAL = a.NOMBRE_COMERCIAL;
                    cli.RFC = a.RFC;
                    cli.TELEFONO_CASA = a.TELEFONO_CASA;
                    cli.TELEFONO_TRABAJO = a.TELEFONO_TRABAJO;
                    cli.PAIS = a.PAIS;
                    cli.DIAS_CREDITO = a.DIAS_CREDITO;
                    cli.FAX = a.FAX;
                    cli.CONTACTO = a.CONTACTO;
                    cli.DIRECCION = a.DIRECCION;
                    cli.COMENTARIOS = a.COMENTARIOS;
                    cli.CIUDAD = a.CIUDAD;
                    cli.COLONIA = a.COLONIA;
                    cli.DESCUENTO = a.DESCUENTO;
                    cli.ID_DESCUENTO = a.ID_DESCUENTO;
                    cli.ID_AGENTE = a.ID_AGENTE;
                    cli.NUMERO_EXTERIOR = a.NUMERO_EXTERIOR;
                    cli.NUMERO_INTERIOR = a.NUMERO_INTERIOR;
                    cli.CURP = a.CURP;
                    cli.CP = a.CP;
                    cli.EMAIL = a.EMAIL;
                    cli.WEB_PASSWORD = a.WEB_PASSWORD;
                    cli.ESTADO = a.ESTADO;
                    cli.FECHA_ALTA = a.FECHA_ALTA;
                    cli.LIMITE_CREDITO = a.LIMITE_CREDITO;
                    cli.DIRECCION_ENVIO = a.DIRECCION_ENVIO;
                    cli.VALORACION = a.VALORACION;
                    cli.LEYENDAS = a.LEYENDAS;
                    cli.AGENTE = a.AGENTE;
                    cli.ASIG = a.ASIG;
                    cli.RECIBO = a.RECIBO;
                    cli.Adenda_ID_facturaglobal = a.Adenda_ID_facturaglobal;
                    cli.Adenda_proveedor = a.Adenda_proveedor;
                    cli.Adenda_contrato = a.Adenda_contrato;
                    cli.Adenda_unidad_negocio = a.Adenda_unidad_negocio;
                    cli.Adenda_pedido = a.Adenda_pedido;
                    cli.Adenda_fianza = a.Adenda_fianza;
                    cli.Adenda_afianzadora = a.Adenda_afianzadora;
                    cli.Adenda_alta = a.Adenda_alta;
                    cli.Flag_extranjero = a.Flag_extranjero;
                    cli.Num_cuenta_pago_cliente = a.Num_cuenta_pago_cliente;
                    cli.Clave_CFDI = a.Clave_CFDI;
                    db.SaveChanges();
                    return RedirectToAction("ClientesLista");
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

                CLIENTE cli = db.CLIENTE.Find(id);
                return View(cli);
            }

        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new JEENContext())
                {
                    CLIENTE cli = db.CLIENTE.Find(id);
                    db.CLIENTE.Remove(cli);
                    db.SaveChanges();
                    return RedirectToAction("ClientesLista");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public void LlenarViewDatas()
        //{           
        //        //FECHA ACTUAL
        //        ViewData["fechaActual"] = DateTime.Now.Date.ToString("dd/MM/yyyy");    
        //}
    }
}