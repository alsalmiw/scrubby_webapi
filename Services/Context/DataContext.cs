using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using scrubby_webapi.Models;
using scrubby_webapi.Models.Static;

namespace scrubby_webapi.Services.Context
{
    public class DataContext: DbContext 
    {
         public DbSet<UserModel> UserInfo { get; set; }
         public DbSet<DependentModel> DependentInfo {get; set;}
         
        public DataContext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

           private void SeedData(ModelBuilder builder)
        {
            var CleaningProducts = new List<CleaningProductsStaticAPIModel>()
            {
                    new CleaningProductsStaticAPIModel(){
                        Id = 1,
                        ProductName ="",
                        Instructions ="",
                        Warnings="",
                        Tags=""
                    },
                     new CleaningProductsStaticAPIModel(){
                        Id = 1,
                        ProductName ="",
                        Instructions ="",
                        Warnings="",
                        Tags=""
                    }
        
             };
             builder.Entity<CleaningProductsStaticAPIModel>().HasData(CleaningProducts);

        }
    
    }
}