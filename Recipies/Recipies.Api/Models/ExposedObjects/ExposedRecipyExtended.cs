using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recipies.Api.Models.ExposedObjects
{
    public class ExposedRecipyExtended : ExposedRecipy
    {
        IEnumerable<ExposedComment> comments;
        IEnumerable<ExposedStep> steps;

        public ExposedRecipyExtended()
        {
            comments = new HashSet<ExposedComment>();
            steps = new HashSet<ExposedStep>();
        }

        public string Description { get; set; }

        public IEnumerable<ExposedComment> Comments
        {
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }

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