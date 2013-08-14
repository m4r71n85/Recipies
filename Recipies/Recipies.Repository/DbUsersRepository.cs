using Reciepes.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Recipies.Repository
{
    public class DbUsersRepository : GeneralRepository<User, string>
    {
        public DbUsersRepository(db03b09a81b82c44bcbe0ba21a008dd95cEntities dbContext)
            : base(dbContext)
        {
        }

        public override User Add(User item)
        {
            User returnedUser = this.dbContext.Users.Add(item);
            this.dbContext.SaveChanges();
            return returnedUser;
        }

        public override User Remove(int id)
        {
            User user = this.dbContext.Users.Remove(this.dbContext.Users.Find(id));
            this.dbContext.SaveChanges();
            return user;
        }

        public override User GetById(int id)
        {
            return this.dbContext.Users.Where(x => x.UserID == id).Select(x => x).FirstOrDefault();
        }

        public override IEnumerable<User> GetAll()
        {
            return this.dbContext.Users.AsEnumerable();
        }

        public override User Find(string userName)
        {
            return this.dbContext.Users.Single(x => x.UserName == userName);
        }
    }
}
