using System;
using System.Collections.Generic;
using System.Linq;
using Recipies.Data;

namespace Recipies.Repository
{
    public class DbProductsRepository : GeneralRepository<Product, int>
    {
        public DbProductsRepository(db03b09a81b82c44bcbe0ba21a008dd95cEntities dbContext)
            : base(dbContext)
        {
        }

        public override Product Add(Product item)
        {
            Product product = this.dbContext.Products.Add(item);
            this.dbContext.SaveChanges();
            return product;
        }

        public override Product Remove(int id)
        {
            Product product = this.dbContext.Products.Remove(this.dbContext.Products.Find(id));
            this.dbContext.SaveChanges();
            return product;
        }

        public override Product GetById(int id)
        {
            return this.dbContext.Products.Single(x => x.Id == id);
        }

        public override IEnumerable<Product> GetAll()
        {
            return this.dbContext.Products.AsEnumerable();
        }

        public override Product Find(int item)
        {
            throw new NotImplementedException();
        }
    }
}
