using Recipies.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipies.Repository
{
    public class DbUsersRepository : IUserRepository<User>
    {
        private db03b09a81b82c44bcbe0ba21a008dd95cEntities dbContext;

        public DbUsersRepository(db03b09a81b82c44bcbe0ba21a008dd95cEntities dbContext)
        {
            this.dbContext = dbContext;
        }

        public string Login(User item)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public void Logout(string sessionKey)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public void Register(User item)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
    }
}
