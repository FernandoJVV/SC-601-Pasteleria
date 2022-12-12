using Microsoft.Ajax.Utilities;
using Pasteleria.Models.Objetos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Web.Mvc;
using System.Net.Http.Json;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace Pasteleria.Models.Modelos
{
    public class UsuarioModel
    {

        public List<UsuarioObj> UsuariosLista()
        {
            try {
                using (HttpClient client = new HttpClient())
                {
                    string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Usuario/UsuariosLista";
                    string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                        HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                        if (respuesta.IsSuccessStatusCode)
                        {
                            //Deserialización System.Net.Http.Formatting.Extension
                            return respuesta.Content.ReadAsAsync<List<UsuarioObj>>().Result;
                        }
                        return null;
                }
            }
            catch (Exception)
            {
                Exception ex = new Exception("Error al obtener lista del usuario.");
                return null;
            }
        }

        public List<SelectListItem> ListarTipoUsuarios()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Usuario/ListarTipoUsuarios";
                string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();
                
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        //Deserialización System.Net.Http.Formatting.Extension
                        return respuesta.Content.ReadAsAsync<List<SelectListItem>>().Result;
                    }
                    return null;
                }
            }
            catch (Exception)
            {
                Exception ex = new Exception("Error al obtener lista de tipos de usuario.");
                return null;
            }
        }


        public UsuarioObj ValidarUsuario(UsuarioObj usuario) {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Usuario/ValidarUsuario";

                    //Serialización System.Net.Http.Json;
                    JsonContent contenido = JsonContent.Create(usuario);

                    HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;
                    if (respuesta.IsSuccessStatusCode)
                    {
                        var Respuesta = respuesta.Content.ReadAsAsync<UsuarioObj>().Result;
                        if (Respuesta.token == null)
                        {
                            return null;
                        }
                        var jwt = new JwtSecurityTokenHandler().ReadJwtToken(Respuesta.token);
                        string role = jwt.Claims.First(c => c.Type == ClaimTypes.Role).Value;
                        TipoUsuarioModel tipoUsuarioModel = new TipoUsuarioModel(0, role);
                        usuario.tipoUsuario = tipoUsuarioModel;
                        usuario.token = Respuesta.token;
                        usuario.id = Respuesta.id;
                        //Deserialización System.Net.Http.Formatting.Extension
                        //return respuesta.Content.ReadAsAsync<RespuestaUsuario>().Result;
                        return usuario;
                    }
                    return null;
                }
            }
            catch (Exception)
            {
                Exception ex = new Exception("Error en la validacion del usuario.");
                return null;
            }
        }


        public UsuarioObj ConsultarUsuarioID (int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Usuario/ConsultarUsuarioID?id=" + id;
                    string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        //Deserialización System.Net.Http.Formatting.Extension
                        return respuesta.Content.ReadAsAsync<UsuarioObj>().Result;
                    }
                    return null;
                }
            }
            catch (Exception)
            {
                Exception ex = new Exception("Error al consultar usuario por ID.");
                return null;
            }
        }


        public UsuarioObj ActualizarUsuario(UsuarioObj obj)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Usuario/ActualizarUsuario";
                    string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    //Serialización System.Net.Http.Json;
                    JsonContent contenido = JsonContent.Create(obj);

                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    HttpResponseMessage respuesta = client.PutAsync(rutaApi, contenido).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        //Deserialización System.Net.Http.Formatting.Extension
                        return respuesta.Content.ReadAsAsync<UsuarioObj>().Result;
                    }
                    return null;
                }
            }
            catch (Exception)
            {
                Exception ex = new Exception("Error al actualizar usuario.");
                return null;
            }
        }

        public UsuarioObj RegistrarUsuario(UsuarioObj obj)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Usuario/RegistrarUsuario";
                    string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    //Serialización System.Net.Http.Json;
                    JsonContent contenido = JsonContent.Create(obj);

                    HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        //Deserialización System.Net.Http.Formatting.Extension
                        return respuesta.Content.ReadAsAsync<UsuarioObj>().Result;
                    }
                    return null;
                }
            }
            catch (Exception)
            {
                Exception ex = new Exception("Error al actualizar usuario.");
                return null;
            }
        }

        public UsuarioObj CambiarEstadoUsuario(UsuarioObj obj)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Usuario/CambiarEstadoUsuario";
                    string token = HttpContext.Current.Session["CodigoSeguridad"].ToString();

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    //Serialización System.Net.Http.Json;
                    JsonContent contenido = JsonContent.Create(obj);

                    HttpResponseMessage respuesta = client.PutAsync(rutaApi, contenido).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        //Deserialización System.Net.Http.Formatting.Extension
                        return respuesta.Content.ReadAsAsync<UsuarioObj>().Result;
                    }
                    return null;
                }
            }
            catch (Exception)
            {
                Exception ex = new Exception("Error al cambiar estado del usuario.");
                return null;
            }
        }


        public bool NuevoRegistro(UsuarioObj usuario) {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Usuario/NuevoRegistro";

                    //Serialización System.Net.Http.Json;
                    JsonContent contenido = JsonContent.Create(usuario);

                    HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;
                    if (respuesta.IsSuccessStatusCode)
                    {
                        var textoRespuesta = respuesta.Content.ReadAsAsync<string>().Result;
                        if (textoRespuesta == null)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            catch (Exception)
            {
                Exception ex = new Exception("Error al registrar nuevo usuario.");
                return false;
            }
        }
    }

   
}
