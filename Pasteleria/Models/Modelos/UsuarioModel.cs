using Antlr.Runtime.Misc;
using Pasteleria.Models.Objetos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;

namespace Pasteleria.Models.Modelos
{
    public class UsuarioModel
    {

        public List<UsuarioObj> UsuariosLista()
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "https://localhost:44377/api/Usuario/UsuariosLista";
                //string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();

                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserialización System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<List<UsuarioObj>>().Result;
                }
                return null;
            }

        }
    }
}