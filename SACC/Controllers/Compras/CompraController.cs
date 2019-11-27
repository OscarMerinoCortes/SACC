using SACC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SACC.Controllers.Compras
{
    public class CompraController : Controller
    {
        // GET: Compra
        //public ActionResult ListaRequisiciones()
        //{
        //    try
        //    {
        //        //REQUISICION model = new REQUISICION()
        //        //{
        //        //    CustomerList = new SelectList(repository.GetAllWithoutSelection(), "CustomerID", "CompanyName")
        //        //};
        //        using (var db = new JEENContext())
        //        {
        //            //List<DIREIMPOR> lista = db.DIREIMPOR.Where(a => a.STATUS == "A").ToList();
        //            return View(db.REQUISICION.ToList());
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public ActionResult ListaRequisiciones(string inpBuscar)
        {
            using (var db = new JEENContext())
            {
                var busqueda = from s in db.REQUISICION select s;

                if (!String.IsNullOrEmpty(inpBuscar))
                {
                    busqueda = busqueda.Where(s => s.URGENTE.Contains(inpBuscar));
                                           //|| s.Apellidos.Contains(Nombre));
                }
                else
                {
                    return View(db.REQUISICION.ToList());
                }
                return View(busqueda.ToList());
            }
        }
    }
}