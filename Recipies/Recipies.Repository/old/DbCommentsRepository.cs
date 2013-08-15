//using Recipies.Data;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace Recipies.Repository
//{
//    public class DbCommentsRepository : GeneralRepository<Comment, string>
//    {
//        public DbCommentsRepository(db03b09a81b82c44bcbe0ba21a008dd95cEntities dbContext)
//            : base(dbContext)
//        {
//        }

//        public override Comment Add(Comment item)
//        {
//            Comment comment = this.dbContext.Comments.Add(item);
//            this.dbContext.SaveChanges();
//            return comment;
//        }

//        public override Comment Remove(int id)
//        {
//            Comment comment = this.dbContext.Comments.Remove(this.dbContext.Comments.Find(id));
//            this.dbContext.SaveChanges();
//            return comment;
//        }

//        public override Comment GetById(int id)
//        {
//            return this.dbContext.Comments.Single(x => x.Id == id);
//        }

//        public override IEnumerable<Comment> GetAll()
//        {
//            return this.dbContext.Comments.AsEnumerable();
//        }

//        public override Comment Find(string item)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
