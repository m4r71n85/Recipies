using Recipies.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipies.Repository
{
    public class DbCookingProductsRepository : GeneralRepository<CookingProduct, int>
    {
        public DbCookingProductsRepository(db03b09a81b82c44bcbe0ba21a008dd95cEntities dbContext)
            : base(dbContext)
        {
        }

        public override CookingProduct Add(CookingProduct item)
        {
            CookingProduct cookingProduct = this.dbContext.CookingProducts.Add(item);
            this.dbContext.SaveChanges();
            return cookingProduct;
        }

        public override CookingProduct Remove(int id)
        {
            CookingProduct cookingProduct = this.dbContext.CookingProducts.Remove(this.dbContext.CookingProducts.Find(id));
            this.dbContext.SaveChanges();
            return cookingProduct;
        }

        public override CookingProduct GetById(int id)
        {
            return this.dbContext.CookingProducts.Single(x => x.Id == id);
        }

        public override IEnumerable<CookingProduct> GetAll()
        {
            return this.dbContext.CookingProducts.AsEnumerable();
        }

        public override CookingProduct Find(int item)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
    }
}
