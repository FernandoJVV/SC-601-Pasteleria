using Pasteleria.Models.Objetos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;
using System.Net.Http.Headers;

namespace Pasteleria.Models.Modelos
{
    public class OpcionModel
    {

        public List<OpcionObj> OpcionesLista()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Opcion/Lista";
                    string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {

                        return respuesta.Content.ReadAsAsync<List<OpcionObj>>().Result;
                    }
                    return null;
                }
            }
            catch (Exception)
            {
                Exception ex = new Exception("Error al obtener lista de opciones.");
                return null;
            }

        }


        public OpcionObj ConsultaOpcion(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Opcion/ConsultaOpcion?id=" + id;
                    string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {

                        return respuesta.Content.ReadAsAsync<OpcionObj>().Result;
                    }
                    return null;
                }
            }
            catch (Exception)
            {
                Exception ex = new Exception("Error al buscar opcion por ID.");
                return null;
            }

        }


        public string OpcionActualizar(OpcionObj opcion)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Opcion/ActualizarOpcion";

                    string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();


                    JsonContent contenido = JsonContent.Create(opcion);

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    HttpResponseMessage respuesta = client.PutAsync(rutaApi, contenido).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {

                        return respuesta.ReasonPhrase;
                    }
                    return null;
                }
            }
            catch (Exception)
            {
                Exception ex = new Exception("Error al actualizar opcion.");
                return null;
            }

        }



        public string OpcionRegistrar(OpcionObj opcion)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Opcion/CrearOpcion";
                    string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();

                    JsonContent contenido = JsonContent.Create(opcion);

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {

                        return respuesta.ReasonPhrase;
                    }
                    return null;
                }
            } catch (Exception)
            {
                Exception ex = new Exception("Error al registrar nueva opcion.");
                return null;
            }

        }

        public List<CategoriaObj> GetCategorias()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Opcion/getCategorias";
                    string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {

                        return respuesta.Content.ReadAsAsync<List<CategoriaObj>>().Result;
                    }
                    return null;
                }
            }catch (Exception)
            {
                Exception ex = new Exception("Error al cargar categorias.");
                return null;
            }

        }


        public string EliminarOpcion(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Opcion/EliminarOpcion?opcion=" + id;
                    string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    HttpResponseMessage respuesta = client.DeleteAsync(rutaApi).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {

                        return respuesta.ReasonPhrase;
                    }
                    return null;
                }
            } catch (Exception)
            {
                Exception ex = new Exception("Error al eliminar una opcion.");
                return null;
            }

        }

        public List<OpcionObj> OpcionesHabilitadas()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Opcion/OpcionesHabilitadas";
                    string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {

                        return respuesta.Content.ReadAsAsync<List<OpcionObj>>().Result;
                    }
                    return null;
                }
            }catch (Exception)
            {
                Exception ex = new Exception("Error al cargar opciones habilitadas.");
                return null;
            }

        }



    }//class
}