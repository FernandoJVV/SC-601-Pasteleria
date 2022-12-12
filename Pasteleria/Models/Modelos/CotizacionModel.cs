using Pasteleria.Models.Objetos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Web;
using System.Web.Helpers;

namespace Pasteleria.Models.Modelos
{
    public class CotizacionModel
    {
        public List<CotizacionObj> ObtenerCotizaciones() {
            using (HttpClient client = new HttpClient()) {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "/api/Cotizaciones/ListaCotizaciones";
                string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode) {
                    return respuesta.Content.ReadAsAsync<List<CotizacionObj>>().Result;
                }
                return null;
            }

        }
        public CotizacionObj ObtenerCotizacion(int id) {
            using (HttpClient client = new HttpClient()) {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "/api/Cotizaciones/GetCotizacion?id=" + id;
                string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode) {
                    return respuesta.Content.ReadAsAsync<CotizacionObj>().Result;
                }
                return null;
            }
        }

        public List<EstadoObj> ObtenerEstados() {
            using (HttpClient client = new HttpClient()) {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "/api/Cotizaciones/ListarEstados";
                string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode) {
                    return respuesta.Content.ReadAsAsync<List<EstadoObj>>().Result;
                }
                return null;
            }
        }

        public bool ActualizarCotizacion(int COT_ID, decimal cOT_ESTIMADO, int cOT_EST_DESC) {
            if (!ActualizarMonto(COT_ID, cOT_ESTIMADO))
                return false;
            if (!ActualizarEstado(COT_ID, cOT_EST_DESC))
                return false;

            return true;
        }

        private bool ActualizarMonto(int COT_ID, decimal COT_ESTIMADO) {
            using (HttpClient client = new HttpClient()) {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "/api/Cotizaciones/EditarEstimadoCot";
                var cot = new DTOCotizacion() {
                    COT_ID = COT_ID,
                    COT_ESTIMADO = COT_ESTIMADO
                };
                //Serialización System.Net.Http.Json;
                JsonContent contenido = JsonContent.Create(cot);
                string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.PutAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode) {
                    return true;
                }
            }
            return false;
        }

        private bool ActualizarEstado(int COT_ID, int COT_EST_DESC) {
            using (HttpClient client = new HttpClient()) {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "/api/Cotizaciones/EditarEstadoCot";
                var cot = new DTOCotizacion() {
                    COT_ID = COT_ID,
                    COT_EST_ID = COT_EST_DESC
                };
                //Serialización System.Net.Http.Json;
                JsonContent contenido = JsonContent.Create(cot);
                string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.PutAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode) {
                    return true;
                }
            }
            return false;
        }

        public List<OpcionObj> ObtenerOpcionesCotizacion(int id) {
            using (HttpClient client = new HttpClient()) {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "/api/Cotizaciones/OpcionCotizacion?id=" + id;
                string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode) {
                    return respuesta.Content.ReadAsAsync<List<OpcionObj>>().Result;
                }
            }
            return null;
        }

        public List<CotizacionObj> ListarCotizacionUsuario(string email) {
            var idUsuario = GetUserId(email);

            using (HttpClient client = new HttpClient()) {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "/api/Cotizaciones/CotizacionesPorUsuario?idUsuario=" + idUsuario;
                string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode) {
                    return respuesta.Content.ReadAsAsync<List<CotizacionObj>>().Result;
                }
                return null;
            }
        }

        public int CrearCotizacion(DTOCotizacion dtoCot, string email) {
            var idUsuario = GetUserId(email);

            dtoCot.COT_USU_ID = idUsuario;

            using (HttpClient client = new HttpClient()) {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "/api/api/Cotizaciones/RegistrarCotizaciones";
                string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                JsonContent content = JsonContent.Create(dtoCot);

                HttpResponseMessage respuesta = client.PostAsync(rutaApi, content).Result;

                if (respuesta.IsSuccessStatusCode) {
                    return respuesta.Content.ReadAsAsync<int>().Result;
                }
                return 0;
            }
        }

        private int GetUserId(string email) {
            using (HttpClient client = new HttpClient()) {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "/api/Usuario/ObtenerId?email=" + email;

                string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);



                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;
                if (respuesta.IsSuccessStatusCode) {
                    return respuesta.Content.ReadAsAsync<int>().Result;
                }
                else {
                    return 0;
                }
            }
        }
    }

}