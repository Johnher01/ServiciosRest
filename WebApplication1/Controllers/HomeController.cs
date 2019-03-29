using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Text.RegularExpressions;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        public JsonResult RegistrarContacto(string Cedula, string Nombre, string Apellido, string Telefono, string Email)
        {

            Contacto _contacto = new Contacto();

            //_contacto.IdContacto = Cedula;
            _contacto.Nombre = Nombre;
            _contacto.Apellido = Apellido;
            _contacto.Telefono = Telefono;
            _contacto.Email = Email;

            var url = "http://localhost:62950/api/ServicioBYS/Guardar/'" + Cedula + "'/'" + Nombre + "'/'" + Apellido + "'/'" + Telefono + "'/'" + Email;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
            }




            return Json(new { Resultado = "Guardado", Mensaje = "Registrado con Exito" });


        }

        public JsonResult ConsultarContacto(string Cedula)
        {

            Contacto _contacto = new Contacto();


            var url = "http://localhost:62950/api/ServicioBYS/Buscar/'" + Cedula ;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            var resultado = "0";

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
               var result = reader.ReadToEnd();
               result = result.Replace("'"," ");
               resultado = result.Trim(new char[]{' ','/','"'});
              
            }

            if (resultado == Cedula)
                return Json(new { Resultado = "ERROR", Mensaje = "El Usuario Ya Se Encuentra Registrado" });
            else
                return Json(new { Resultado = "Guardado", Mensaje = "Usuario No Registrado" });


        }

        
    }
}