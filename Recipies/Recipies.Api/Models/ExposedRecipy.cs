using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recipies.Api.Models
{
    public class ExposedRecipy
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public string ImagesFolder { get; set; }

        public ExposedUser User { get; set; }
    }
}