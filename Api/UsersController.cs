using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Api.Models;

namespace Api
{
    public class UsersController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(IEnumerable<User>))]
        public HttpResponseMessage Get()
        {
            IList<User> list = new List<User>()
            {
                new User
                {
                    Username = "user",
                    Password = "1235"
                }
            };
//            using (var context = new ShelterDbContext())
//            {
//                list = context.MonitoredUserStates.ToList();
//            }

            return Request.CreateResponse(HttpStatusCode.OK, list);
        }
    }
}