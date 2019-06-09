using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoginForanea_Prueba4.Models
{
    public class Producto
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int CategoryId1 { get; set; }
        

        [ForeignKey("CategoryId1")]
        public virtual Categoria Categoria{ get; set; }
    }
}