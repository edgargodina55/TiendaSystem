using System.Text;
using AutoMapper;
using MasterLoyaltyStore.API.Configuration;
using MasterLoyaltyStore.Data.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
var jwtString = builder.Configuration["Jwt:key"];

services.AddDbContext<StoreDbContext>(options =>
{
    options.UseMySql(
        connectionString,
        new MySqlServerVersion(new Version(8, 0, 21)),
        // 👇 le decimos explícitamente dónde van las migraciones
        b => b.MigrationsAssembly("MasterLoyaltyStore.Data")
    );
});


services.AddControllers();

// 🔴 AutoMapper manual para v15
var loggerFactory = LoggerFactory.Create(logging =>
{
    logging.AddConsole();
});
var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
}, loggerFactory);
IMapper mapper = mapperConfig.CreateMapper();
services.AddSingleton(mapper);

// tus servicios
services.AddServices();

// 👇 CORS: lo defines
builder.Services.AddCors(options =>
{
    options.AddPolicy("AngularClient", policy =>
    {
        policy
            .WithOrigins("http://localhost:4200")   // origen de Angular
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Auth
services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtString!))
    };
});

// Roles/policies
services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireClaim("Admin"));
    options.AddPolicy("CustomerPolicy", policy => policy.RequireClaim("Customer"));
});

services.AddOpenApi();

var app = builder.Build();

// pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// 👇 👇 👇 AQUÍ es donde te faltaba
app.UseCors("AngularClient");

// si usas JWT tienes que poner esto también
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
