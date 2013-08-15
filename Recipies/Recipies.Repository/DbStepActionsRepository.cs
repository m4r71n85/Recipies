using System;
using System.Collections.Generic;
using System.Linq;
using Recipies.Data;

namespace Recipies.Repository
{
    public class DbStepActionsRepository : GeneralRepository<StepAction, string>
    {
        public DbStepActionsRepository(db03b09a81b82c44bcbe0ba21a008dd95cEntities dbContext)
            : base(dbContext)
        {
        }

        public override StepAction Add(StepAction item)
        {
            StepAction action = this.dbContext.StepActions.Add(item);
            this.dbContext.SaveChanges();
            return action;
        }

        public override StepAction Remove(int id)
        {
            StepAction action = this.dbContext.StepActions.Remove(this.dbContext.StepActions.Find(id));
            this.dbContext.SaveChanges();
            return action;
        }

        public override StepAction GetById(int id)
        {
            return this.dbContext.StepActions.Single(x => x.Id == id);
        }

        public override IEnumerable<StepAction> GetAll()
        {
            return this.dbContext.StepActions.AsEnumerable();
        }

        public override StepAction Find(string item)
        {
            return this.dbContext.StepActions.Single(x => x.Name == item);
        }
    }
}
