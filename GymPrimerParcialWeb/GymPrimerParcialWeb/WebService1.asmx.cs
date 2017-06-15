using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace GymPrimerParcialWeb
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://Gym.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "El mejor Gimnasio";
        }

        [WebMethod]
        public string UsuarioGym(string nombre, string ApePat)
        {
            return "Nombre del Usuario: " + nombre + " Apellido: " + ApePat;
        }

        [WebMethod]
        public List<String> Usuarios()
        {
            List<string> lista = new List<string>();
            using (var u = new gymEntities())
            {
                var us = from usu in u.usuario
                         select usu;

                foreach (var s in us)
                {
                    lista.Add(s.nombre_usu);
                }

            }

            return lista;
        }
    }
}
