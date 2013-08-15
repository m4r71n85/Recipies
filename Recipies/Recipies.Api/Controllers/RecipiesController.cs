using System;
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
        private IRecipyRepository<Recipy> repository;

        public RecipiesController(IRecipyRepository<Recipy> repository)
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
                    CookingMinutes = recipyEntity.Steps.AsEnumerable<Step>().Sum(x => x.PreparationTime),
                    CreatedBy = recipyEntity.User.UserName,
					RecipyID = recipyEntity.Id
                };

            return recipyModels.AsEnumerable();
        }

        // GET api/Recipies/5
        public ExposedRecipyExtended GetRecipy(int id)
        {
            Recipy recipy = this.repository.GetById(id);
            if (recipy == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            int orderIndex = 0;
            ExposedRecipyExtended expRecipy = new ExposedRecipyExtended()
            {
                Name = recipy.Name,
                Description = recipy.Description,
                CreatedBy = recipy.User.UserName,
                CookingMinutes = recipy.Steps.AsEnumerable<Step>().Sum(x => x.PreparationTime),
                Rating = recipy.Rating,
				RecipyID = recipy.Id,
                ImagesFolder = recipy.ImagesFolderUrl,
                Comments =
                    from comment in recipy.Comments
                    select new ExposedComment()
                    {
                        PostedTime = comment.PostedTime,
                        Text = comment.Text,
                        CreatedBy = comment.User.UserName
                    },
                Steps =
                    from step in recipy.Steps
                    select new ExposedStep()
                    {
                        Description = step.Description,
                        PreparationTime = step.PreparationTime,
                        OrderOfPrecedence = orderIndex++
                    }
            };


            return expRecipy;
        }

        // PUT api/Recipies/5
        public HttpResponseMessage PutRecipy(int id, string sessionkey, [FromBody]string vote)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.repository.Vote(id, sessionkey, vote);
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

        // POST api/Recipies/5
        public HttpResponseMessage PostRecipy(string sessionKey, Recipy recipy)
        {
            if (ModelState.IsValid)
            {
                Recipy retRecipy = this.repository.Add(recipy, sessionKey);
                if (retRecipy != null)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, recipy);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = recipy.Id }));
                    return response;
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}