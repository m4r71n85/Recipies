using Reciepes.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Recipies.Repository
{
    public class DbUsersRepository : IRepository<User,string>
    {
        private db03b09a81b82c44bcbe0ba21a008dd95cEntities dbContext;

        public DbUsersRepository(db03b09a81b82c44bcbe0ba21a008dd95cEntities dbContext)
        {
            this.dbContext = dbContext;
        }

        public User Add(User item)
        {
            User returnedUser = this.dbContext.Users.Add(item);
            this.dbContext.SaveChanges();
            return returnedUser;
        }

        public void Update(int id, User item)
        {
            this.dbContext.Entry(item).State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }

        public void Remove(int id)
        {
            this.dbContext.Users.Remove(this.dbContext.Users.Find(id));
            this.dbContext.SaveChanges();
        }

        public User GetById(int id)
        {
            return this.dbContext.Users.Where(x => x.UserID == id).Select(x => x).FirstOrDefault();
        }

        public IEnumerable<User> GetAll()
        {
            return this.dbContext.Users.AsEnumerable();
        }

        public bool Find(string userName)
        {
            this.dbContext.Users.Single(x => x.UserName == userName);
            return true;
        }
    }
}
