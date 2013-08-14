using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recipies.Model
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual Recipie Recepie { get; set; }
        public virtual User User { get; set; }
        public DateTime PostedTime { get; set; }
    }
}
