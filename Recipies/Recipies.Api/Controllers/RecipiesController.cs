﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Recipies.Api.Models.ExposedObjects;
using Recipies.Data;
using Recipies.Repository;
using System.Web.Http.Cors;

namespace Recipies.Api.Controllers
{
    [EnableCors(origins: "http://recepiesclient.apphb.com", headers: "*", methods: "*")]
    public class RecipiesController : ApiController
    {
        private IRepository<Recipy, string> repository;

        public RecipiesController(IRepository<Recipy, string> repository)
        {
            this.repository = repository;
        }

        // GET api/Recipies
        public IEnumerable<ExposedRecipy> GetRecipies()
        {
            var recipyEntities = this.repository.GetAll();

            var recipyModels =
                from recipyEntity in recipyEntities
                select new ExposedRecipy()
                {
                    Name = recipyEntity.Name,
                    Rating = recipyEntity.Rating,
                    ImagesFolder = recipyEntity.ImagesFolderUrl,
                    CookingMinutes = recipyEntity.Steps.AsEnumerable<Step>().Sum(x => x.PreparationTime.Minutes),
                    User = new ExposedUser()
                    {
                        Name = recipyEntity.User.NickName
                    }
                };

            return recipyModels.AsEnumerable();
        }

        // GET api/Recipies/5
        public Recipy GetRecipy(int id)
        {
            Recipy recipy = this.repository.GetById(id);
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
                try
                {
                    this.repository.Update(id, recipy);
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

        // POST api/Recipies
        public HttpResponseMessage PostRecipy(Recipy recipy)
        {
            if (ModelState.IsValid)
            {
                this.repository.Add(recipy);
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
            Recipy recipy = null;
            try
            {
                recipy = this.repository.Remove(id);
                if (recipy == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, recipy);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}