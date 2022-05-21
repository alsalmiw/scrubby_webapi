using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scrubby_webapi.Migrations
{
    public partial class defaultcollectionsInvited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssignedTasksChildInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChildId = table.Column<int>(type: "int", nullable: false),
                    SpaceId = table.Column<int>(type: "int", nullable: false),
                    AssignedTaskId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCompleted = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsRequestedApproval = table.Column<bool>(type: "bit", nullable: false),
                    Repeat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedTasksChildInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssignedTasksUsersInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SpaceId = table.Column<int>(type: "int", nullable: false),
                    AssignedTaskId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCompleted = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Repeat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedTasksUsersInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CleaningProductsStaticAPIInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Warnings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskTags = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CleaningProductsStaticAPIInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DefaultCollectionDependentInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChildId = table.Column<int>(type: "int", nullable: false),
                    CollectionId = table.Column<int>(type: "int", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultCollectionDependentInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DefaultCollectionInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CollectionId = table.Column<int>(type: "int", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultCollectionInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DependentInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DependentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DependentAge = table.Column<int>(type: "int", nullable: false),
                    DependentPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DependentCoins = table.Column<int>(type: "int", nullable: false),
                    DependentPoints = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DependentPassCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DependentInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvitesInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InviterId = table.Column<int>(type: "int", nullable: false),
                    InviterUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InviterFullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InviterPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvitedId = table.Column<int>(type: "int", nullable: false),
                    InvitedUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvitedFullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvitedPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvitesInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SelectedItemsInSpaceInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpaceId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedItemsInSpaceInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SelectedTasksInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SpaceId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCompleted = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedTasksInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SharedSpacesInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvitedUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InviterUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollectionId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharedSpacesInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpaceCollectionInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollectionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpaceCollectionInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpaceInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpaceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpaceCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpaceInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpaceItemsStaticAPIInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpaceItemsStaticAPIInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TasksInfoStaticAPIInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    coins = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasksInfoStaticAPIInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Coins = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Points = table.Column<int>(type: "int", nullable: false),
                    IsChildFree = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AssignedTasksChildInfo",
                columns: new[] { "Id", "AssignedTaskId", "ChildId", "DateCompleted", "DateCreated", "IsCompleted", "IsDeleted", "IsRequestedApproval", "Repeat", "SpaceId" },
                values: new object[,]
                {
                    { 1, 1, 1, "04/02/2022", "03/30/2022", false, false, false, 1, 0 },
                    { 2, 2, 2, "04/03/2022", "03/31/2022", false, false, false, 1, 0 },
                    { 3, 3, 3, "04/04/2022", "04/01/2022", false, false, false, 2, 0 },
                    { 4, 4, 4, "04/05/2022", "04/02/2022", false, false, false, 3, 0 },
                    { 5, 5, 5, "04/06/2022", "04/03/2022", false, false, false, 2, 0 }
                });

            migrationBuilder.InsertData(
                table: "AssignedTasksUsersInfo",
                columns: new[] { "Id", "AssignedTaskId", "DateCompleted", "DateCreated", "IsCompleted", "IsDeleted", "Repeat", "SpaceId", "UserId" },
                values: new object[,]
                {
                    { 1, 5, "4-22-2022", "4-21-2022", false, false, 2, 4, 4 },
                    { 2, 3, "4-12-2022", "4-10-2022", false, false, 3, 3, 3 },
                    { 3, 2, "4-3-2022", "4-1-2022", false, false, 1, 1, 1 },
                    { 4, 4, "4-20-2022", "4-20-2022", false, false, 1, 2, 2 },
                    { 5, 1, "3-31-2022", "3-30-2022", false, false, 2, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "CleaningProductsStaticAPIInfo",
                columns: new[] { "Id", "Instructions", "ProductName", "TaskTags", "Warnings" },
                values: new object[,]
                {
                    { 1, "Spray compound onto window and wipe with a clean towel", "Window Wipers", "Window, Mirror", "HARMFUL IF SWALLOWED. SKIN AND EYE IRRITANT." },
                    { 2, "Spray compound onto surface and scurb with a sponge", "Bleach", "Toilet, Shower, Bathtub", "HARMFUL IF SWALLOWED. SKIN AND EYE IRRITANT." },
                    { 3, "Squeeze onto a sponge", "Dish Detergents", "Dishes", "HARMFUL IF SWALLOWED. SKIN AND EYE IRRITANT." },
                    { 4, "Pour into a bucket of warm water and stir until product is mixed", "Floor Detergents", "Floor", "HARMFUL IF SWALLOWED. SKIN AND EYE IRRITANT." },
                    { 5, "Spray compound onto window and wipe with a clean towel", "Window Wipers", "Window, Mirror", "HARMFUL IF SWALLOWED. SKIN AND EYE IRRITANT." }
                });

            migrationBuilder.InsertData(
                table: "DependentInfo",
                columns: new[] { "Id", "DependentAge", "DependentCoins", "DependentName", "DependentPassCode", "DependentPhoto", "DependentPoints", "IsDeleted", "UserId" },
                values: new object[,]
                {
                    { 1, 11, 5000, "Taylor", 0, "https://scrubbystorage.blob.core.windows.net/scrubbystorage/avatar6.png", 0, false, 3 },
                    { 2, 8, 2000, "Sammy", 0, "https://scrubbystorage.blob.core.windows.net/scrubbystorage/avatar7.png", 6, false, 3 },
                    { 3, 15, 100, "Jeff", 0, "https://scrubbystorage.blob.core.windows.net/scrubbystorage/avatar8.png", 5, true, 3 },
                    { 4, 8, 7000, "Jessica", 0, "https://scrubbystorage.blob.core.windows.net/scrubbystorage/avatar9.png", 670, false, 1 },
                    { 5, 17, 4000, "Tony", 0, "https://scrubbystorage.blob.core.windows.net/scrubbystorage/avatar10.png", 50, false, 2 }
                });

            migrationBuilder.InsertData(
                table: "SelectedItemsInSpaceInfo",
                columns: new[] { "Id", "IsDeleted", "SpaceId" },
                values: new object[,]
                {
                    { 1, true, 1 },
                    { 2, false, 2 },
                    { 3, true, 3 },
                    { 4, false, 4 },
                    { 5, true, 5 }
                });

            migrationBuilder.InsertData(
                table: "SelectedTasksInfo",
                columns: new[] { "Id", "DateCompleted", "DateCreated", "IsArchived", "IsDeleted", "ItemId", "ProductId", "SpaceId", "TaskId", "UserId" },
                values: new object[,]
                {
                    { 1, "", "4-19-2022", true, false, 1, 3, 2, 5, 2 },
                    { 2, "4-22-2022", "4-21-2022", true, false, 1, 3, 2, 5, 2 },
                    { 3, "4-22-2022", "4-21-2022", true, false, 1, 3, 2, 5, 3 },
                    { 4, "4-22-2022", "4-21-2022", true, false, 1, 3, 2, 5, 1 },
                    { 5, "4-22-2022", "4-21-2022", true, false, 1, 3, 2, 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "SharedSpacesInfo",
                columns: new[] { "Id", "CollectionId", "InvitedUsername", "InviterUsername", "IsAccepted", "IsDeleted" },
                values: new object[,]
                {
                    { 1, 2, "Peter", null, true, false },
                    { 2, 2, "Walaa", null, true, false }
                });

            migrationBuilder.InsertData(
                table: "SpaceCollectionInfo",
                columns: new[] { "Id", "CollectionName", "IsDefault", "IsDeleted", "UserId" },
                values: new object[,]
                {
                    { 1, "Smith House", false, false, 1 },
                    { 2, "Storage Shed", false, false, 1 },
                    { 3, "Paris Home", false, false, 2 },
                    { 4, "Work Office", false, false, 3 },
                    { 5, "Shed", false, false, 4 }
                });

            migrationBuilder.InsertData(
                table: "SpaceInfo",
                columns: new[] { "Id", "CollectionId", "SpaceCategory", "SpaceName" },
                values: new object[,]
                {
                    { 1, 1, "Space Category", "Space Name" },
                    { 2, 1, "Space Category", "Space Name" },
                    { 3, 1, "Space Category", "Space Name" },
                    { 4, 1, "Space Category", "Space Name" },
                    { 5, 1, "Space Category", "Space Name" }
                });

            migrationBuilder.InsertData(
                table: "SpaceInfo",
                columns: new[] { "Id", "CollectionId", "SpaceCategory", "SpaceName" },
                values: new object[,]
                {
                    { 6, 3, "Bathroom", "Master Bath" },
                    { 7, 3, "Bedroom", "Kids Bedroom" },
                    { 8, 3, "Kitchen", "Kitchen" },
                    { 9, 3, "Living Room", "Loft" }
                });

            migrationBuilder.InsertData(
                table: "SpaceItemsStaticAPIInfo",
                columns: new[] { "Id", "Description", "Name", "Tags" },
                values: new object[,]
                {
                    { 1, "A chair that is brown", "Wooden Chair", "living room, bedroom, office " },
                    { 2, "A lamp", "Lamp", "living room, bedroom, office " },
                    { 3, "A round table that is made of wood", "Wooden Table", "kitchen, living room, bedroom, office" },
                    { 4, "A table that is made of glass", "Glass Table", "kitchen, living room, bedroom, office" },
                    { 5, "A table that is made of ceramic", "Ceramic Table", "kitchen, living room, bedroom, office" },
                    { 6, "A table that is made of granite", "Granite Table", "kitchen, living room, bedroom, office" },
                    { 7, "A table that is made of marble", "Marble Table", "kitchen, living room, bedroom, office" },
                    { 8, "A rug that is fluffy", "Rug", "carpet, fluffy, living room, bedroom" },
                    { 9, "A water bed", "Water Bed", "slippery, wet, bedroom, " },
                    { 10, "A standard bed", "Bed", "bedroom, attic" },
                    { 11, "A bunk bed with one mattress in the bottom and another mattress in the top", "Bunk Bed", "bedroom, attic" },
                    { 12, "A bed that is made for babies/toddlers", "Baby Cot", "bedroom, attic, living room" },
                    { 13, "A bed that is made for children", "Children Bed", "bedroom, attic" },
                    { 14, "a bed that is used in the medical field", "Medical Bed", "bedroom, attic," },
                    { 15, "A bed that can be a sofa or can fold into a bed", "Futon", "bedroom, attic, living room" },
                    { 16, "A bed that is inflated by air", "Air Mattress", "bedroom, attic" },
                    { 17, "A floor that is made of ceramic tiles", "Ceramic Tile Floor", "living room, bathroom, kitchen" },
                    { 18, "A floor that is made of vinyl", "Vinyl Floor", "living room, bathroom, kitchen" },
                    { 19, "A floor that is made of concrete", "Concrete Floor", "living room, bathroom, kitchen" },
                    { 20, "A Chair that is made of fabric", "Fabric Chair", "living room, bedroom, office" },
                    { 21, "", "Computer Monitor", "office" },
                    { 22, "", "Keyboard", "office" },
                    { 23, "", "Bookshelf", "office, living room" },
                    { 24, "", "Side table", "office, living room, office" },
                    { 25, "", "Dresser", "bedroom" },
                    { 26, "", "Drawer Chest", "bedroom" },
                    { 27, "", "Nightstand", "bedroom" },
                    { 28, "", "Mirror", "office, living room, office, bedroom, bathroom" },
                    { 29, "", "Sink", "bathroom, kitchen, laundry room" },
                    { 30, "", "Cabinet", "bathroom" },
                    { 31, "", "Vanity", "bathroom" },
                    { 32, "", "Toilet", "bathroom" },
                    { 33, "", "Bathtub", "bathroom" },
                    { 34, "", "Shower Stall", "bathroom" },
                    { 35, "", "Sofa", "living room" },
                    { 36, "", "TV Stand", "living room" },
                    { 37, "", "Cabinets", "kitchen" },
                    { 38, "", "Stove Top", "kitchen" }
                });

            migrationBuilder.InsertData(
                table: "SpaceItemsStaticAPIInfo",
                columns: new[] { "Id", "Description", "Name", "Tags" },
                values: new object[,]
                {
                    { 39, "", "Oven", "kitchen" },
                    { 40, "", "Microwave", "kitchen" },
                    { 41, "", "Countertops", "kitchen" },
                    { 42, "", "Wooden Floor", "living room, kithen, bedroom" },
                    { 43, "", "Fridge", "kitchen" },
                    { 44, "", "Dishwasher", "kitchen" },
                    { 45, "", "Car", "garage" },
                    { 46, "", "Work Station", "garage" },
                    { 47, "", "Grass", "yard" },
                    { 48, "", "Tree", "yard" },
                    { 49, "", "Plants", "yard" },
                    { 50, "", "laundry", "laundry room" },
                    { 51, "A floor that is made of carpet", "Carpet Floor", "living room, bedroom" },
                    { 52, "A Trashbin", "Trash", "kitchen" }
                });

            migrationBuilder.InsertData(
                table: "TasksInfoStaticAPIInfo",
                columns: new[] { "Id", "Description", "Name", "Tags", "Time", "coins" },
                values: new object[,]
                {
                    { 1, "Clean the toilet using a sanitizer", "Clean", "toilet", "15 min", 15 },
                    { 2, "Remove the comforter, make sure the fitted sheet is clean and stretched. Lay out your top sheet an put your comforter on, then add the pillows.", "Make", "bed", "10 min", 10 },
                    { 3, "Load your dishwasher with dirty dishes. Make sure the dishes don't have a lot of food on them.", "Wash dishes", "dishwasher", "10 min", 15 },
                    { 4, "Wash clothes with one batch colors and other batch white", "Wash Clothes", "laundry", "15 min", 20 },
                    { 5, "Dust the piece of furniture", "Dust", "chair, table, monitor, keyboard, bookshelf, dresser, drawer, nightstand, cabinet, TV, Cabinets", "5 min", 5 },
                    { 6, "Remove old bedsheets and replace with clean sheets. Remove the comforter, make sure the fitted sheet is clean and stretched. Lay out your top sheet an put your comforter on, then add the pillows.", "Change Bedsheets", "bed", "10 min", 10 },
                    { 7, "Polish the wood surface", "Polish", "wood, wooden, Wooden Chair, Wooden Table, Dresser, Drawer Chest, Nightstand, TV Stand ", "5 min", 5 },
                    { 8, "", "Scrub", "toilet, sink ", "5 min", 5 },
                    { 9, "clean", "Sanitize", "", " min", 5 },
                    { 10, "Organize the items on the surface", "Organize", "Work Station, Countertops, Bookshelf", " min", 5 },
                    { 11, "", "Shine Glass", "Glass Table, Vanity, Mirror ", "5 min", 5 },
                    { 12, "", "Wipe", "", " min", 5 },
                    { 13, "", "Sweep", "Ceramic Tile Floor, Concrete Floor, Vinyl Floor", "10 min", 10 },
                    { 14, "Sweep or vaccum under the furniture", "Sweep under", "chair, couch", "10 min", 10 },
                    { 15, "Vaccume the carpet with a vaccum cleaner", "Vaccum", "Carpet Floor", "15 min", 15 },
                    { 16, "", "Mop", "Wooden Floor, Vinyl Floor, Ceramic Tile Floor", "15 min", 15 },
                    { 17, "Trim the tree to make sure it looks good", "Trim Tree", "tree", "20 min", 20 },
                    { 18, "Take the trash outside and put a new trash lining", "Remove ", "trash", "5 min", 5 },
                    { 19, "Cut the grass on the lawn with a lawn mower ", "Mow the Lawn", "grass", " 20 min", 20 },
                    { 20, "Water the plants and give them fertilizer if needed", "Water the plants", "plants", "15 min", 15 },
                    { 21, "Check the fridge and make sure all expired food are removed", "Remove expired food", "fridge ", "15 min", 15 }
                });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "Coins", "Hash", "IsChildFree", "IsDeleted", "Name", "Photo", "Points", "Salt", "Username" },
                values: new object[,]
                {
                    { 1, 5000, "BBvCTG4MF3e0YvDBW7mPkimgpAOpbP7HUkNb8YRmHjM8KdNBKFRRgctlBZV/WZ0GfasEBS8qJCuPB0Z4rOalX0UuAxkqmoBznghkV+lmxmIod+25vzFPjuSYhN7QvWsfPvGf7Ze1w/qG3xQ6KBTgjTc+yKe9bcaQPFBjiYPVnM1RYsUPC3RG47Q27K2xqCOQTtdvaAUEhoDgaCLi3zyi+e750FEZ6e9y1HObs4Zsnl2Yk4AwkFZ8IZBnHlXoDyy1b1ICIG7+CggJdDkiNJxv57BRlNqijDwfE+6vBujqvr7a5kgzWgGoEMBsqLpFNv7j7sIJVBjevmyV3X8eDAY68g==", false, false, "JT", "https://scrubbystorage.blob.core.windows.net/scrubbystorage/avatar1.png", 600, "6oyIFN+J/zb3uaje2+GP98c/WdMgNb9Rwbn3Wyi51i+OUta55QsZFkrTqbJy9hiothKp95mleCPySEZOIOcPIg==", "JT" },
                    { 2, 1000, "BBvCTG4MF3e0YvDBW7mPkimgpAOpbP7HUkNb8YRmHjM8KdNBKFRRgctlBZV/WZ0GfasEBS8qJCuPB0Z4rOalX0UuAxkqmoBznghkV+lmxmIod+25vzFPjuSYhN7QvWsfPvGf7Ze1w/qG3xQ6KBTgjTc+yKe9bcaQPFBjiYPVnM1RYsUPC3RG47Q27K2xqCOQTtdvaAUEhoDgaCLi3zyi+e750FEZ6e9y1HObs4Zsnl2Yk4AwkFZ8IZBnHlXoDyy1b1ICIG7+CggJdDkiNJxv57BRlNqijDwfE+6vBujqvr7a5kgzWgGoEMBsqLpFNv7j7sIJVBjevmyV3X8eDAY68g==", false, false, "Angel Pantoja", "https://scrubbystorage.blob.core.windows.net/scrubbystorage/avatar2.png", 1000, "6oyIFN+J/zb3uaje2+GP98c/WdMgNb9Rwbn3Wyi51i+OUta55QsZFkrTqbJy9hiothKp95mleCPySEZOIOcPIg==", "Angel" },
                    { 3, 5000, "BBvCTG4MF3e0YvDBW7mPkimgpAOpbP7HUkNb8YRmHjM8KdNBKFRRgctlBZV/WZ0GfasEBS8qJCuPB0Z4rOalX0UuAxkqmoBznghkV+lmxmIod+25vzFPjuSYhN7QvWsfPvGf7Ze1w/qG3xQ6KBTgjTc+yKe9bcaQPFBjiYPVnM1RYsUPC3RG47Q27K2xqCOQTtdvaAUEhoDgaCLi3zyi+e750FEZ6e9y1HObs4Zsnl2Yk4AwkFZ8IZBnHlXoDyy1b1ICIG7+CggJdDkiNJxv57BRlNqijDwfE+6vBujqvr7a5kgzWgGoEMBsqLpFNv7j7sIJVBjevmyV3X8eDAY68g==", false, false, "Walaa AlSalmi", "https://scrubbystorage.blob.core.windows.net/scrubbystorage/avatar3.png", 1000, "6oyIFN+J/zb3uaje2+GP98c/WdMgNb9Rwbn3Wyi51i+OUta55QsZFkrTqbJy9hiothKp95mleCPySEZOIOcPIg==", "Walaa" },
                    { 4, 50000, "BBvCTG4MF3e0YvDBW7mPkimgpAOpbP7HUkNb8YRmHjM8KdNBKFRRgctlBZV/WZ0GfasEBS8qJCuPB0Z4rOalX0UuAxkqmoBznghkV+lmxmIod+25vzFPjuSYhN7QvWsfPvGf7Ze1w/qG3xQ6KBTgjTc+yKe9bcaQPFBjiYPVnM1RYsUPC3RG47Q27K2xqCOQTtdvaAUEhoDgaCLi3zyi+e750FEZ6e9y1HObs4Zsnl2Yk4AwkFZ8IZBnHlXoDyy1b1ICIG7+CggJdDkiNJxv57BRlNqijDwfE+6vBujqvr7a5kgzWgGoEMBsqLpFNv7j7sIJVBjevmyV3X8eDAY68g==", false, false, "DB", "https://scrubbystorage.blob.core.windows.net/scrubbystorage/avatar4.png", 50000, "6oyIFN+J/zb3uaje2+GP98c/WdMgNb9Rwbn3Wyi51i+OUta55QsZFkrTqbJy9hiothKp95mleCPySEZOIOcPIg==", "DB" },
                    { 5, 15000, "BBvCTG4MF3e0YvDBW7mPkimgpAOpbP7HUkNb8YRmHjM8KdNBKFRRgctlBZV/WZ0GfasEBS8qJCuPB0Z4rOalX0UuAxkqmoBznghkV+lmxmIod+25vzFPjuSYhN7QvWsfPvGf7Ze1w/qG3xQ6KBTgjTc+yKe9bcaQPFBjiYPVnM1RYsUPC3RG47Q27K2xqCOQTtdvaAUEhoDgaCLi3zyi+e750FEZ6e9y1HObs4Zsnl2Yk4AwkFZ8IZBnHlXoDyy1b1ICIG7+CggJdDkiNJxv57BRlNqijDwfE+6vBujqvr7a5kgzWgGoEMBsqLpFNv7j7sIJVBjevmyV3X8eDAY68g==", false, false, "Peter Vang", "https://scrubbystorage.blob.core.windows.net/scrubbystorage/avatar5.png", 15000, "6oyIFN+J/zb3uaje2+GP98c/WdMgNb9Rwbn3Wyi51i+OUta55QsZFkrTqbJy9hiothKp95mleCPySEZOIOcPIg==", "Peter" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignedTasksChildInfo");

            migrationBuilder.DropTable(
                name: "AssignedTasksUsersInfo");

            migrationBuilder.DropTable(
                name: "CleaningProductsStaticAPIInfo");

            migrationBuilder.DropTable(
                name: "DefaultCollectionDependentInfo");

            migrationBuilder.DropTable(
                name: "DefaultCollectionInfo");

            migrationBuilder.DropTable(
                name: "DependentInfo");

            migrationBuilder.DropTable(
                name: "InvitesInfo");

            migrationBuilder.DropTable(
                name: "SelectedItemsInSpaceInfo");

            migrationBuilder.DropTable(
                name: "SelectedTasksInfo");

            migrationBuilder.DropTable(
                name: "SharedSpacesInfo");

            migrationBuilder.DropTable(
                name: "SpaceCollectionInfo");

            migrationBuilder.DropTable(
                name: "SpaceInfo");

            migrationBuilder.DropTable(
                name: "SpaceItemsStaticAPIInfo");

            migrationBuilder.DropTable(
                name: "TasksInfoStaticAPIInfo");

            migrationBuilder.DropTable(
                name: "UserInfo");
        }
    }
}
