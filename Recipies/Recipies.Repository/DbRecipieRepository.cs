using System;
using System.Collections.Generic;
using System.Linq;
using Recipies.Data;

namespace Recipies.Repository
{
    public class DbRecipieRepository : GeneralRepository<Recipy, string>
    {
        public DbRecipieRepository(db03b09a81b82c44bcbe0ba21a008dd95cEntities dbContext)
            : base(dbContext)
        {
        }

        public override Recipy Add(Recipy item)
        {
            Recipy recipy = this.dbContext.Recipies.Add(item);
            this.dbContext.SaveChanges();
            return recipy;
        }

        public override Recipy Remove(int id)
        {
            Recipy recipy = this.dbContext.Recipies.Remove(this.dbContext.Recipies.Find(id));
            this.dbContext.SaveChanges();
            return recipy;
        }

        public override Recipy GetById(int id)
        {
            return this.dbContext.Recipies.Single(x => x.Id == id);
        }

        public override IEnumerable<Recipy> GetAll()
        {
            return this.dbContext.Recipies.AsEnumerable();
        }

        public override Recipy Find(string item)
        {
            return this.dbContext.Recipies.Single(x => x.Name == item);
        }
    }
}
