﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AnimalsViewer.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AnimalsEntities : DbContext
    {
        public AnimalsEntities()
            : base("name=AnimalsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Animal> Animal { get; set; }
        public DbSet<AnimalType> AnimalType { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<SkinColor> SkinColor { get; set; }
    }
}
