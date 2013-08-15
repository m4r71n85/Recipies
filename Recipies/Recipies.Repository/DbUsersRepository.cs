using Recipies.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Recipies.Repository
{
    public class DbUsersRepository : IUserRepository<User>
    {
        private db03b09a81b82c44bcbe0ba21a008dd95cEntities dbContext;

        public DbUsersRepository(db03b09a81b82c44bcbe0ba21a008dd95cEntities dbContext)
        {
            this.dbContext = dbContext;
        }

        private string GetSessionKey(string input)
        {
            byte[] buffer = Encoding.Unicode.GetBytes(input);
            SHA1CryptoServiceProvider cryptoTransformSHA1 = new SHA1CryptoServiceProvider();
            return BitConverter.ToString(cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "");
        }

        public string Login(User item)
        {
            User user = this.dbContext.Users
                .Where(x => x.UserName == item.UserName && x.AuthCode == item.AuthCode)
                .Select(x => x).FirstOrDefault();

            if (user != null)
            {
                string sessionKey = GetSessionKey(user.UserName + user.AuthCode + DateTime.Now.ToLongTimeString());
                user.SessionKey = sessionKey;
                dbContext.SaveChanges();
                return sessionKey;
            }
            else
            {
                return null;
            }
        }

        public void Logout(string sessionKey)
        {
            User user = this.dbContext.Users
                .Where(x => x.SessionKey == sessionKey)
                .Select(x => x).FirstOrDefault();

            if (user != null)
            {
                user.SessionKey = null;
                this.dbContext.SaveChanges();
            }
        }

        public string Register(User item)
        {
            string sessionKey = GetSessionKey(item.NickName + item.AuthCode + DateTime.Now.ToLongTimeString());
            User user = this.dbContext.Users.Where(x => x.UserName == item.UserName).Select(x => x).FirstOrDefault();

            if (user != null)
            {
                return null;
            }

            this.dbContext.Users.Add(item);
            item.SessionKey = sessionKey;
            this.dbContext.SaveChanges();

            return sessionKey;
        }

        public bool Find(User item)
        {
            User user = this.dbContext.Users
                .Where(x => x.UserName == item.UserName && x.AuthCode == item.AuthCode)
                .Select(x => x).FirstOrDefault();
            if (user != null)
            {
                return true;
            }

            return false;
        }
    }
}
