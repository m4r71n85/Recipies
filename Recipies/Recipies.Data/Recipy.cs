//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Recipies.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Recipy
    {
        public Recipy()
        {
            this.Comments = new HashSet<Comment>();
            this.Steps = new HashSet<Step>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public Nullable<int> User_UserID { get; set; }
        public string Description { get; set; }
        public string ImagesFolderUrl { get; set; }
    
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Step> Steps { get; set; }
    }
}
