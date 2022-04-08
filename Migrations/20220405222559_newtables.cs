using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scrubby_webapi.Migrations
{
    public partial class newtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssignedTasksChildInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SelectedTasksId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCompleted = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
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
                    UserIdTasked = table.Column<int>(type: "int", nullable: false),
                    UserIdOwner = table.Column<int>(type: "int", nullable: false),
                    SelectedTasksId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCompleted = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DependentInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SelectedItemsInSpaceInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpaceId = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    taskAndProductId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCompleted = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Repeat = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    isAccepted = table.Column<bool>(type: "bit", nullable: true)
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
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    collectionId = table.Column<int>(type: "int", nullable: false)
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
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AssignedTasksChildInfo",
                columns: new[] { "Id", "DateCompleted", "DateCreated", "IsDeleted", "Repeat", "SelectedTasksId", "UserId" },
                values: new object[,]
                {
                    { 1, "04/02/2022", "03/30/2022", false, 1, 1, 1 },
                    { 2, "04/03/2022", "03/31/2022", false, 1, 2, 2 },
                    { 3, "04/04/2022", "04/01/2022", false, 2, 3, 3 },
                    { 4, "04/05/2022", "04/02/2022", false, 3, 4, 4 },
                    { 5, "04/06/2022", "04/03/2022", false, 2, 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "AssignedTasksUsersInfo",
                columns: new[] { "Id", "DateCompleted", "DateCreated", "Repeat", "SelectedTasksId", "UserIdOwner", "UserIdTasked" },
                values: new object[,]
                {
                    { 1, "4-22-2022", "4-21-2022", 2, 5, 4, 4 },
                    { 2, "4-12-2022", "4-10-2022", 3, 3, 3, 3 },
                    { 3, "4-3-2022", "4-1-2022", 1, 2, 1, 1 },
                    { 4, "4-20-2022", "4-20-2022", 1, 4, 2, 2 },
                    { 5, "3-31-2022", "3-30-2022", 2, 1, 2, 2 }
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
                columns: new[] { "Id", "DependentAge", "DependentCoins", "DependentName", "DependentPhoto", "UserId", "isDeleted" },
                values: new object[,]
                {
                    { 1, 11, 5000, "Taylor", "", 1, false },
                    { 2, 8, 2000, "Sammy", "", 1, false },
                    { 3, 15, 100, "Jeff", "", 1, true },
                    { 4, 8, 7000, "Jessica", "", 1, false },
                    { 5, 17, 4000, "Tony", "", 2, false }
                });

            migrationBuilder.InsertData(
                table: "SelectedItemsInSpaceInfo",
                columns: new[] { "Id", "SpaceId", "isDeleted" },
                values: new object[,]
                {
                    { 1, 1, true },
                    { 2, 2, false },
                    { 3, 3, true },
                    { 4, 4, false },
                    { 5, 5, true }
                });

            migrationBuilder.InsertData(
                table: "SelectedTasksInfo",
                columns: new[] { "Id", "DateCompleted", "DateCreated", "Repeat", "taskAndProductId" },
                values: new object[,]
                {
                    { 1, "3-31-2022", "3-30-2022", 1, 1 },
                    { 2, "", "4-1-2022", 2, 2 },
                    { 3, "4-12-2022", "4-10-2022", 2, 3 },
                    { 4, "", "4-20-2022", 3, 4 },
                    { 5, "4-22-2022", "4-21-2022", 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "SharedSpacesInfo",
                columns: new[] { "Id", "UserId", "isAccepted", "isDeleted" },
                values: new object[,]
                {
                    { 1, 1, true, false },
                    { 2, 2, true, false },
                    { 3, 3, true, true },
                    { 4, 4, true, true },
                    { 5, 5, true, false }
                });

            migrationBuilder.InsertData(
                table: "SpaceCollectionInfo",
                columns: new[] { "Id", "CollectionName", "IsDeleted", "UserId" },
                values: new object[,]
                {
                    { 1, "Smith House", false, 1 },
                    { 2, "Storage Shed", false, 1 },
                    { 3, "Paris Home", false, 2 },
                    { 4, "Work Office", false, 3 },
                    { 5, "Shed", false, 4 }
                });

            migrationBuilder.InsertData(
                table: "SpaceInfo",
                columns: new[] { "Id", "SpaceCategory", "SpaceName", "collectionId" },
                values: new object[,]
                {
                    { 1, "Space Category", "Space Name", 1 },
                    { 2, "Space Category", "Space Name", 1 }
                });

            migrationBuilder.InsertData(
                table: "SpaceInfo",
                columns: new[] { "Id", "SpaceCategory", "SpaceName", "collectionId" },
                values: new object[,]
                {
                    { 3, "Space Category", "Space Name", 1 },
                    { 4, "Space Category", "Space Name", 1 },
                    { 5, "Space Category", "Space Name", 1 }
                });

            migrationBuilder.InsertData(
                table: "SpaceItemsStaticAPIInfo",
                columns: new[] { "Id", "Description", "Name", "Tags" },
                values: new object[,]
                {
                    { 1, "A chair that is brown", "Chair", "wood, living room, bedroom, office " },
                    { 2, "A lamp that is shiny", "Lamp", "bright, metal, living room, bedroom, office " },
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
                    { 16, "A bed that is inflated by air", "Air Mattress Bed", "bedroom, attic" },
                    { 17, "A floor that is made of ceramic tiles", "Ceramic Tile Floor", "living room, bathroom, kitchen" },
                    { 18, "A floor that is made of vinyl", "Vinyl Floor", "living room, bathroom, kitchen" },
                    { 19, "A floor that is made of concrete", "Concrete Floor", "living room, bathroom, kitchen" },
                    { 20, "A water bed", "Wooden Desk", "slippery, wet, bedroom" }
                });

            migrationBuilder.InsertData(
                table: "TasksInfoStaticAPIInfo",
                columns: new[] { "Id", "Description", "Name", "Tags", "Time", "coins" },
                values: new object[,]
                {
                    { 1, "Clean the toilet using wax on and wax off", "Clean toilet", "tile, slippery", "15 min", 20 },
                    { 2, "Make bed using military style", "Make bed", "sheets, pillow", "5 min", 10 },
                    { 3, "Wash dishes by hand", "Wash dishes", "soap, water", "10 min", 15 },
                    { 4, "Wash clothes with one batch colors and other batch white", "Do laundry", "tile, slippery", "15 min", 20 },
                    { 5, "Dust living room with swifter", "Dust living room", "dust, swifter", "5 min", 5 }
                });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "Coins", "Hash", "Photo", "Salt", "Username", "isDeleted" },
                values: new object[,]
                {
                    { 1, 5000, "", "", "", "JT", false },
                    { 2, 1000, "", "", "", "Angel", false },
                    { 3, 5000, "", "", "", "Walaa", false },
                    { 4, 50000, "", "", "", "DB", false },
                    { 5, 15000, "", "", "", "Peter", false }
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
                name: "DependentInfo");

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
