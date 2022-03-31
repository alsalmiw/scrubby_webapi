using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using scrubby_webapi.Models;

namespace scrubby_webapi.Services.Context
{
    public class DataContext: DbContext 
    {
         public DbSet<UserModel> UserInfo { get; set; }
         public DbSet<DependentModel> DependentInfo {get; set;}
         public DbSet<SelectedTasksModel> SelectedTasksInfo {get; set;}
         public DBSet<SelectedItemsInSpaceModel> SelectedItemsInSpaceInfo {get; set;}
         public DbSet<SpaceInfoModel> SpaceInfo { get; set; }
         public DbSet<SharedSpacesModel> SharedSpacesInfo { get; set; }
         public DbSet<SpaceCollectionModel> SpaceCollectionInfo {get; set;}
         public DbSet<AssignedTasksChildModel> AssignedTasksChildInfo {get; set;}
         
        public DataContext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedData(builder);
        }
        private void SeedData(ModelBuilder builder)
        {
            var userData = new List<UserModel>()
            {
                new UserModel(){
                    Id=1,
                    Username= "JT",
                    Salt="",
                    Hash="",
                    Photo="",
                    Coins= 5000,
                    isDeleted=false

                },
                new UserModel(){
                    Id=2,
                    Username= "Angel",
                    Salt="",
                    Hash="",
                    Photo="",
                    Coins= 1000,
                    isDeleted=false

                },
                new UserModel(){
                    Id=3,
                    Username= "Walaa",
                    Salt="",
                    Hash="",
                    Photo="",
                    Coins= 5000,
                    isDeleted=false

                },
                new UserModel(){
                    Id=4,
                    Username= "DB",
                    Salt="",
                    Hash="",
                    Photo="",
                    Coins= 50000,
                    isDeleted=false

                },
                new UserModel(){
                    Id=5,
                    Username= "Peter",
                    Salt="",
                    Hash="",
                    Photo="",
                    Coins= 15000,
                    isDeleted=false

                }
            };
            builder.Entity<UserModel>().HasData(userData);

            var spaceInfoData = new List<SpaceInfoModel>()
            {
            new SpaceInfoModel(){
                Id=1,
                SpaceName="Space Name",
                SpaceCategory="Space Category",
                collectionId =1
                },
            new SpaceInfoModel(){
                Id=2,
                SpaceName="Space Name",
                SpaceCategory="Space Category",
                collectionId =1
                },
            new SpaceInfoModel(){
                Id=3,
                SpaceName="Space Name",
                SpaceCategory="Space Category",
                collectionId =1
                },
            new SpaceInfoModel(){
                Id=4,
                SpaceName="Space Name",
                SpaceCategory="Space Category",
                collectionId =1
                },
            new SpaceInfoModel(){
                Id=5,
                SpaceName="Space Name",
                SpaceCategory="Space Category",
                collectionId =1
                },
            };
            builder.Entity<SpaceInfoModel>().HasData(spaceInfoData);

            var spaceCollectionData = new List<SpaceCollectionModel>(){
                new SpaceCollectionModel(){
                    Id=1,
                    CollectionName="Bathroom",
                    IsDeleted=false,
                    UserId=1
                },
                new SpaceCollectionModel(){
                    Id=2,
                    CollectionName="Bathroom",
                    IsDeleted=false,
                    UserId=1
                },
                new SpaceCollectionModel(){
                    Id=3,
                    CollectionName="Bathroom",
                    IsDeleted=false,
                    UserId=2
                },
                new SpaceCollectionModel(){
                    Id=4,
                    CollectionName="Bathroom",
                    IsDeleted=false,
                    UserId=3
                },
                new SpaceCollectionModel(){
                    Id=5,
                    CollectionName="Bathroom",
                    IsDeleted=false,
                    UserId=4
                }
            };
            builder.Entity<SpaceCollectionModel>().HasData(spaceCollectionData);

            var sharedSpacesData = new List<SharedSpacesModel>(){
                 new SharedSpacesModel(){
                     Id=1,
                     UserId=1
                 },
                 new SharedSpacesModel(){
                     Id=2,
                     UserId=2
                 },
                 new SharedSpacesModel(){
                     Id=3,
                     UserId=3
                 },
                 new SharedSpacesModel(){
                     Id=4,
                     UserId=4
                 },
                 new SharedSpacesModel(){
                     Id=5,
                     UserId=5
                 },
            };
            builder.Entity<SharedSpacesModel>().HasData(sharedSpacesData);

            var selectedTasksData = new List<SelectedTasksModel>(){
                new SelectedTasksModel(){
                    Id=1,
                    taskAndProductId=1,
                    DateCreated="3-30-2022",
                    DateCompleted="3-31-2022",
                    Repeat=1
                },
                new SelectedTasksModel(){
                    Id=2,
                    taskAndProductId=2,
                    DateCreated="4-1-2022",
                    DateCompleted="4-3-2022",
                    Repeat=2
                },
                new SelectedTasksModel(){
                    Id=3,
                    taskAndProductId=3,
                    DateCreated="4-10-2022",
                    DateCompleted="4-12-2022",
                    Repeat=2
                },
                new SelectedTasksModel(){
                    Id=4,
                    taskAndProductId=4,
                    DateCreated="4-20-2022",
                    DateCompleted="4-20-2022",
                    Repeat=3
                },
                new SelectedTasksModel(){
                    Id=5,
                    taskAndProductId=5,
                    DateCreated="4-21-2022",
                    DateCompleted="4-22-2022",
                    Repeat=3
                }
            };
            builder.Entity<SelectedTasksModel>().HasData(selectedTasksData);
        }
        
    }
}