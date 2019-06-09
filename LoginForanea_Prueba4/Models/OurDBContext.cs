using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LoginForanea_Prueba4.Models
{
    public class OurDBContext : DbContext
    {

        public DbSet<Producto> Productos{ get; set; }
        public DbSet<Categoria> Categorias{ get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          //  modelBuilder.Entity<Padre>().HasRequired(x => x.Persona);
            base.OnModelCreating(modelBuilder);
        }


    }
}