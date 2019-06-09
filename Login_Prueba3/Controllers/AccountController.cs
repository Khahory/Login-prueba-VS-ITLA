using Login_Prueba3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login_Prueba3.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (OurDBContext db = new OurDBContext())
            {
                return View(db.cuentas.ToList());
            }
            
        }

        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(Cuenta model)
        {

            //Si el modelo es valido
            if (ModelState.IsValid)
            {
                using (OurDBContext db = new OurDBContext())
                {
                    Boolean tik = false;
                    string nombreLocal = model.User;

                    //aqui verificamos que el nombre que ingreso en la vista no exista en la DB
                    foreach (var item in db.cuentas)
                    {
                        if (nombreLocal == item.User)
                        {
                            tik = true;
                        }
                    }

                    //aqui verificamos que hacer en caso de que el tik sea true o falso,
                    //o sea, en caso de que existe el usario en la DB si o no
                    if (tik)
                    {
                        ViewBag.Message = model.User + " Error: Esta persona existe en l DB";
                    }
                    else
                    {
                        ViewBag.Message = model.User + " Bienvenido";
                        db.cuentas.Add(model);
                        db.SaveChanges();
                    }

                }
                
            }
            return View();
        }

        //login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Cuenta cuenta)
        {
            using (OurDBContext db = new OurDBContext())
            {
                try
                {
                    //verifica si los datos estan correctos
                    var usr = db.cuentas.Single(u => u.User == cuenta.User && u.Password == cuenta.Password);

                    //esto es para guardar en session (son varables temporales o algo asi) para luego usarla a nuestro gusto
                    //Ej: podemos obtener el nombre de usario diciendo: String nombre = Session["User"].ToString()
                    if (usr != null)
                    {
                        Session["Id"] = usr.Id.ToString();
                        Session["User"] = usr.User.ToString();
                        return RedirectToAction("LoggeIn");
                    }
                    else
                    {
                        ModelState.AddModelError("", "El usuario o la contrasena esta incorrecto");
                    }
                }
                catch (Exception)
                {
                    //en caso de que ocurra un error en la verificacion del login pues se ejecuta este Catch
                    return View("Login");
                    throw;
                }
            }

            return View();
        }

        //Actualmente podemos acceder a esta vista sin tener que verificar (lo que pasa es que yo estaba haciendo pruebas)
        //Podemos cambiar eso en el View del Else poder que se dirija a un view que queramos
        public ActionResult LoggeIn()
        {
            //esto es para que se verificque si el usuario esta logueadon en la aplicacion
            if (Session["Id"] != null)
            {
                
                return View();
            }
            else
            {
                ViewBag.Message = "Credenciales erroneas";
                return RedirectToAction("Login");
            }
        }
    }
}