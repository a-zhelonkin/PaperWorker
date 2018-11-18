using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Api.Models;
using Database;

namespace Api.Controllers
{
    public class UsersController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(IEnumerable<User>))]
        public IHttpActionResult Get()
        {
            using (var context = new PaperWorkerDbContext())
            {
                return Ok(context.Users.ToList());
            }
        }
    }
}