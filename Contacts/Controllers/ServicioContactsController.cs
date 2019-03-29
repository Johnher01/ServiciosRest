using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;


namespace Contacts.Controllers
{

    [RoutePrefix("api/ServicioBYS")]
    public class ServicioContactsController : ApiController
    {
        [HttpGet]
        [Route("Guardar/{Cedula}/{Nombre}/{Apellido}/{Telefono}/{Email}")]
        public string Guardar(string Cedula, string Nombre, string Apellido, string Telefono, string Email)
        {

            StreamWriter Registro = File.CreateText("D:\\ Contacto.txt");

            Registro.WriteLine(Cedula + '|' + Nombre + '|' + Apellido + '|' + Telefono + '|' + Email);
           

            Registro.Close();

            StreamWriter RegistroCedula = File.CreateText("D:\\ Cedula.txt");
            RegistroCedula.WriteLine(Cedula);
            RegistroCedula.Close();

            string resultado = Cedula;

            return resultado;
        }


        [HttpGet]
        [Route("Buscar/{Cedula}")]
        public string Buscar(string Cedula)
        {

            using (StreamReader leer = new StreamReader(@"D:\\ Cedula.txt"))
            {
                var x = "0";
                
                while (!leer.EndOfStream)
                {
                    x= leer.ReadLine();                    
                    
                }
                string resultado = x;
                return resultado;
            }

            

            
        }
    }
}
