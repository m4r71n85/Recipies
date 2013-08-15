//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Recipies.Data;

//namespace Recipies.Repository
//{
//    public class DbStepsRepository : GeneralRepository<Step, int>
//    {
//        public DbStepsRepository(db03b09a81b82c44bcbe0ba21a008dd95cEntities dbContext)
//            : base(dbContext)
//        {
//        }

//        public override Step Add(Step item)
//        {
//            Step step = this.dbContext.Steps.Add(item);
//            this.dbContext.SaveChanges();
//            return step;
//        }

//        public override Step Remove(int id)
//        {
//            Step step = this.dbContext.Steps.Remove(this.dbContext.Steps.Find(id));
//            this.dbContext.SaveChanges();
//            return step;
//        }

//        public override Step GetById(int id)
//        {
//            return this.dbContext.Steps.Single(x => x.Id == id);
//        }

//        public override IEnumerable<Step> GetAll()
//        {
//            return this.dbContext.Steps.AsEnumerable();
//        }

//        public override Step Find(int item)
//        {
//            throw new NotImplementedException(); 
//        }
//    }
//}
