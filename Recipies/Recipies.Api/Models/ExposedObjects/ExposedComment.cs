using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recipies.Api.Models.ExposedObjects
{
    public class ExposedComment
    {
        public string Text { get; set; }
        public DateTime PostedTime { get; set; }
        public string CreatedBy { get; set; }
    }
}