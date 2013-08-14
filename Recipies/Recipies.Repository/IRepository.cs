using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Recipies.Repository
{
	public interface IRepository<T, V>
	{
		T Add(T item);
		void Update(int id, T item);
		void Remove(int id);
		T GetById(int id);
		IEnumerable<T> GetAll();
        bool Find(V item);
	}
}
