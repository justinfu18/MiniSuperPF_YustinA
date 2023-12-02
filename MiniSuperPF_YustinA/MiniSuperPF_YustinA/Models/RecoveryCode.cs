using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MiniSuperPF_YustinA.Models
{
    public class RecoveryCode
    {
        public RestRequest Request { get; set; }

        public int RecoveryCodeId { get; set; }
        public string Email { get; set; } = null!;
        public string RecoveryCode1 { get; set; } = null!;
        

        // public DateTime GenerateDate { get; set; }
        // public bool IsUsed { get; set; }

        public async Task<bool> ValidateRecoveryCode()
        {
            try
            {
                string RouteSufix = string.Format("RecoveryCodes/ValideteCode?pEmail={0}&pRecoveryCode={1}", this.Email, this.RecoveryCode1);

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
                    return true;

                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                string ErrorMsg = ex.Message;
                // almacernar registro de errores en bitacora

                throw;
            }
        }
        public async Task<bool> AddRecoveryCode()
        {
            try
            {
                string RouteSufix = string.Format("RecoveryCodes");

                string URL = Services.Connection.ProductionURLPrefix + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Post);

                //agrego la info del ApiKey

                Request.AddHeader(Services.Connection.KeyName, Services.Connection.KeyValue);
                Request.AddHeader(GlobalObjects.contenttype, GlobalObjects.minetype);

                string SerealizedModel = JsonConvert.SerializeObject(this);
                Request.AddBody(SerealizedModel, GlobalObjects.minetype);



                RestResponse response = await client.ExecuteAsync(Request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.Created)
                {
                    return true;

                }
                else
                {
                    return false;
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

