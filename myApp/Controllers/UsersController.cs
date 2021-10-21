using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;

namespace myApp.Controllers
{
    public class UsersController : ApiController
    {

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        public HttpResponseMessage GetUser(int userID)
        {
            try
            {
                shamamsaAppEntities entity = new shamamsaAppEntities();

                var getUser = entity.getUser(userID);
                var json = JsonConvert.SerializeObject(getUser);
                var response = this.Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
                return response;
            }

            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }


        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public HttpResponseMessage CreateUser(App_Start.NewUser user)
        {
            try
            {
                shamamsaAppEntities entity = new shamamsaAppEntities();

                var getUser = entity.createUser(user.userName, user.age, user.dateOfBirth, user.Address);
                var json = JsonConvert.SerializeObject(getUser);
                var response = this.Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
                return response;
            }

            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
    }
}
