using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipies.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual QuantityType QuantityType { get; set; }
    }
}
