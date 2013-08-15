using System;
using System.Linq;

namespace Recipies.Repository
{
    public interface IUserRepository<T>
    {
        T Login(T item);
        void Logout(string sessionKey);
        string Register(T item);
        bool Find(T item);
    }
}
