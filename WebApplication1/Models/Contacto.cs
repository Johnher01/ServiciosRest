using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity;
using System.Globalization;
using System.Web.Security;
using System.Linq;
using System.Web;


namespace WebApplication1.Models
{



    public class Contacto
    {

        public int IdContacto { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }




    }
}


