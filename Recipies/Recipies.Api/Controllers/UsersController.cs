using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Reciepes.Data;
using Recipies.Repository;
using System.Web.Http.Cors;

namespace Recipies.Api.Controllers
{
    [EnableCors(origins: "http://myclient.azurewebsites.net", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        private IRepository<User, string> repository;

        public UsersController(IRepository<User, string> repository)
        {
            this.repository = repository;
        }

        // GET api/Users
        public IEnumerable<User> GetUsers()
        {
            return this.repository.GetAll();
        }

        // GET api/Users/5
		public User GetUser(int id)
        {
            User user = this.repository.GetById(id);
            if (user == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return user;
        }

        // PUT api/Users/5
        public HttpResponseMessage PutUser(int id, User user)
        {
            if (ModelState.IsValid && id == user.UserID)
            {
                try
                {
                    this.repository.Update(id, user);
                }
                catch (DBConcurrencyException)
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
                this.repository.Add(user);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, user);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = user.UserID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Users/5
		public HttpResponseMessage DeleteUser(int id)
        {
            User user = null;
            try
            {
                user = this.repository.Remove(id);
                if (user == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
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