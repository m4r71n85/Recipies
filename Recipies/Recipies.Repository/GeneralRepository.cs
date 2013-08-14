using Reciepes.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Recipies.Repository
{
    public abstract class GeneralRepository<T, V> : IRepository<T, V>
        where T : class
    {
        protected db03b09a81b82c44bcbe0ba21a008dd95cEntities dbContext;

        protected GeneralRepository(db03b09a81b82c44bcbe0ba21a008dd95cEntities dbContext)
        {
            this.dbContext = dbContext;
        }

        public abstract T Add(T item);

        public void Update(int id, T item)
        {
            var entry = this.dbContext.Entry<T>(item);

            if (entry.State == EntityState.Detached)
            {
                var set = this.dbContext.Set<T>();
                T attachedEntity = set.Find(id);  // You need to have access to key

                if (attachedEntity != null)
                {
                    var attachedEntry = this.dbContext.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(item);
                }
                else
                {
                    entry.State = EntityState.Modified; // This should attach entity
                }
            }

            this.dbContext.SaveChanges();
        }

        public abstract T Remove(int id);

        public abstract T GetById(int id);

        public abstract IEnumerable<T> GetAll();

        public abstract T Find(V item);
    }
}
