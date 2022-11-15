using Microsoft.Ajax.Utilities;
using Pasteleria.Models.Objetos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;

namespace Pasteleria.Models.Modelos
{
    public class UsuarioModel
    {

        public List<UsuarioObj> UsuariosLista()
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Usuario/UsuariosLista";
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

        public UsuarioObj ValidarUsuario(UsuarioObj usuario) {
            using (HttpClient client = new HttpClient()) {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Usuario/ValidarUsuario";

                //Serialización System.Net.Http.Json;
                JsonContent contenido = JsonContent.Create(usuario);

                HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;   
                if (respuesta.IsSuccessStatusCode) {
                    var tokenRespuesta = respuesta.Content.ReadAsAsync<string>().Result;
                    if (tokenRespuesta == null) {
                        return null;
                    }
                    var jwt = new JwtSecurityTokenHandler().ReadJwtToken(tokenRespuesta);
                    string role = jwt.Claims.First(c => c.Type == ClaimTypes.Role).Value;
                    TipoUsuarioModel tipoUsuarioModel = new TipoUsuarioModel(0, role);
                    usuario.tipoUsuario = tipoUsuarioModel;
                    usuario.token = tokenRespuesta;
                    //Deserialización System.Net.Http.Formatting.Extension
                    //return respuesta.Content.ReadAsAsync<RespuestaUsuario>().Result;
                    return usuario;
                }
                return null;
            }
        }

        public bool NuevoRegistro(UsuarioObj usuario) {
            using (HttpClient client = new HttpClient()) {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Usuario/NuevoRegistro";

                //Serialización System.Net.Http.Json;
                JsonContent contenido = JsonContent.Create(usuario);

                HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;
                if (respuesta.IsSuccessStatusCode) {
                    var textoRespuesta = respuesta.Content.ReadAsAsync<string>().Result;
                    if (textoRespuesta == null) {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}