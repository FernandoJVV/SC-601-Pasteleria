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
            try
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
            catch (Exception)
            {
                Exception ex = new Exception("Error al revisar existencia del correo.");
                return null;
            }
        }


        public UsuarioObj CambiarContrasenaRecuperacionModel(UsuarioObj obj)
        {
            try
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
            catch (Exception)
            {
                Exception ex = new Exception("Error al ejecutar cambio de contrasena.");
                return null;
            }
        }




    }
}