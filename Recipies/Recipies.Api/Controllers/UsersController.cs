using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Recipies.Data;
using Recipies.Repository;
using System.Web.Http.Cors;

namespace Recipies.Api.Controllers
{
    [EnableCors(origins: "http://recepiesclient.apphb.com", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        private IUserRepository<User> repository;

        public UsersController(IUserRepository<User> repository)
        {
            this.repository = repository;
        }

        // PUT api/Users/5
        public HttpResponseMessage PutUser(string sessionKey)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.repository.Logout(sessionKey);
                }
                catch (Exception)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Users
        public HttpResponseMessage PostUser(User user)
        {
            if (ModelState.IsValid)
            {
                string sessionKey = this.repository.Login(user);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, sessionKey);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = user.UserID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
        

        // DELETE api/Users/5
		public HttpResponseMessage DeleteUser(string sessionKey)
        {
            User user = null;
            try
            {
                this.repository.Logout(sessionKey);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}