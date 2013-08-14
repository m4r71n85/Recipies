using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipies.Model
{
    public class User
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string SessionKey { get; set; }
        public int AuthCode { get; set; }
        public ICollection<Recipie> Recipies { get; set; }
    }
}
