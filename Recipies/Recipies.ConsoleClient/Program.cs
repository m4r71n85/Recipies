using Reciepes.Data;
using Recipies.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipies.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            db03b09a81b82c44bcbe0ba21a008dd95cEntities dbContext = new db03b09a81b82c44bcbe0ba21a008dd95cEntities();
            IRepository<User, string> rep = new DbUsersRepository(dbContext);
            rep.Add(new User
                {
                    UserID = 100,
                    UserName = "gosho",
                    AuthCode = 438
                });


        }
    }
}
