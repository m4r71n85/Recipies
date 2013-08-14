using Reciepes.Data;
using Recipies.Repository;
using System;
using System.Linq;

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

            rep.Add(new User
                {
                    UserID = 200,
                    UserName = "pesho",
                    AuthCode = 32
                });

            var data = rep.GetAll();
            foreach (var item in data)
            {
                Console.WriteLine(item.UserName);
            }
        }
    }
}
