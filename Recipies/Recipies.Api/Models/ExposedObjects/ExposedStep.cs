using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipies.Api.Models.ExposedObjects
{
    public class ExposedStep
    {
        public int OrderOfPrecedence { get; set; }
        public int PreparationTime { get; set; }
        public string Description { get; set; }
    }
}