using System;
using System.Linq;
using System.Linq.Expressions;

namespace Recipies.Repository
{
	public interface IRepository<T>
	{
		T Add(T item);
		void Update(int id, T item);
		void Remove(int id);
		T GetById(int id);
		IQueryable<T> GetAll();
	}
}
