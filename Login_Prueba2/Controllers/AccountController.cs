using Login_Prueba2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login_Prueba2.Controllers
{
    public class AccountController : Controller
    {
        //objetos
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader sqlDataReader; 

        // GET: Account

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Verify(AccountModel model)
        {
            ConnectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Cuentas where Name='"+model.Name +"' Password = '" +model.Password +"'";
            sqlDataReader = com.ExecuteReader();

            if (sqlDataReader.Read())
            {
                con.Close();
                return View("Succes");
            }
            else
            {
                con.Close();
                return View("Error");
            }
        }

        //conexcion de la DB
         void ConnectionString()
        {
            con.ConnectionString = "data source=LAPTOP-ANGEL-GG; database=Cuentas; integrated security=SSPI;";
            //string connStr = ConfigurationManager.ConnectionStrings["entityFramework"].ConnectionString;
            //con.ConnectionString = connStr;
        }


    }
}