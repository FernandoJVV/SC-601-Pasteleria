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
    public class CotizacionModel
    {
        public List<CotizacionObj> ObtenerCotizaciones() {
            using (HttpClient client = new HttpClient()) {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "/api/Cotizaciones/ListaCotizaciones";

                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode) {
                    return respuesta.Content.ReadAsAsync<List<CotizacionObj>>().Result;
                }
                return null;
            }

        }
        public CotizacionObj ObtenerCotizacion(int id) {
            using (HttpClient client = new HttpClient()) {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "/api/Cotizaciones/GetCotizacion?id="+id;

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

                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode) {
                    return respuesta.Content.ReadAsAsync<List<EstadoObj>>().Result;
                }
                return null;
            }
        }

        public bool ActualizarCotizacion(int COT_ID, decimal cOT_ESTIMADO, int cOT_EST_DESC) {
            if(!ActualizarMonto(COT_ID, cOT_ESTIMADO)) 
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
                HttpResponseMessage respuesta = client.PutAsync(rutaApi,contenido).Result;

                if (respuesta.IsSuccessStatusCode) {
                    return true;
                }
            }
            return false;
        }

        public List<OpcionObj> ObtenerOpcionesCotizacion(int id) {
            using (HttpClient client = new HttpClient()) {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "/api/Cotizaciones/OpcionCotizacion?id="+id;

                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode) {
                    return respuesta.Content.ReadAsAsync<List<OpcionObj>>().Result;
                }
            }
            return null;
        }

        public List<CotizacionObj> ListarCotizacionUsuario(string email) {
            var idUsuario = 0;

            using (HttpClient client = new HttpClient()) {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "/api/Usuario/ObtenerId?email="+ email;

                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode) {
                    idUsuario = respuesta.Content.ReadAsAsync<int>().Result;
                }
                else {
                    return null;
                }
            }

            using (HttpClient client = new HttpClient()) {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "/api/Cotizaciones/CotizacionesPorUsuario?idUsuario="+ idUsuario;

                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode) {
                    return respuesta.Content.ReadAsAsync<List<CotizacionObj>>().Result;
                }
                return null;
            }
        }
    }
}