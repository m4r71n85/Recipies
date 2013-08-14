using Recipies.Data;
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
                    AuthCode = "c9fd84364bacccb70bdeb47de3b9ca66489afcf5" // hash sha1 -> goshoTestPassword
                });

            rep.Add(new User
                {
                    UserID = 200,
                    UserName = "pesho",
                    AuthCode = "e146f71c858ab5ca472541878c604686ba7a152b" // hash sha1 -> peshoTestPassword
                });

            var data = rep.GetAll();
            foreach (var item in data)
            {
                Console.WriteLine(item.UserName);
            }
        }
    }
}
