using System;
using System.Linq;

namespace Recipies.Repository
{
    public interface IUserRepository<T>
    {
        string Login(T item);
        void Logout(string sessionKey);
        void Register(T item);
    }
}
