using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MiniSuperPF_YustinA.Models
{
    public class UserRole
    {
        public RestRequest Request { get; set; }

        public int UserRoleId { get; set; }
        public string UserRoleDescription { get; set; }

        //Funciones

        public async Task<List<UserRole>> GetAllUserRoleList()
        {
            try
            {
                string RouteSufix = string.Format("UserRoles");

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
                    var list = JsonConvert.DeserializeObject<List<UserRole>>(response.Content);
                    return list;

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
