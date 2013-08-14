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

namespace Recipies.Api.Controllers
{
    public class CookingProductController : ApiController
    {
        private db03b09a81b82c44bcbe0ba21a008dd95cEntities db = new db03b09a81b82c44bcbe0ba21a008dd95cEntities();

        // GET api/CookingProduct
        public IEnumerable<CookingProduct> GetCookingProducts()
        {
            return db.CookingProducts.AsEnumerable();
        }

        // GET api/CookingProduct/5
        public CookingProduct GetCookingProduct(int id)
        {
            CookingProduct cookingproduct = db.CookingProducts.Find(id);
            if (cookingproduct == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return cookingproduct;
        }

        // PUT api/CookingProduct/5
        public HttpResponseMessage PutCookingProduct(int id, CookingProduct cookingproduct)
        {
            if (ModelState.IsValid && id == cookingproduct.Id)
            {
                db.Entry(cookingproduct).State = EntityState.Modified;

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

        // POST api/CookingProduct
        public HttpResponseMessage PostCookingProduct(CookingProduct cookingproduct)
        {
            if (ModelState.IsValid)
            {
                db.CookingProducts.Add(cookingproduct);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, cookingproduct);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = cookingproduct.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/CookingProduct/5
        public HttpResponseMessage DeleteCookingProduct(int id)
        {
            CookingProduct cookingproduct = db.CookingProducts.Find(id);
            if (cookingproduct == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.CookingProducts.Remove(cookingproduct);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, cookingproduct);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}