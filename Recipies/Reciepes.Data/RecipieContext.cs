using Recipies.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reciepes.Data
{
    public class RecipieContext : DbContext
    {
        public RecipieContext()
            : base("RecipiesDb")
        {

        }

        public DbSet<User> Places { get; set; }

        public DbSet<Step> Steps { get; set; }

        public DbSet<Recipie> Recipies { get; set; }

        public DbSet<StepAction> StepsAction { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
