using System.Text;
using MasterLoyaltyStore.API.Configuration;
using MasterLoyaltyStore.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
var jwtString = builder.Configuration["Jwt:key"];
services.AddDbContext<StoreDbContext>(options =>
{
    options.UseMySql(connectionString,new MySqlServerVersion(new Version(8, 0, 21)));
});

services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
services.AddOpenApi();

//Add ServiceCollection
services.AddServices();

//DbContext 

//Configuracion Auth
services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
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

services.AddCors(options =>
{
    options.AddPolicy("NewPolicy", app =>
    {
        app.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

//Validate Roles using Authorize
services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy",policy => policy.RequireClaim("Admin"));
    options.AddPolicy("CustomerPolicy", policy => policy.RequireClaim("Customer"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
