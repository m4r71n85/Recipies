﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Reciepes.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class db03b09a81b82c44bcbe0ba21a008dd95cEntities : DbContext
    {
        public db03b09a81b82c44bcbe0ba21a008dd95cEntities()
            : base("name=db03b09a81b82c44bcbe0ba21a008dd95cEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CookingProduct> CookingProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Recipy> Recipies { get; set; }
        public DbSet<StepAction> StepActions { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
