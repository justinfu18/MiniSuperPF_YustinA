using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MiniSuperPF_YustinA.Models
{
     public class Service
    {
        public RestRequest Request { get; set; }


        public int ServiceId { get; set; }
        public DateTime CreationDate { get; set; }
        public string? Notes { get; set; }
        public int UserId { get; set; }
        public int AttentionId { get; set; }
        public int ScheduleId { get; set; }
        public int ServiceStatusId { get; set; }
        public DateTime ServiceDate { get; set; }
        public int? ServiceStart { get; set; }
        public int? ServiceEnd { get; set; }

        public virtual Attention Attention { get; set; } = null!;
        public virtual Schedule Schedule { get; set; } = null!;
        public virtual ServiceStatus ServiceStatus { get; set; } = null!;
        public virtual User User { get; set; } = null!;

        //Funciones
        public async Task<ObservableCollection<Service>> GetServiceListByUser()
        {
            try
            {
                string RouteSufix = string.Format("Services/GetServiceListByUser?pUserID={0}", this.UserId);

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
                    var ServiceList = JsonConvert.DeserializeObject<ObservableCollection<Service>>(response.Content);
                    return ServiceList;

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
