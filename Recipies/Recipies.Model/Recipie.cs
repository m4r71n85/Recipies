using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipies.Model
{
    public class Recipie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Step> PreparationSteps { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public Recipie()
        {
            this.PreparationSteps = new HashSet<Step>();
            this.Comments = new HashSet<Comment>();
        }
    }
}
