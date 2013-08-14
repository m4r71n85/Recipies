using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recipies.Model
{
    public class Step
    {
        public int Id { get; set; }
        public virtual Recipie Recepie { get; set; }
        public int OrderOfPrecedence { get; set; }
        public virtual StepAction StepAction { get; set; }
        public DateTime PreparationTime { get; set; }
        public int Degrees { get; set; }
        public virtual ICollection<CookingProduct> CookingProducts { get; set; }

        public Step()
        {
            this.CookingProducts = new HashSet<CookingProduct>();
        }
    }
}
