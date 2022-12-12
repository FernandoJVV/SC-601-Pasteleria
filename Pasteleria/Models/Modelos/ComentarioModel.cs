using Pasteleria.Models.Objetos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;

namespace Pasteleria.Models.Modelos
{
    public class ComentarioModel
    {
        public List<ComentarioObj> ObtenerComentarios(int id) {
            using (HttpClient client = new HttpClient()) {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "/api/Cotizaciones/Comentarios?id=" + id;

                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode) {
                    return respuesta.Content.ReadAsAsync<List<ComentarioObj>>().Result;
                }
            }
            return null;
        }

        public List<ComentarioObj> AgregarComentarios(string email, ComentarioObj comentario) {
            using (HttpClient client = new HttpClient()) {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "/api/Cotizaciones/Comentarios?idCotizacion=" + comentario.IdCotizacion+ "&email=" + email;

                JsonContent contenido = JsonContent.Create(comentario);
                HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;
                if (respuesta.IsSuccessStatusCode) {
                    return respuesta.Content.ReadAsAsync<List<ComentarioObj>>().Result;
                }
            }
            return null;
        }
    }
}