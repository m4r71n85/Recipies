using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipies.Model
{
    public class CookingProduct
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        public decimal Amount { get; set; }
    }
}
