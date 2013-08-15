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

        // POST api/Users?login=true
        public HttpResponseMessage Login(User user, string login)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string sessionKey = null;
                    if (login == "true")
                    {
                        sessionKey = this.repository.Login(user);
                    }

                    if (sessionKey == null)
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest);
                    }

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, sessionKey);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = user.UserID }));
                    return response;
                }
                catch (Exception)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Users
        public HttpResponseMessage Register(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string sessionKey = this.repository.Register(user);

                    if (sessionKey == null)
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Username already exists.");
                    }

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, sessionKey);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = user.UserID }));
                    return response;
                }
                catch (Exception)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Users/5
		public HttpResponseMessage Logout(string sessionKey)
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