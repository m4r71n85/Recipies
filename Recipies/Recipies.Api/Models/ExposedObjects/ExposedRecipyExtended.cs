using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recipies.Api.Models.ExposedObjects
{
    public class ExposedRecipyExtended : ExposedRecipy
    {
        IEnumerable<ExposedStep> steps;

        public ExposedRecipyExtended()
        {
            steps = new HashSet<ExposedStep>();
        }

        public string Description { get; set; }

        public IEnumerable<ExposedStep> Steps
        {
            get
            {
                return this.steps;
            }
            set
            {
                this.steps = value;
            }
        }
    }
}