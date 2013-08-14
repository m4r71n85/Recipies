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
    public class StepsController : ApiController
    {
        private db03b09a81b82c44bcbe0ba21a008dd95cEntities db = new db03b09a81b82c44bcbe0ba21a008dd95cEntities();

        // GET api/Steps
        public IEnumerable<Step> GetSteps()
        {
            return db.Steps.AsEnumerable();
        }

        // GET api/Steps/5
        public Step GetStep(int id)
        {
            Step step = db.Steps.Find(id);
            if (step == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return step;
        }

        // PUT api/Steps/5
        public HttpResponseMessage PutStep(int id, Step step)
        {
            if (ModelState.IsValid && id == step.Id)
            {
                db.Entry(step).State = EntityState.Modified;

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

        // POST api/Steps
        public HttpResponseMessage PostStep(Step step)
        {
            if (ModelState.IsValid)
            {
                db.Steps.Add(step);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, step);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = step.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Steps/5
        public HttpResponseMessage DeleteStep(int id)
        {
            Step step = db.Steps.Find(id);
            if (step == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Steps.Remove(step);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, step);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}