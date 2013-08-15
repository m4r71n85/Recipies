using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recipies.Api.Models.ExposedObjects
{
    public class ExposedRecipy
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public string ImagesFolder { get; set; }
        public int CookingMinutes { get; set; }
        public string CreatedBy { get; set; }
    }
}