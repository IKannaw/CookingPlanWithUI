﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CookingPlanWithUI.DataModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CookingPlanEntities : DbContext
    {
        public CookingPlanEntities()
            : base("name=CookingPlanEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Curry> Curries { get; set; }
        public virtual DbSet<CurryCategory> CurryCategories { get; set; }
        public virtual DbSet<SideDish> SideDishes { get; set; }
        public virtual DbSet<SideDishCategory> SideDishCategories { get; set; }
        public virtual DbSet<Soup> Soups { get; set; }
        public virtual DbSet<SoupCategory> SoupCategories { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<TeamMember> TeamMembers { get; set; }
    }
}