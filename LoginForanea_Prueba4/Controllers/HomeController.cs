using LoginForanea_Prueba4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginForanea_Prueba4.Controllers
{
    public class HomeController : Controller
    {
        

        public ActionResult Index()
        {

            using (OurDBContext db = new OurDBContext())
            {
                //  var persona = new Persona() {Usuario = "Aura", Password = "1234", Id = 78 };
                // db.Padres.Add(new Padre() { Telefono = 11111, Nombre = "Domingo", Persona = persona});
                //db.Personas.Add(persona);
                //db.SaveChanges();


                //   db.cuentas.Add(model);
                //       db.SaveChanges();

                var categoria = new Categoria() { Name = "Name"};
                db.Productos.Add(new Producto() {Categoria = categoria, CategoryId1 = 200, Name = "ok", ProductId = 2 });
                db.Categorias.Add(categoria);
                db.SaveChanges();
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}