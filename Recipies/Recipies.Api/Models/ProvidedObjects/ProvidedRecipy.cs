using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recipies.Api.Models.ProvidedObjects
{
    public class ProvidedRecipy
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagesFolderUrl { get; set; }
    }
}