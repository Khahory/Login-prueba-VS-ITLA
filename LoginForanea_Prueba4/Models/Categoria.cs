using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoginForanea_Prueba4.Models
{
    public class Categoria
    {
        [Key, Column(Order = 0)]
        public int CategoryId1 { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Producto> Products { get; set; }
    }
}