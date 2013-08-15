using System;
using System.Linq;

namespace Recipies.Api.Models.ExposedObjects
{
    public class ExposedRecipy
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public string ImagesFolder { get; set; }
        public decimal CookingMinutes { get; set; }
        public string CreatedBy { get; set; }
		public int RecipyID { get; set;  }
    }
}