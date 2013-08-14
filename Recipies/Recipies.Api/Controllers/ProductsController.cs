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
using Recipies.Model;
using Reciepes.Data;

namespace Recipies.Api.Controllers
{
    public class ProductsController : ApiController
    {
        private RecipieContext db = new RecipieContext();

        // GET api/Products
        public IEnumerable<Recipie> GetRecipies()
        {
            return db.Recipies.AsEnumerable();
        }

        // GET api/Products/5
        public Recipie GetRecipie(int id)
        {
            Recipie recipie = db.Recipies.Find(id);
            if (recipie == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return recipie;
        }

        // PUT api/Products/5
        public HttpResponseMessage PutRecipie(int id, Recipie recipie)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != recipie.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(recipie).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Products
        public HttpResponseMessage PostRecipie(Recipie recipie)
        {
            if (ModelState.IsValid)
            {
                db.Recipies.Add(recipie);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, recipie);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = recipie.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Products/5
        public HttpResponseMessage DeleteRecipie(int id)
        {
            Recipie recipie = db.Recipies.Find(id);
            if (recipie == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Recipies.Remove(recipie);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, recipie);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}