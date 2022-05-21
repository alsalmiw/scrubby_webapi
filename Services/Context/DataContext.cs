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
         public DbSet<InviteUsersModel> InvitesInfo { get; set; }
         public DbSet<DependentModel> DependentInfo {get; set;}
         public DbSet<SelectedTasksModel> SelectedTasksInfo {get; set;}
         public DbSet<SelectedItemsInSpaceModel> SelectedItemsInSpaceInfo {get; set;}
         public DbSet<SpaceInfoModel> SpaceInfo { get; set; }
         public DbSet<SharedSpacesModel> SharedSpacesInfo { get; set; }
         public DbSet<SpaceCollectionModel> SpaceCollectionInfo {get; set;}
         public DbSet<AssignedTasksChildModel> AssignedTasksChildInfo {get; set;}
         public DbSet<AssignedTasksUsersModel> AssignedTasksUsersInfo { get; set; }
         public DbSet<TasksInfoStaticAPIModel> TasksInfoStaticAPIInfo { get; set; }
         public DbSet<SpaceItemsStaticAPIModel> SpaceItemsStaticAPIInfo { get; set; }
         public DbSet<CleaningProductsStaticAPIModel> CleaningProductsStaticAPIInfo { get; set; }

         public DbSet<DefaultCollectionModel> DefaultCollectionInfo { get; set; }

         public DbSet<DefaultCollectionDependentModel> DefaultCollectionDependentInfo { get; set; }


         
        public DataContext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedData(builder);
        }
        private void SeedData(ModelBuilder builder)
        {
            // var InvitedUsers = new List<InviteUsersModel>(){
            //      new InviteUsersModel(){
            //       Id =1,
            //       InviterId =3,
            //       InviterUsername = "Walaa",
            //       InviterFullname = "Walaa AlSalmi",
            //       InvitedId = 5,
            //       InvitedUsername ="Peter",
            //       InvitedFullname = "Peter Vang",
            //       IsAccepted =false,
            //       IsDeleted  = false,
            //      }
            //  };
            // builder.Entity<InviteUsersModel>().HasData(InvitedUsers);

            var userData = new List<UserModel>()
            {
                new UserModel(){
                    Id=1,
                    Username= "JT",
                    Name = "JT",
                    Salt ="6oyIFN+J/zb3uaje2+GP98c/WdMgNb9Rwbn3Wyi51i+OUta55QsZFkrTqbJy9hiothKp95mleCPySEZOIOcPIg==",
                    Hash  ="BBvCTG4MF3e0YvDBW7mPkimgpAOpbP7HUkNb8YRmHjM8KdNBKFRRgctlBZV/WZ0GfasEBS8qJCuPB0Z4rOalX0UuAxkqmoBznghkV+lmxmIod+25vzFPjuSYhN7QvWsfPvGf7Ze1w/qG3xQ6KBTgjTc+yKe9bcaQPFBjiYPVnM1RYsUPC3RG47Q27K2xqCOQTtdvaAUEhoDgaCLi3zyi+e750FEZ6e9y1HObs4Zsnl2Yk4AwkFZ8IZBnHlXoDyy1b1ICIG7+CggJdDkiNJxv57BRlNqijDwfE+6vBujqvr7a5kgzWgGoEMBsqLpFNv7j7sIJVBjevmyV3X8eDAY68g==",
                    Photo="https://scrubbystorage.blob.core.windows.net/scrubbystorage/avatar1.png",
                    Coins= 5000,
                    Points = 600,
                    IsDeleted=false,
                    IsChildFree=false

                },
                new UserModel(){
                    Id=2,
                    Username= "Angel",
                    Name = "Angel Pantoja",
                    Salt ="6oyIFN+J/zb3uaje2+GP98c/WdMgNb9Rwbn3Wyi51i+OUta55QsZFkrTqbJy9hiothKp95mleCPySEZOIOcPIg==",
                    Hash  ="BBvCTG4MF3e0YvDBW7mPkimgpAOpbP7HUkNb8YRmHjM8KdNBKFRRgctlBZV/WZ0GfasEBS8qJCuPB0Z4rOalX0UuAxkqmoBznghkV+lmxmIod+25vzFPjuSYhN7QvWsfPvGf7Ze1w/qG3xQ6KBTgjTc+yKe9bcaQPFBjiYPVnM1RYsUPC3RG47Q27K2xqCOQTtdvaAUEhoDgaCLi3zyi+e750FEZ6e9y1HObs4Zsnl2Yk4AwkFZ8IZBnHlXoDyy1b1ICIG7+CggJdDkiNJxv57BRlNqijDwfE+6vBujqvr7a5kgzWgGoEMBsqLpFNv7j7sIJVBjevmyV3X8eDAY68g==",
                    Photo="https://scrubbystorage.blob.core.windows.net/scrubbystorage/avatar2.png",
                    Coins= 1000,
                    Points = 1000,
                    IsDeleted=false,
                    IsChildFree=false

                },
                new UserModel(){
                    Id=3,
                    Username= "Walaa",
                    Name = "Walaa AlSalmi",
                    Salt ="6oyIFN+J/zb3uaje2+GP98c/WdMgNb9Rwbn3Wyi51i+OUta55QsZFkrTqbJy9hiothKp95mleCPySEZOIOcPIg==",
                    Hash  ="BBvCTG4MF3e0YvDBW7mPkimgpAOpbP7HUkNb8YRmHjM8KdNBKFRRgctlBZV/WZ0GfasEBS8qJCuPB0Z4rOalX0UuAxkqmoBznghkV+lmxmIod+25vzFPjuSYhN7QvWsfPvGf7Ze1w/qG3xQ6KBTgjTc+yKe9bcaQPFBjiYPVnM1RYsUPC3RG47Q27K2xqCOQTtdvaAUEhoDgaCLi3zyi+e750FEZ6e9y1HObs4Zsnl2Yk4AwkFZ8IZBnHlXoDyy1b1ICIG7+CggJdDkiNJxv57BRlNqijDwfE+6vBujqvr7a5kgzWgGoEMBsqLpFNv7j7sIJVBjevmyV3X8eDAY68g==",
                    Photo="https://scrubbystorage.blob.core.windows.net/scrubbystorage/avatar3.png",
                    Coins= 5000,
                    Points= 1000,
                    IsDeleted=false,
                    IsChildFree=false

                },
                new UserModel(){
                    Id=4,
                    Username= "DB",
                    Name = "DB",
                    Salt ="6oyIFN+J/zb3uaje2+GP98c/WdMgNb9Rwbn3Wyi51i+OUta55QsZFkrTqbJy9hiothKp95mleCPySEZOIOcPIg==",
                    Hash  ="BBvCTG4MF3e0YvDBW7mPkimgpAOpbP7HUkNb8YRmHjM8KdNBKFRRgctlBZV/WZ0GfasEBS8qJCuPB0Z4rOalX0UuAxkqmoBznghkV+lmxmIod+25vzFPjuSYhN7QvWsfPvGf7Ze1w/qG3xQ6KBTgjTc+yKe9bcaQPFBjiYPVnM1RYsUPC3RG47Q27K2xqCOQTtdvaAUEhoDgaCLi3zyi+e750FEZ6e9y1HObs4Zsnl2Yk4AwkFZ8IZBnHlXoDyy1b1ICIG7+CggJdDkiNJxv57BRlNqijDwfE+6vBujqvr7a5kgzWgGoEMBsqLpFNv7j7sIJVBjevmyV3X8eDAY68g==",
                    Photo="https://scrubbystorage.blob.core.windows.net/scrubbystorage/avatar4.png",
                    Coins= 50000,
                    Points= 50000,
                    IsDeleted=false,
                    IsChildFree=false

                },
                new UserModel(){
                    Id=5,
                    Username= "Peter",
                    Name= "Peter Vang",
                    Salt ="6oyIFN+J/zb3uaje2+GP98c/WdMgNb9Rwbn3Wyi51i+OUta55QsZFkrTqbJy9hiothKp95mleCPySEZOIOcPIg==",
                    Hash  ="BBvCTG4MF3e0YvDBW7mPkimgpAOpbP7HUkNb8YRmHjM8KdNBKFRRgctlBZV/WZ0GfasEBS8qJCuPB0Z4rOalX0UuAxkqmoBznghkV+lmxmIod+25vzFPjuSYhN7QvWsfPvGf7Ze1w/qG3xQ6KBTgjTc+yKe9bcaQPFBjiYPVnM1RYsUPC3RG47Q27K2xqCOQTtdvaAUEhoDgaCLi3zyi+e750FEZ6e9y1HObs4Zsnl2Yk4AwkFZ8IZBnHlXoDyy1b1ICIG7+CggJdDkiNJxv57BRlNqijDwfE+6vBujqvr7a5kgzWgGoEMBsqLpFNv7j7sIJVBjevmyV3X8eDAY68g==",
                    Photo="https://scrubbystorage.blob.core.windows.net/scrubbystorage/avatar5.png",
                    Coins= 15000,
                    Points= 15000,
                    IsDeleted=false,
                    IsChildFree=false

                }
            };
            builder.Entity<UserModel>().HasData(userData);

            var spaceInfoData = new List<SpaceInfoModel>()
            {
            new SpaceInfoModel(){
                Id=1,
                SpaceName="Space Name",
                SpaceCategory="Space Category",
                CollectionId =1
                },
            new SpaceInfoModel(){
                Id=2,
                SpaceName="Space Name",
                SpaceCategory="Space Category",
                CollectionId =1
                },
            new SpaceInfoModel(){
                Id=3,
                SpaceName="Space Name",
                SpaceCategory="Space Category",
                CollectionId =1
                },
            new SpaceInfoModel(){
                Id=4,
                SpaceName="Space Name",
                SpaceCategory="Space Category",
                CollectionId =1
                },
            new SpaceInfoModel(){
                Id=5,
                SpaceName="Space Name",
                SpaceCategory="Space Category",
                CollectionId =1
                },
                 new SpaceInfoModel(){
                Id=6,
                SpaceName="Master Bath",
                SpaceCategory="Bathroom",
                CollectionId =3
                },
                 new SpaceInfoModel(){
                Id=7,
                SpaceName="Kids Bedroom",
                SpaceCategory="Bedroom",
                CollectionId =3
                },
                 new SpaceInfoModel(){
                Id=8,
                SpaceName="Kitchen",
                SpaceCategory="Kitchen",
                CollectionId =3
                },
                 new SpaceInfoModel(){
                Id=9,
                SpaceName="Loft",
                SpaceCategory="Living Room",
                CollectionId =3
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
                    InvitedUsername="Peter",
                    CollectionId=2,
                    IsDeleted=false,
                    IsAccepted=true
                 },
                  new SharedSpacesModel(){
                     Id=2,
                    InvitedUsername="Walaa",
                    CollectionId=2,
                    IsDeleted=false,
                    IsAccepted=true
                 },
                 
            };
            builder.Entity<SharedSpacesModel>().HasData(sharedSpacesData);

            var selectedTasksData = new List<SelectedTasksModel>(){
                new SelectedTasksModel(){
                    Id=1,
                    ItemId=1,
                    UserId=2,
                    TaskId=5,
                    ProductId=3,
                    SpaceId=2,
                    DateCreated="4-19-2022",
                    DateCompleted="",
                    IsDeleted=false,
                    IsArchived=true
                },
                new SelectedTasksModel(){
                    Id=2,
                    ItemId=1,
                    UserId=2,
                    TaskId=5,
                    ProductId=3,
                    SpaceId=2,
                    DateCreated="4-21-2022",
                    DateCompleted="4-22-2022",
                    IsDeleted=false,
                    IsArchived=true
                },
                new SelectedTasksModel(){
                    Id=3,
                    ItemId=1,
                    UserId=3,
                    TaskId=5,
                    ProductId=3,
                    SpaceId=2,
                    DateCreated="4-21-2022",
                    DateCompleted="4-22-2022",
                    IsDeleted=false,
                    IsArchived=true
                },
                new SelectedTasksModel(){
                    Id=4,
                    ItemId=1,
                    UserId=1,
                    TaskId=5,
                    ProductId=3,
                    SpaceId=2,
                    DateCreated="4-21-2022",
                    DateCompleted="4-22-2022",
                    IsDeleted=false,
                    IsArchived=true
                },
                new SelectedTasksModel(){
                    Id=5,
                    ItemId=1,
                    UserId=1,
                    TaskId=5,
                    ProductId=3,
                    SpaceId=2,
                    DateCreated="4-21-2022",
                    DateCompleted="4-22-2022",
                    IsDeleted=false,
                    IsArchived=true
                }
            };
            builder.Entity<SelectedTasksModel>().HasData(selectedTasksData);

            var selectedItemsInSpaceData = new List<SelectedItemsInSpaceModel>()
            {
                new SelectedItemsInSpaceModel(){
                    Id=1,
                    SpaceId=1,
                    IsDeleted=true
                },
                new SelectedItemsInSpaceModel(){
                    Id=2,
                    SpaceId=2,
                    IsDeleted=false
                },
                new SelectedItemsInSpaceModel(){
                    Id=3,
                    SpaceId=3,
                    IsDeleted=true
                },
                new SelectedItemsInSpaceModel(){
                    Id=4,
                    SpaceId=4,
                    IsDeleted=false
                },
                new SelectedItemsInSpaceModel(){
                    Id=5,
                    SpaceId=5,
                    IsDeleted=true
                }
            };
            builder.Entity<SelectedItemsInSpaceModel>().HasData(selectedItemsInSpaceData);

            var dependentData = new List<DependentModel>(){

                new DependentModel(){
                    Id=1,
                    UserId=3,
                    DependentName="Taylor",
                    DependentAge=11,
                    DependentPhoto="https://scrubbystorage.blob.core.windows.net/scrubbystorage/avatar6.png",
                    DependentCoins=5000,
                    DependentPoints=0,
                    IsDeleted=false,
                    DependentPassCode= 0
                },
                new DependentModel(){
                    Id=2,
                    UserId=3,
                    DependentName="Sammy",
                    DependentAge=8,
                    DependentPhoto="https://scrubbystorage.blob.core.windows.net/scrubbystorage/avatar7.png",
                    DependentCoins=2000,
                    DependentPoints=6,
                    IsDeleted=false,
                    DependentPassCode= 0
                },
                new DependentModel(){
                    Id=3,
                    UserId=3,
                    DependentName="Jeff",
                    DependentAge=15,
                    DependentPhoto="https://scrubbystorage.blob.core.windows.net/scrubbystorage/avatar8.png",
                    DependentCoins=100,
                    DependentPoints=5,
                    IsDeleted=true,
                    DependentPassCode= 0
                },
                new DependentModel(){
                    Id=4,
                    UserId=1,
                    DependentName="Jessica",
                    DependentAge=8,
                    DependentPhoto="https://scrubbystorage.blob.core.windows.net/scrubbystorage/avatar9.png",
                    DependentCoins=7000,
                    DependentPoints=670,
                    IsDeleted=false,
                    DependentPassCode= 0
                },
                new DependentModel(){
                    Id=5,
                    UserId=2,
                    DependentName="Tony",
                    DependentAge=17,
                    DependentPhoto="https://scrubbystorage.blob.core.windows.net/scrubbystorage/avatar10.png",
                    DependentCoins=4000,
                    DependentPoints=50,
                    IsDeleted=false,
                    DependentPassCode= 0
                },
            };
            builder.Entity<DependentModel>().HasData(dependentData);

            var cleaningProductsStaticAPIData = new List<CleaningProductsStaticAPIModel>(){

                new CleaningProductsStaticAPIModel(){
                    Id=1,
                    ProductName="Window Wipers",
                    Instructions="Spray compound onto window and wipe with a clean towel",
                    Warnings="HARMFUL IF SWALLOWED. SKIN AND EYE IRRITANT.",
                    TaskTags="Window, Mirror"
                },
                new CleaningProductsStaticAPIModel(){
                    Id=2,
                    ProductName="Bleach",
                    Instructions="Spray compound onto surface and scurb with a sponge",
                    Warnings="HARMFUL IF SWALLOWED. SKIN AND EYE IRRITANT.",
                    TaskTags="Toilet, Shower, Bathtub"
                },
                new CleaningProductsStaticAPIModel(){
                    Id=3,
                    ProductName="Dish Detergents",
                    Instructions="Squeeze onto a sponge",
                    Warnings="HARMFUL IF SWALLOWED. SKIN AND EYE IRRITANT.",
                    TaskTags="Dishes"
                },
                new CleaningProductsStaticAPIModel(){
                    Id=4,
                    ProductName="Floor Detergents",
                    Instructions="Pour into a bucket of warm water and stir until product is mixed",
                    Warnings="HARMFUL IF SWALLOWED. SKIN AND EYE IRRITANT.",
                    TaskTags="Floor"
                },
                new CleaningProductsStaticAPIModel(){
                    Id=5,
                    ProductName="Window Wipers",
                    Instructions="Spray compound onto window and wipe with a clean towel",
                    Warnings="HARMFUL IF SWALLOWED. SKIN AND EYE IRRITANT.",
                    TaskTags="Window, Mirror"
                },
            };
            builder.Entity<CleaningProductsStaticAPIModel>().HasData(cleaningProductsStaticAPIData);

            var AssignedTasksUsersData = new List<AssignedTasksUsersModel>(){

                new AssignedTasksUsersModel(){
                    Id=1,
                    UserId=4,
                    SpaceId=4,
                    AssignedTaskId=5,
                    DateCreated="4-21-2022",
                    DateCompleted="4-22-2022",
                    Repeat=2
                },
                new AssignedTasksUsersModel(){
                    Id=2,
                    UserId=3,
                    SpaceId=3,
                    AssignedTaskId=3,
                    DateCreated="4-10-2022",
                    DateCompleted="4-12-2022",
                    Repeat=3
                },
                new AssignedTasksUsersModel(){
                    Id=3,
                    UserId=1,
                    SpaceId=1,
                    AssignedTaskId=2,
                    DateCreated="4-1-2022",
                    DateCompleted="4-3-2022",
                    Repeat=1
                },
                new AssignedTasksUsersModel(){
                    Id=4,
                    UserId=2,
                    SpaceId=2,
                    AssignedTaskId=4,
                    DateCreated="4-20-2022",
                    DateCompleted="4-20-2022",
                    Repeat=1
                },
                new AssignedTasksUsersModel(){
                    Id=5,
                    UserId=2,
                    SpaceId=2,
                    AssignedTaskId=1,
                    DateCreated="3-30-2022",
                    DateCompleted="3-31-2022",
                    Repeat=2
                }
            };
            builder.Entity<AssignedTasksUsersModel>().HasData(AssignedTasksUsersData);

            
            var assignedTasksChildData = new List<AssignedTasksChildModel>() {
                new AssignedTasksChildModel() {
                    Id=1,
                    ChildId=1,
                    AssignedTaskId=1,
                    DateCreated="03/30/2022",
                    DateCompleted="04/02/2022",
                    IsDeleted=false,
                    Repeat= 1
                },
                new AssignedTasksChildModel() {
                    Id=2,
                    ChildId=2,
                    AssignedTaskId=2,
                    DateCreated="03/31/2022",
                    DateCompleted="04/03/2022",
                    IsDeleted=false,
                    Repeat= 1
                },
                new AssignedTasksChildModel() {
                    Id=3,
                    ChildId=3,
                    AssignedTaskId=3,
                    DateCreated="04/01/2022",
                    DateCompleted="04/04/2022",
                    IsDeleted=false,
                    Repeat= 2
                },
                new AssignedTasksChildModel() {
                    Id=4,
                    ChildId=4,
                    AssignedTaskId=4,
                    DateCreated="04/02/2022",
                    DateCompleted="04/05/2022",
                    IsDeleted=false,
                    Repeat= 3
                },
                new AssignedTasksChildModel() {
                    Id=5,
                    ChildId=5,
                    AssignedTaskId=5,
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
                    Name="Wooden Chair",
                    Description="A chair that is brown",
                    Tags="living room, bedroom, office ",
                },
                new SpaceItemsStaticAPIModel() {
                    Id=2,
                    Name="Lamp",
                    Description="A lamp",
                    Tags="living room, bedroom, office ",
                },
                new SpaceItemsStaticAPIModel() {
                    Id=3,
                    Name="Wooden Table",
                    Description="A round table that is made of wood",
                    Tags="kitchen, living room, bedroom, office",
                },
                new SpaceItemsStaticAPIModel() {
                    Id=4,
                    Name="Glass Table",
                    Description="A table that is made of glass",
                    Tags="kitchen, living room, bedroom, office",
                },
                new SpaceItemsStaticAPIModel() {
                    Id=5,
                    Name="Ceramic Table",
                    Description="A table that is made of ceramic",
                    Tags="kitchen, living room, bedroom, office",
                },
                new SpaceItemsStaticAPIModel() {
                    Id=6,
                    Name="Granite Table",
                    Description="A table that is made of granite",
                    Tags="kitchen, living room, bedroom, office",
                },
                new SpaceItemsStaticAPIModel() {
                    Id=7,
                    Name="Marble Table",
                    Description="A table that is made of marble",
                    Tags="kitchen, living room, bedroom, office",
                },
                new SpaceItemsStaticAPIModel() {
                    Id=8,
                    Name="Rug",
                    Description="A rug that is fluffy",
                    Tags="carpet, fluffy, living room, bedroom",
                },
                new SpaceItemsStaticAPIModel() {
                    Id=9,
                    Name="Water Bed",
                    Description="A water bed",
                    Tags="slippery, wet, bedroom, ",
                },
                new SpaceItemsStaticAPIModel() {
                    Id=10,
                    Name="Bed",
                    Description="A standard bed",
                    Tags="bedroom, attic",
                },
                new SpaceItemsStaticAPIModel() {
                    Id=11,
                    Name="Bunk Bed",
                    Description="A bunk bed with one mattress in the bottom and another mattress in the top",
                    Tags="bedroom, attic",
                },
                new SpaceItemsStaticAPIModel() {
                    Id=12,
                    Name="Baby Cot",
                    Description="A bed that is made for babies/toddlers",
                    Tags="bedroom, attic, living room",
                },
                new SpaceItemsStaticAPIModel() {
                    Id=13,
                    Name="Children Bed",
                    Description="A bed that is made for children",
                    Tags="bedroom, attic",
                },
                new SpaceItemsStaticAPIModel() {
                    Id=14,
                    Name="Medical Bed",
                    Description="a bed that is used in the medical field",
                    Tags="bedroom, attic,",
                },
                new SpaceItemsStaticAPIModel() {
                    Id=15,
                    Name="Futon",
                    Description="A bed that can be a sofa or can fold into a bed",
                    Tags="bedroom, attic, living room",
                },
                new SpaceItemsStaticAPIModel() {
                    Id=16,
                    Name="Air Mattress",
                    Description="A bed that is inflated by air",
                    Tags="bedroom, attic",
                },
                new SpaceItemsStaticAPIModel() {
                    Id=17,
                    Name="Ceramic Tile Floor",
                    Description="A floor that is made of ceramic tiles",
                    Tags="living room, bathroom, kitchen",
                },
                new SpaceItemsStaticAPIModel() {
                    Id=18,
                    Name="Vinyl Floor",
                    Description="A floor that is made of vinyl",
                    Tags="living room, bathroom, kitchen",
                },
                new SpaceItemsStaticAPIModel() {
                    Id=19,
                    Name="Concrete Floor",
                    Description="A floor that is made of concrete",
                    Tags="living room, bathroom, kitchen",
                },
                new SpaceItemsStaticAPIModel() {
                    Id=20,
                    Name="Fabric Chair",
                    Description="A Chair that is made of fabric",
                    Tags="living room, bedroom, office",
                },
                  new SpaceItemsStaticAPIModel() {
                    Id=21,
                    Name="Computer Monitor",
                    Description="",
                    Tags="office",
                },
                  new SpaceItemsStaticAPIModel() {
                    Id=22,
                    Name="Keyboard",
                    Description="",
                    Tags="office",
                },
                  new SpaceItemsStaticAPIModel() {
                    Id=23,
                    Name="Bookshelf",
                    Description="",
                    Tags="office, living room",
                },
                  new SpaceItemsStaticAPIModel() {
                    Id=24,
                    Name="Side table",
                    Description="",
                    Tags="office, living room, office",
                },
                  new SpaceItemsStaticAPIModel() {
                    Id=25,
                    Name="Dresser",
                    Description="",
                    Tags="bedroom",
                },
                  new SpaceItemsStaticAPIModel() {
                    Id=26,
                    Name="Drawer Chest",
                    Description="",
                    Tags="bedroom",
                },
                  new SpaceItemsStaticAPIModel() {
                    Id=27,
                    Name="Nightstand",
                    Description="",
                    Tags="bedroom",
                },
                  new SpaceItemsStaticAPIModel() {
                    Id=28,
                    Name="Mirror",
                    Description="",
                    Tags="office, living room, office, bedroom, bathroom",
                },
                  new SpaceItemsStaticAPIModel() {
                    Id=29,
                    Name="Sink",
                    Description="",
                    Tags="bathroom, kitchen, laundry room",
                },
                  new SpaceItemsStaticAPIModel() {
                    Id=30,
                    Name="Cabinet",
                    Description="",
                    Tags="bathroom",
                },
                  new SpaceItemsStaticAPIModel() {
                    Id=31,
                    Name="Vanity",
                    Description="",
                    Tags="bathroom",
                },
                  new SpaceItemsStaticAPIModel() {
                    Id=32,
                    Name="Toilet",
                    Description="",
                    Tags="bathroom",
                },
                   new SpaceItemsStaticAPIModel() {
                    Id=33,
                    Name="Bathtub",
                    Description="",
                    Tags="bathroom",
                },
                   new SpaceItemsStaticAPIModel() {
                    Id=34,
                    Name="Shower Stall",
                    Description="",
                    Tags="bathroom",
                },
                   new SpaceItemsStaticAPIModel() {
                    Id=35,
                    Name="Sofa",
                    Description="",
                    Tags="living room",
                },
                   new SpaceItemsStaticAPIModel() {
                    Id=36,
                    Name="TV Stand",
                    Description="",
                    Tags="living room",
                },
                   new SpaceItemsStaticAPIModel() {
                    Id=37,
                    Name="Cabinets",
                    Description="",
                    Tags="kitchen",
                },  
                 new SpaceItemsStaticAPIModel() {
                    Id=38,
                    Name="Stove Top",
                    Description="",
                    Tags="kitchen",
                },
                new SpaceItemsStaticAPIModel() {
                    Id=39,
                    Name="Oven",
                    Description="",
                    Tags="kitchen",
                },
                new SpaceItemsStaticAPIModel() {
                    Id=40,
                    Name="Microwave",
                    Description="",
                    Tags="kitchen",
                },
                new SpaceItemsStaticAPIModel() {
                    Id=41,
                    Name="Countertops",
                    Description="",
                    Tags="kitchen",
                },
                new SpaceItemsStaticAPIModel() {
                    Id=42,
                    Name="Wooden Floor",
                    Description="",
                    Tags="living room, kithen, bedroom",
                },
                  new SpaceItemsStaticAPIModel() {
                    Id=43,
                    Name="Fridge",
                    Description="",
                    Tags="kitchen",
                },
                  new SpaceItemsStaticAPIModel() {
                    Id=44,
                    Name="Dishwasher",
                    Description="",
                    Tags="kitchen",
                },
                  new SpaceItemsStaticAPIModel() {
                    Id=45,
                    Name="Car",
                    Description="",
                    Tags="garage",
                },
                   new SpaceItemsStaticAPIModel() {
                    Id=46,
                    Name="Work Station",
                    Description="",
                    Tags="garage",
                },
                  new SpaceItemsStaticAPIModel() {
                    Id=47,
                    Name="Grass",
                    Description="",
                    Tags="yard",
                },
                   new SpaceItemsStaticAPIModel() {
                    Id=48,
                    Name="Tree",
                    Description="",
                    Tags="yard",
                },

                   new SpaceItemsStaticAPIModel() {
                    Id=49,
                    Name="Plants",
                    Description="",
                    Tags="yard",
                },
                   new SpaceItemsStaticAPIModel() {
                    Id=50,
                    Name="laundry",
                    Description="",
                    Tags="laundry room",
                },
                 new SpaceItemsStaticAPIModel() {
                    Id=51,
                    Name="Carpet Floor",
                    Description="A floor that is made of carpet",
                    Tags="living room, bedroom",
                },
                     new SpaceItemsStaticAPIModel() {
                    Id=52,
                    Name="Trash",
                    Description="A Trashbin",
                    Tags="kitchen",
                },
                
            };
            builder.Entity<SpaceItemsStaticAPIModel>().HasData(spaceItemsStaticAPIData);

            var tasksInfoStaticAPIData = new List<TasksInfoStaticAPIModel>() {
                new TasksInfoStaticAPIModel() {
                    Id=1,
                    Name="Clean",
                    Description="Clean the toilet using a sanitizer",
                    Tags="toilet",
                    Time="15 min",
                    coins=15
                },
                new TasksInfoStaticAPIModel() {
                    Id=2,
                    Name="Make",
                    Description="Remove the comforter, make sure the fitted sheet is clean and stretched. Lay out your top sheet an put your comforter on, then add the pillows.",
                    Tags="bed",
                    Time="10 min",
                    coins=10
                },
                new TasksInfoStaticAPIModel() {
                    Id=3,
                    Name="Wash dishes",
                    Description="Load your dishwasher with dirty dishes. Make sure the dishes don't have a lot of food on them.",
                    Tags="dishwasher",
                    Time="10 min",
                    coins=15
                },
                new TasksInfoStaticAPIModel() {
                    Id=4,
                    Name="Wash Clothes",
                    Description="Wash clothes with one batch colors and other batch white",
                    Tags="laundry",
                    Time="15 min",
                    coins=20
                },
                new TasksInfoStaticAPIModel() {
                    Id=5,
                    Name="Dust",
                    Description="Dust the piece of furniture",
                    Tags="chair, table, monitor, keyboard, bookshelf, dresser, drawer, nightstand, cabinet, TV, Cabinets",
                    Time="5 min",
                    coins=5
                },
                 new TasksInfoStaticAPIModel() {
                    Id=6,
                    Name="Change Bedsheets",
                    Description="Remove old bedsheets and replace with clean sheets. Remove the comforter, make sure the fitted sheet is clean and stretched. Lay out your top sheet an put your comforter on, then add the pillows.",
                    Tags="bed",
                    Time="10 min",
                    coins=10
                },
                 new TasksInfoStaticAPIModel() {
                    Id=7,
                    Name="Polish",
                    Description="Polish the wood surface",
                    Tags="wood, wooden, Wooden Chair, Wooden Table, Dresser, Drawer Chest, Nightstand, TV Stand ",
                    Time="5 min",
                    coins=5
                },
                 new TasksInfoStaticAPIModel() {
                    Id=8,
                    Name="Scrub",
                    Description="",
                    Tags="toilet, sink ",
                    Time="5 min",
                    coins=5
                },
                 new TasksInfoStaticAPIModel() {
                    Id=9,
                    Name="Sanitize",
                    Description="clean",
                    Tags="",
                    Time=" min",
                    coins=5
                },
                 new TasksInfoStaticAPIModel() {
                    Id=10,
                    Name="Organize",
                    Description="Organize the items on the surface",
                    Tags="Work Station, Countertops, Bookshelf",
                    Time=" min",
                    coins=5
                },
                 new TasksInfoStaticAPIModel() {
                    Id=11,
                    Name="Shine Glass",
                    Description="",
                    Tags="Glass Table, Vanity, Mirror ",
                    Time="5 min",
                    coins=5
                },
                 new TasksInfoStaticAPIModel() {
                    Id=12,
                    Name="Wipe",
                    Description="",
                    Tags="",
                    Time=" min",
                    coins=5
                },
                 new TasksInfoStaticAPIModel() {
                    Id=13,
                    Name="Sweep",
                    Description="",
                    Tags="Ceramic Tile Floor, Concrete Floor, Vinyl Floor",
                    Time="10 min",
                    coins=10
                },
                 new TasksInfoStaticAPIModel() {
                    Id=14,
                    Name="Sweep under",
                    Description="Sweep or vaccum under the furniture",
                    Tags="chair, couch",
                    Time="10 min",
                    coins=10
                },
                 new TasksInfoStaticAPIModel() {
                    Id=15,
                    Name="Vaccum",
                    Description="Vaccume the carpet with a vaccum cleaner",
                    Tags="Carpet Floor",
                    Time="15 min",
                    coins=15
                },
                 new TasksInfoStaticAPIModel() {
                    Id=16,
                    Name="Mop",
                    Description="",
                    Tags="Wooden Floor, Vinyl Floor, Ceramic Tile Floor",
                    Time="15 min",
                    coins=15
                },
                 new TasksInfoStaticAPIModel() {
                    Id=17,
                    Name="Trim Tree",
                    Description="Trim the tree to make sure it looks good",
                    Tags="tree",
                    Time="20 min",
                    coins=20
                },
                 new TasksInfoStaticAPIModel() {
                    Id=18,
                    Name="Remove ",
                    Description="Take the trash outside and put a new trash lining",
                    Tags="trash",
                    Time="5 min",
                    coins=5
                },
                 new TasksInfoStaticAPIModel() {
                    Id=19,
                    Name="Mow the Lawn",
                    Description="Cut the grass on the lawn with a lawn mower ",
                    Tags="grass",
                    Time=" 20 min",
                    coins=20
                },
                 new TasksInfoStaticAPIModel() {
                    Id=20,
                    Name="Water the plants",
                    Description="Water the plants and give them fertilizer if needed",
                    Tags="plants",
                    Time="15 min",
                    coins=15
                },
                 new TasksInfoStaticAPIModel() {
                    Id=21,
                    Name="Remove expired food",
                    Description="Check the fridge and make sure all expired food are removed",
                    Tags="fridge ",
                    Time="15 min",
                    coins=15
                },
                
            };

            builder.Entity<TasksInfoStaticAPIModel>().HasData(tasksInfoStaticAPIData);


        }

           
    
    }
}