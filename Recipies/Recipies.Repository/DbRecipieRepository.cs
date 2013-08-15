using System;
using System.Collections.Generic;
using System.Linq;
using Recipies.Data;

namespace Recipies.Repository
{
    public class DbRecipieRepository : IRecipyRepository<Recipy>
    {
        private db03b09a81b82c44bcbe0ba21a008dd95cEntities dbContext;

        public DbRecipieRepository(db03b09a81b82c44bcbe0ba21a008dd95cEntities dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool CreateComment(int id, string sessionKey, Comment item)
        {
            User user = this.dbContext.Users.Where(x => x.SessionKey == sessionKey).Select(x => x).FirstOrDefault();
            if (user != null)
            {
                Recipy recipy = this.dbContext.Recipies.Find(id);
                recipy.Comments.Add(item);
                user.Comments.Add(item);
                this.dbContext.Comments.Add(item);
                this.dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Recipy GetById(int id)
        {
            return this.dbContext.Recipies.Single(x => x.Id == id);
        }

        public IEnumerable<Recipy> GetAll()
        {
            return this.dbContext.Recipies.AsEnumerable();
        }

        public void Vote(int id, string sessionKey, string vote)
        {
            User user = this.dbContext.Users.Where(x => x.SessionKey == sessionKey).Select(x => x).FirstOrDefault();
            if (user != null)
            {
                Recipy recipy = this.dbContext.Recipies.Find(id);
                if (vote == "up")
                {
                    recipy.Rating++;
                }
                else
                {
                    recipy.Rating--;
                }
                this.dbContext.SaveChanges();
            }
        }

        public Recipy Add(Recipy item, string sessionKey)
        {
            User user = this.dbContext.Users.Where(x => x.SessionKey == sessionKey).Select(x => x).FirstOrDefault();
            if (user != null)
            {
                item.User = user;
                Recipy recipy = this.dbContext.Recipies.Add(item);
                this.dbContext.SaveChanges();
                return recipy;
            }
            else
            {
                return null;
            }
        }
    }
}
