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
         public DbSet<SelectedTasksModel> SelectedTasksInfo {get; set;}
         public DBSet<SelectedItemsInSpaceModel> SelectedItemsInSpaceInfo {get; set;}
         public DbSet<SpaceInfoModel> SpaceInfo { get; set; }
         public DbSet<SharedSpacesModel> SharedSpacesInfo { get; set; }
         public DbSet<SpaceCollectionModel> SpaceCollectionInfo {get; set;}
         public DbSet<AssignedTasksChildModel> AssignedTasksChildInfo {get; set;}

         public DbSet<AssignedTasksUsersModel> AssignedTasksUsersInfo { get; set; }
         public DbSet<TasksInfoStaticAPIModel> TasksInfoStaticAPIInfo { get; set; }
         public DbSet<SpaceItemsStaticAPIModel> SpaceItemsStaticAPIInfo { get; set; }
         public DbSet<CleaningProductsStaticAPIModel> CleaningProductsStaticAPIInfo { get; set; }

         
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
                    CollectionName="Smith House",
                    IsDeleted=false,
                    UserId=1
                },
                new SpaceCollectionModel(){
                    Id=2,
                    CollectionName="Storage Shed",
                    IsDeleted=false,
                    UserId=1
                },
                new SpaceCollectionModel(){
                    Id=3,
                    CollectionName="Paris Home",
                    IsDeleted=false,
                    UserId=2
                },
                new SpaceCollectionModel(){
                    Id=4,
                    CollectionName="Work Office",
                    IsDeleted=false,
                    UserId=3
                },
                new SpaceCollectionModel(){
                    Id=5,
                    CollectionName="Shed",
                    IsDeleted=false,
                    UserId=4
                }
            };
            builder.Entity<SpaceCollectionModel>().HasData(spaceCollectionData);

            var sharedSpacesData = new List<SharedSpacesModel>(){
                 new SharedSpacesModel(){
                     Id=1,
                     UserId=1,
                    isDeleted=false,
                    isAccepted=true
                 },
                 new SharedSpacesModel(){
                     Id=2,
                     UserId=2,
                     isDeleted=false,
                    isAccepted=true
                 },
                 new SharedSpacesModel(){
                     Id=3,
                     UserId=3,
                     isDeleted=true,
                    isAccepted=true
                 },
                 new SharedSpacesModel(){
                     Id=4,
                     UserId=4,
                     isDeleted=true,
                    isAccepted=true
                 },
                 new SharedSpacesModel(){
                     Id=5,
                     UserId=5,
                     isDeleted=false,
                    isAccepted=true
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
                    DateCompleted="",
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
                    DateCompleted="",
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

            var selectedItemsInSpaceData = new List<SelectedItemsInSpaceModel>()
            {
                new SelectedItemsInSpaceModel(){
                    Id=1,
                    SpaceId=1,
                    isDeleted=true
                },
                new SelectedItemsInSpaceModel(){
                    Id=2,
                    SpaceId=2,
                    isDeleted=false
                },
                new SelectedItemsInSpaceModel(){
                    Id=3,
                    SpaceId=3,
                    isDeleted=true
                },
                new SelectedItemsInSpaceModel(){
                    Id=4,
                    SpaceId=4,
                    isDeleted=false
                },
                new SelectedItemsInSpaceModel(){
                    Id=5,
                    SpaceId=5,
                    isDeleted=true
                }
            };
            builder.Entity<SelectedItemsInSpaceModel>().HasData(selectedItemsInSpaceData);

            var dependentData = new List<DependentModel>(){

                new DependentModel(){
                    Id=1,
                    UserId=1,
                    DependentName="Taylor",
                    DependentAge=11,
                    DependentPhoto="",
                    DependentCoins=5000,
                    isDeleted=false
                },
                new DependentModel(){
                    Id=2,
                    UserId=1,
                    DependentName="Sammy",
                    DependentAge=8,
                    DependentPhoto="",
                    DependentCoins=2000,
                    isDeleted=false
                },
                new DependentModel(){
                    Id=3,
                    UserId=1,
                    DependentName="Jeff",
                    DependentAge=15,
                    DependentPhoto="",
                    DependentCoins=100,
                    isDeleted=true
                },
                new DependentModel(){
                    Id=4,
                    UserId=1,
                    DependentName="Jessica",
                    DependentAge=8,
                    DependentPhoto="",
                    DependentCoins=7000,
                    isDeleted=false
                },
                new DependentModel(){
                    Id=5,
                    UserId=2,
                    DependentName="Tony",
                    DependentAge=17,
                    DependentPhoto="",
                    DependentCoins=4000,
                    isDeleted=false
                },
            };
            builder.Entity<DependentModel>().HasData(dependentData);

            var cleaningProductsStaticAPIData = new List<CleaningProductsStaticAPIModel>(){

                new CleaningProductsStaticAPIModel(){
                    Id=1,
                    ProductName="Window Wipers",
                    Instructions="Spray compound onto window and wipe with a clean towel",
                    Warnings="HARMFUL IF SWALLOWED. SKIN AND EYE IRRITANT.",
                    TasksTags="Window, Mirror"
                },
                new CleaningProductsStaticAPIModel(){
                    Id=2,
                    ProductName="Bleach",
                    Instructions="Spray compound onto surface and scurb with a sponge",
                    Warnings="HARMFUL IF SWALLOWED. SKIN AND EYE IRRITANT.",
                    TasksTags="Toilet, Shower, Bathtub"
                },
                new CleaningProductsStaticAPIModel(){
                    Id=3,
                    ProductName="Dish Detergents",
                    Instructions="Squeeze onto a sponge",
                    Warnings="HARMFUL IF SWALLOWED. SKIN AND EYE IRRITANT.",
                    TasksTags="Dishes"
                },
                new CleaningProductsStaticAPIModel(){
                    Id=4,
                    ProductName="Floor Detergents",
                    Instructions="Pour into a bucket of warm water and stir until product is mixed",
                    Warnings="HARMFUL IF SWALLOWED. SKIN AND EYE IRRITANT.",
                    TasksTags="Floor"
                },
                new CleaningProductsStaticAPIModel(){
                    Id=5,
                    ProductName="Window Wipers",
                    Instructions="Spray compound onto window and wipe with a clean towel",
                    Warnings="HARMFUL IF SWALLOWED. SKIN AND EYE IRRITANT.",
                    TasksTags="Window, Mirror"
                },
            };
            builder.Entity<CleaningProductsStaticAPIModel>().HasData(cleaningProductsStaticAPIData);

            var AssignedTasksUsersData = new List<AssignedTasksUsersModel>(){

                new AssignedTasksUsersModel(){
                    Id=1,
                    UserIdTasked=4,
                    UserIdOwner=4,
                    SelectedTasksId=5,
                    DateCreated="4-21-2022",
                    DateCompleted="4-22-2022",
                    Repeat=2
                },
                new AssignedTasksUsersModel(){
                    Id=2,
                    UserIdTasked=3,
                    UserIdOwner=3,
                    SelectedTasksId=3,
                    DateCreated="4-10-2022",
                    DateCompleted="4-12-2022",
                    Repeat=3
                },
                new AssignedTasksUsersModel(){
                    Id=3,
                    UserIdTasked=1,
                    UserIdOwner=1,
                    SelectedTasksId=2,
                    DateCreated="4-1-2022",
                    DateCompleted="4-3-2022",
                    Repeat=1
                },
                new AssignedTasksUsersModel(){
                    Id=4,
                    UserIdTasked=2,
                    UserIdOwner=2,
                    SelectedTasksId=4,
                    DateCreated="4-20-2022",
                    DateCompleted="4-20-2022",
                    Repeat=1
                },
                new AssignedTasksUsersModel(){
                    Id=5,
                    UserIdTasked=2,
                    UserIdOwner=2,
                    SelectedTasksId=1,
                    DateCreated="3-30-2022",
                    DateCompleted="3-31-2022",
                    Repeat=2
                }
            };
            builder.Entity<AssignedTasksUsersModel>().HasData(AssignedTasksUsersData);

            
            var assignedTasksChildData = new List<AssignedTasksChildModel>() {
                new AssignedTasksChildModel() {
                    Id=1,
                    UserId=1,
                    SelectedTasksId=1,
                    DateCreated="03/30/2022",
                    DateCompleted="04/02/2022",
                    IsDeleted=false,
                    Repeat= 1
                },
                new AssignedTasksChildModel() {
                    Id=2,
                    UserId=2,
                    SelectedTasksId=2,
                    DateCreated="03/31/2022",
                    DateCompleted="04/03/2022",
                    IsDeleted=false,
                    Repeat= 1
                },
                new AssignedTasksChildModel() {
                    Id=3,
                    UserId=3,
                    SelectedTasksId=3,
                    DateCreated="04/01/2022",
                    DateCompleted="04/04/2022",
                    IsDeleted=false,
                    Repeat= 2
                },
                new AssignedTasksChildModel() {
                    Id=4,
                    UserId=4,
                    SelectedTasksId=4,
                    DateCreated="04/02/2022",
                    DateCompleted="04/05/2022",
                    IsDeleted=false,
                    Repeat= 3
                },
                new AssignedTasksChildModel() {
                    Id=5,
                    UserId=5,
                    SelectedTasksId=5,
                    DateCreated="04/03/2022",
                    DateCompleted="04/06/2022",
                    IsDeleted=false,
                    Repeat= 2
                }
            };
            builder.Entity<AssignedTasksChildModel>().HasData(assignedTasksChildData);
            
            var spaceItemsStaticAPIData = new List<SpaceItemsStaticAPIModel>() {
                new SpaceItemsStaticAPIModel() {
                    Id=1,
                    Name="Chair",
                    Description="A chair that is brown",
                    Tags="wood, living room, bedroom, office ",
                },
                new SpaceItemsStaticAPIModel() {
                    Id=2,
                    Name="Lamp",
                    Description="A lamp that is shiny",
                    Tags="bright, metal, living room, bedroom, office ",
                },
                new SpaceItemsStaticAPIModel() {
                    Id=3,
                    Name="Table",
                    Description="A round table",
                    Tags="wood, living room, bedroom, office, kitchen",
                },
                new SpaceItemsStaticAPIModel() {
                    Id=4,
                    Name="Rug",
                    Description="A rug that is fluffy",
                    Tags="carpet, fluffy, living room, bedroom",
                },
                new SpaceItemsStaticAPIModel() {
                    Id=5,
                    Name="Bed",
                    Description="A water bed",
                    Tags="slippery, wet, bedroom",
                },
            };
            builder.Entity<SpaceItemsStaticAPIModel>().HasData(spaceItemsStaticAPIData);

            var tasksInfoStaticAPIData = new List<TasksInfoStaticAPIModel>() {
                new TasksInfoStaticAPIModel() {
                    Id=1,
                    Name="Clean toilet",
                    Description="Clean the toilet using wax on and wax off",
                    Tags="tile, slippery",
                    Time="15 min",
                    coins=20
                },
                new TasksInfoStaticAPIModel() {
                    Id=2,
                    Name="Make bed",
                    Description="Make bed using military style",
                    Tags="sheets, pillow",
                    Time="5 min",
                    coins=10
                },
                new TasksInfoStaticAPIModel() {
                    Id=3,
                    Name="Wash dishes",
                    Description="Wash dishes by hand",
                    Tags="soap, water",
                    Time="10 min",
                    coins=15
                },
                new TasksInfoStaticAPIModel() {
                    Id=4,
                    Name="Do laundry",
                    Description="Wash clothes with one batch colors and other batch white",
                    Tags="tile, slippery",
                    Time="15 min",
                    coins=20
                },
                new TasksInfoStaticAPIModel() {
                    Id=5,
                    Name="Dust living room",
                    Description="Dust living room with swifter",
                    Tags="dust, swifter",
                    Time="5 min",
                    coins=5
                }
            };

            builder.Entity<TasksInfoStaticAPIModel>().HasData(tasksInfoStaticAPIData);


        }
        
    }
}