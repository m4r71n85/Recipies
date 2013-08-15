using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipies.Repository
{
	public interface IRepository<T, V>
	{
		T Add(T item);
		void Update(int id, T item);
		T Remove(int id);
		T GetById(int id);
		IEnumerable<T> GetAll();
        T Find(V item);
        void Vote(int id, int? sessionKey, bool vote);
	}
}
