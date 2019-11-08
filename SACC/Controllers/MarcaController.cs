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
    }
}