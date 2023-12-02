using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MiniSuperPF_YustinA.Models
{
    public class User
    {
        public RestRequest Request { get; set; }
       

        public User() 
        { 
        
        }
        public int UserId { get; set; } 
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? CardId { get; set; }
        public string LoginPassword { get; set; } = null!;
        public string? Address { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public int UserRoleId { get; set; }
        public int UserStatusId { get; set; }

        public virtual UserRole? UserRole { get; set; } = null!;
        public virtual UserStatus? UserStatus { get; set; } = null!;



        //funciones

        public async Task<bool> ValidateLogin()
        {
            try
            {
                string RouteSufix = string.Format("Users/ValidateUserLogin?pUserName={0}&pPassword={1}",this.Email, this.LoginPassword);

                string URL = Services.Connection.ProductionURLPrefix + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

                //agrego la info del ApiKey

                Request.AddHeader(Services.Connection.KeyName, Services.Connection.KeyValue);
                Request.AddHeader(GlobalObjects.contenttype, GlobalObjects.minetype);

                RestResponse response= await client.ExecuteAsync(Request);
          
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
        public async Task<bool> AddUser()
        {
            try
            {
                string RouteSufix = string.Format("Users");

                string URL = Services.Connection.ProductionURLPrefix + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Post);

                //agrego la info del ApiKey

                Request.AddHeader(Services.Connection.KeyName, Services.Connection.KeyValue);
                Request.AddHeader(GlobalObjects.contenttype, GlobalObjects.minetype);

                string SerealizedModel = JsonConvert.SerializeObject(this);
                Request. AddBody(SerealizedModel, GlobalObjects.minetype);



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
