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
using Recipies.Data;

namespace Recipies.Api.Controllers
{
    public class StepActionsController : ApiController
    {
        private db03b09a81b82c44bcbe0ba21a008dd95cEntities db = new db03b09a81b82c44bcbe0ba21a008dd95cEntities();

        // GET api/StepActions
        public IEnumerable<StepAction> GetStepActions()
        {
            return db.StepActions.AsEnumerable();
        }

        // GET api/StepActions/5
        public StepAction GetStepAction(int id)
        {
            StepAction stepaction = db.StepActions.Find(id);
            if (stepaction == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return stepaction;
        }

        // PUT api/StepActions/5
        public HttpResponseMessage PutStepAction(int id, StepAction stepaction)
        {
            if (ModelState.IsValid && id == stepaction.Id)
            {
                db.Entry(stepaction).State = EntityState.Modified;

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

        // POST api/StepActions
        public HttpResponseMessage PostStepAction(StepAction stepaction)
        {
            if (ModelState.IsValid)
            {
                db.StepActions.Add(stepaction);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, stepaction);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = stepaction.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/StepActions/5
        public HttpResponseMessage DeleteStepAction(int id)
        {
            StepAction stepaction = db.StepActions.Find(id);
            if (stepaction == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.StepActions.Remove(stepaction);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, stepaction);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}