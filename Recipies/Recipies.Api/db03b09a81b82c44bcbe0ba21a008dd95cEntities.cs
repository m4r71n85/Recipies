using System.Data.Entity;
using Reciepes.Data;

namespace Recipies.Api
{
	public class db03b09a81b82c44bcbe0ba21a008dd95cEntities : DbContext
	{
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<Recipies.Api.db03b09a81b82c44bcbe0ba21a008dd95cEntities>());

        public db03b09a81b82c44bcbe0ba21a008dd95cEntities() : base("name=db03b09a81b82c44bcbe0ba21a008dd95cEntities")
        {
        }

		public DbSet<User> Users { get; set; }

		public DbSet<Recipy> Recipies { get; set; }

		public DbSet<Comment> Comments { get; set; }

		public DbSet<Step> Steps { get; set; }

		public DbSet<CookingProduct> CookingProducts { get; set; }

		public DbSet<Product> Products { get; set; }

		public DbSet<StepAction> StepActions { get; set; }
	}
}
