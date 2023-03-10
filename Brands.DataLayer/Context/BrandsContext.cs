using Brands.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brands.DataLayer.Context
{
    public class BrandsContext : DbContext
    {
        public BrandsContext(DbContextOptions<BrandsContext> options) : base(options)
        {

        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Brands.DataLayer.Entities.Brands> Brands { get; set; }
        //dbset's

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Using Fluent For User Entity :
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<User>()
                .Property(u => u.UserName)
                .HasColumnName("User Name")
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .HasColumnName("Password")
                .IsRequired()
                .HasMaxLength(200);

            //Using Fluent For Brands Entity :
            modelBuilder.Entity<Brands.DataLayer.Entities.Brands>()
               .HasKey(u => u.BrandId);

            modelBuilder.Entity<Brands.DataLayer.Entities.Brands>()
                .Property(b => b.PersianBrandName)
                .HasColumnName("Persian Brand Name")
                .IsRequired()
                .HasMaxLength(75);

            modelBuilder.Entity<Brands.DataLayer.Entities.Brands>()
                .Property(b => b.EnglishBrandName)
                .HasColumnName("English Brand Name")
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Brands.DataLayer.Entities.Brands>()
                .Property(b => b.BrandPicture)
                .HasColumnName("Picture Name of Brand")                
                .HasMaxLength(200);

            //Using Fluent for Relations:
            modelBuilder.Entity<Brands.DataLayer.Entities.Brands>()
                .HasOne<User>(f => f.Users)
                .WithMany(f => f.Brands)
                .HasForeignKey(f => f.UserId);


            
            
            //The below block implement IsDelete field by Query Filter in the brands table :
            modelBuilder.Entity<Brands.DataLayer.Entities.Brands>()
                .HasQueryFilter(u => !u.IsDelete);

            base.OnModelCreating(modelBuilder);


        }

    }
}
