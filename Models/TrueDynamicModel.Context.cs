﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrueDynamicWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TrueDynamicDBEntities : DbContext
    {
        public TrueDynamicDBEntities()
            : base("name=TrueDynamicDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Url_call_track> Url_call_track { get; set; }
        public virtual DbSet<Url_Config_tabl> Url_Config_tabl { get; set; }
        public virtual DbSet<User_Data> User_Data { get; set; }
    }
}
