using System;
using System.Linq;

namespace Recipies.Api.Models.ExposedObjects
{
    public class ExposedUser
    {
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string SessionKey { get; set; }
    }
}
