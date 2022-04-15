using Microsoft.EntityFrameworkCore;
using scrubby_webapi.Services;
using scrubby_webapi.Services.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped <UserService>();
builder.Services.AddScoped<DependentService>();
builder.Services.AddScoped<SelectedTasksService>();
builder.Services.AddScoped<SelectedItemsInSpaceService>();

builder.Services.AddScoped<SharedSpacesService>();

builder.Services.AddScoped<SpaceInfoService>();
builder.Services.AddScoped<SpaceCollectionService>();
builder.Services.AddScoped<AssignedTasksChildService>();

builder.Services.AddScoped<AssignedTasksUsersService>();
builder.Services.AddScoped<TasksInfoStaticAPIService>();
builder.Services.AddScoped<CleaningProductsStaticAPIService>();
builder.Services.AddScoped<SpaceItemsStaticAPIService>();



var ConnectionString = builder.Configuration.GetConnectionString("MyScrubbyString");

builder.Services.AddDbContext<DataContext>(Options => Options.UseSqlServer(ConnectionString));

builder.Services.AddCors(options => {
options.AddPolicy("ScrubbyPolicy",
builder => {builder.WithOrigins("http://localhost:19000", "http://localhost:19001","http://localhost:19002")
    .AllowAnyHeader()
    .AllowAnyMethod();
});
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseCors("ScrubbyPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
