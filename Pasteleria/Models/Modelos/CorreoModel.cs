using Pasteleria.Models.Objetos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Web;

namespace Pasteleria.Models.Modelos
{
    public class CorreoModel
    {
        public CorreoObj ExisteCorreo(CorreoObj correo)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Correo/existeCorreo?correo=" + correo;


                JsonContent contenido = JsonContent.Create(correo);
                HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<CorreoObj>().Result;
                }
                return null;
            }
        }


        public UsuarioObj CambiarContrasenaRecuperacionModel(UsuarioObj obj)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Correo/CambiarContrasenaRecuperacion";

                JsonContent contenido = JsonContent.Create(obj);

                HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<UsuarioObj>().Result;
                }
                return null;
            }
        }




    }
}