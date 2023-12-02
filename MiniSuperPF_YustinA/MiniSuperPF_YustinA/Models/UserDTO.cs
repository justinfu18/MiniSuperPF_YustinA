using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MiniSuperPF_YustinA.Models
{
    public class UserDTO
    {
        public RestRequest Request { get; set; }

      
        
        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string? Cedula { get; set; }
        public string Contrasennia { get; set; } = null!;
        public string? Direccion { get; set; }
        public string NumeroTelefono { get; set; } = null!;
        public int IdRol { get; set; }
        public int IdEstado { get; set; }

        public string EstadoDescripcion { get; set; } = null!;
        public string RolDescripcion { get; set; } = null!;

        public async Task<UserDTO> GetUserData(string email)
        {
            try
            {
                string RouteSufix = string.Format("Users/GetUserData?email={0}", email);

                string URL = Services.Connection.ProductionURLPrefix + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

                //agrego la info del ApiKey

                Request.AddHeader(Services.Connection.KeyName, Services.Connection.KeyValue);
                Request.AddHeader(GlobalObjects.contenttype, GlobalObjects.minetype);

                RestResponse response = await client.ExecuteAsync(Request);

                HttpStatusCode statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.OK)
                {
                    var list = JsonConvert.DeserializeObject<List<UserDTO>>(response.Content);
                    var item = list[0];

                    return item ;

                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                string ErrorMsg = ex.Message;
                // almacernar registro de errores en bitacora

                throw;
            }
        }




    }
    
}
    