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
    
    public partial class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public System.DateTime PostedTime { get; set; }
        public Nullable<int> Recepie_Id { get; set; }
        public Nullable<int> User_UserID { get; set; }
    
        public virtual Recipy Recipy { get; set; }
        public virtual User User { get; set; }
    }
}