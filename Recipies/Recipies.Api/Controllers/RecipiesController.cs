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
//using System.Web.Http.Cors;

namespace Recipies.Api.Controllers
{
    //[EnableCors(origins: "http://myclient.azurewebsites.net", headers: "*", methods: "*")]
    public class RecipiesController : ApiController
    {
        private db03b09a81b82c44bcbe0ba21a008dd95cEntities db = new db03b09a81b82c44bcbe0ba21a008dd95cEntities();

        // GET api/Recipies
        public IEnumerable<Recipy> GetRecipies()
        {
            return db.Recipies.AsEnumerable();
        }

        // GET api/Recipies/5
        public Recipy GetRecipy(int id)
        {
            Recipy recipy = db.Recipies.Find(id);
            if (recipy == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return recipy;
        }

        // PUT api/Recipies/5
        public HttpResponseMessage PutRecipy(int id, Recipy recipy)
        {
            if (ModelState.IsValid && id == recipy.Id)
            {
                db.Entry(recipy).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
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

        // POST api/Recipies
        public HttpResponseMessage PostRecipy(Recipy recipy)
        {
            if (ModelState.IsValid)
            {
                db.Recipies.Add(recipy);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, recipy);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = recipy.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Recipies/5
        public HttpResponseMessage DeleteRecipy(int id)
        {
            Recipy recipy = db.Recipies.Find(id);
            if (recipy == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Recipies.Remove(recipy);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, recipy);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}