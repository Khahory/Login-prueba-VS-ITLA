using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Login_Prueba3.Models
{
    public class Cuenta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String User { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        public string Url { get; set; }
    }
}