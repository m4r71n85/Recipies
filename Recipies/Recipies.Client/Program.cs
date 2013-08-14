using Reciepes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipies.Client
{
    class Program
    {
        static void Main()
        {
            RecipieContext dbContext = new RecipieContext();

            foreach (var item in dbContext.Comments)
            {
                
            }
        }
    }
}
