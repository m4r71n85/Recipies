using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Recipies.Data;
using Recipies.Api.Controllers;
using Recipies.Repository;

namespace Recipies.Api
{
    public class DbDependencyResolver: IDependencyResolver
    {
        static db03b09a81b82c44bcbe0ba21a008dd95cEntities dbContext = new db03b09a81b82c44bcbe0ba21a008dd95cEntities();
        static IRepository<User, string> usersRepository = new DbUsersRepository(dbContext);

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
            //dbContext.Dispose();
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(UsersController))
            {
                return new UsersController(usersRepository);
            }
            else
            {
                return null;
            }
        }
    }
}
