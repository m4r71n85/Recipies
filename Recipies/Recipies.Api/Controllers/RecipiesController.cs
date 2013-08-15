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
                    CreatedBy = recipyEntity.User.UserName
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
                CookingMinutes = recipy.Steps.AsEnumerable<Step>().Sum(x => x.PreparationTime.Minutes),
                Rating = recipy.Rating,
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
                        PreparationTime = step.PreparationTime.Minutes,
                        OrderOfPrecedence = orderIndex++
                    }
            };


            return expRecipy;
        }

        // PUT api/Recipies/5
        public HttpResponseMessage PutRecipy(int id, int? sessionkey, [FromBody]bool vote)
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
        public HttpResponseMessage PostRecipy(int userId, Recipy recipy)
        {
            if (ModelState.IsValid)
            {
                recipy.User_UserID = userId;
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