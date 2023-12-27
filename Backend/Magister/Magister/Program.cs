using Magister.DataAccess;
using Magister.DbInitializer;
using Magister.Services;
using Magister.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Magister.Extentions;
using Magister.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<MagisterContext>(option => option.UseNpgsql("Host=localhost;Port=5432;Database=postgres_magister;Username=postgres;Password=Qwe123!!"));
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.AddScoped<DbContext, MagisterContext>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IDatabaseInitializer, DatabaseInitializer>();

builder.Services.AddIdentity<User, Role>(opts =>
{
    // Настройка перевірки пароля
    opts.Password.RequiredLength = 4;
    opts.Password.RequireNonAlphanumeric = false;
    opts.Password.RequireLowercase = false;
    opts.Password.RequireUppercase = false;
    opts.Password.RequireDigit = false;
})
.AddEntityFrameworkStores<MagisterContext>()
.AddDefaultTokenProviders();

var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<Lesson>("Lessons");
modelBuilder.EntitySet<Student>("Students");
modelBuilder.EnableLowerCamelCase();
var edmModel = modelBuilder.GetEdmModel();

// Register OData service.
builder.Services.AddControllers().AddOData(
    options => options.EnableQueryFeatures().AddRouteComponents(edmModel));



var app = builder.Build().SeedDatabase();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

// allow origin http://localhost:4200/
app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
