
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeApp.Model.Request;
using EmployeeApp.Model.Responce;
namespace EmployeeApp.DAL.EmployeeDBContext
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options): base(options) 
        { 
        
        
        }

        public DbSet<EmployeeData> EmployeeData { get; set; }
        public DbSet<EmployeeDataResponce> EmployeeDataResponce { get; set; }
        public DbSet<Role> Role { get; set; }
        //public DbSet<EmployeeDataResponce_v1> EmployeeDataResponce_v1 { get; set; }
        //public DbSet<EmployeeInfo> EmployeeInfo { get; set; }
        //public DbSet<Roles> Roles { get; set; }
        public DbSet<Season_Master> Season_Master { get; set; }
        public DbSet<CropMaster> CropMaster { get; set; }
        public DbSet <ProductMaster> ProductMaster { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeData>().HasKey(e => e.EMPId); ;
            modelBuilder.Entity<Role>();
            modelBuilder.Entity<EmployeeDataResponce>().HasKey(e => e.EMPId);

            //modelBuilder.Entity<CropMaster>();
            modelBuilder.Entity<Season_Master>();
            modelBuilder.Entity<CropMaster>()
           .HasOne(p => p.Season_Master)
           .WithMany(c => c.CropMaster)
           .HasForeignKey(p => p.SeasonId)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductMaster>()
           .HasOne(p => p.CropMaster)
           .WithMany(c => c.ProductMaster)
           .HasForeignKey(p => p.CropId)
           .OnDelete(DeleteBehavior.Restrict);
            //.OnDelete(DeleteBehavior.Cascade); // or SetNull/Restrict
          //  modelBuilder.Entity<Season_Master>();


        }
    }
}
