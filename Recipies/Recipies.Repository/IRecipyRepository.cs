using Recipies.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipies.Repository
{
    public interface IRecipyRepository<T>
    {
        T Add(T item, string sessionKey);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Vote(int id, string sessionKey, string vote);
        bool CreateComment(int id, string sessionKey, Comment item);
        IEnumerable<Comment> ListComments(int id, string sessionKey);
    }
}
