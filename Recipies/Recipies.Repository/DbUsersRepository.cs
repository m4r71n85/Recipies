//using Reciepes.Data;
//using Recipies.Model;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Recipies.Repository
//{
//	public class DbUsersRepository : IRepository<User>
//	{
//		private RecipieContext dbContext;

//		public DbUsersRepository(RecipieContext dbContext)
//		{
//			this.dbContext = dbContext;
//		}

//		public User Add(User item)
//		{
//			User returnedUser = this.dbContext.Users.Add(item);
//			this.dbContext.SaveChanges();
//			return returnedUser;
//		}

//		public void Update(int id, User item)
//		{
//			this.dbContext.Entry(item).State = EntityState.Modified;
//		}

//		public void Remove(int id)
//		{
//			this.dbContext.Users.Remove(this.dbContext.Users.Find(id));
//		}

//		public User GetById(int id)
//		{
//			return this.dbContext.Users.Where(x => x.UserID == id).Select(x => x).FirstOrDefault();
//		}

//		public IQueryable<User> GetAll()
//		{
//			return this.dbContext.Users;
//		}
//	}
//}
