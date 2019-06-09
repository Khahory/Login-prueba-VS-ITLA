using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Login_Prueba3.Models
{
    public class OurDBContext : DbContext
    {
        public DbSet<Cuenta> cuentas { get; set; }
    }
}