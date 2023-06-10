
using Backend.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

using Practice.Context;
using Practice.Contracts;
using Backend.Configuration;
using Practice.Repositories;
using System.Text;
using Stripe;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BackendDdContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("BankendDbContext") ?? throw new InvalidOperationException("Connection string 'BankendDbContext' not found.")));


// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("HotelConnectionString");
builder.Services.AddControllers();
builder.Services.AddDbContext<BackendDdContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IAuthManager, AuthManager>();
builder.Services.AddAutoMapper(typeof(IMapper));
builder.Services.AddCors(o =>
{
    o.AddPolicy("React", o => o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
builder.Services.AddIdentityCore<ApiUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<BackendDdContext>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
    };
});

builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
app.UseCors("React");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
