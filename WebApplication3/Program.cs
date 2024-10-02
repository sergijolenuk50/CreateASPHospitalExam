using Core.MapperProfiles;
using Core.Services;
using Core.Interfaces;
using Data.Data;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Middlewares;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using WebApplication3.ServiceExtensions;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("HospitalDbContextConnection") ?? throw new InvalidOperationException("Connection string 'HospitalDbContextConnection' not found.");



//builder.Services.AddDbContext<HospitalDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDbContext(connectionString);
builder.Services.AddIdentity();
builder.Services.AddRepository();

//builder.Services.AddIdentity<User, IdentityRole>(options =>
//    options.SignIn.RequireConfirmedAccount = false)
//    .AddDefaultTokenProviders()
//    .AddEntityFrameworkStores<HospitalDbContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// fluent validators
//builder.Services.AddFluentValidationAutoValidation();
//builder.Services.AddFluentValidationClientsideAdapters();
//builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddFluentValidators();
//builder.Services.AddAutoMapper(typeof(AppProfile));
builder.Services.AddAutoMapper();
// custom services
builder.Services.AddCustomServices();
//builder.Services.AddScoped<ICategoryService, CategoryService>();
//builder.Services.AddScoped<IDoctorsService, DoctorsService>();
//builder.Services.AddScoped<IAccountsService, AccountsService>();
//builder.Services.AddScoped<IJwtService, JwtService>();


//builder.Services.AddSwaggerGen(options =>
//{
//    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
//    {
//        Name = "Authorization",
//        In = ParameterLocation.Header,
//        Type = SecuritySchemeType.Http,
//        Scheme = "Bearer"
//    });

//    options.AddSecurityRequirement(new OpenApiSecurityRequirement
//                {
//                    {
//                        new OpenApiSecurityScheme
//                        {
//                            Reference = new OpenApiReference
//                            {
//                                Type = ReferenceType.SecurityScheme,
//                                Id = "Bearer"
//                            }
//                        },
//                        Array.Empty<string>()
//                    }
//                });
//});


builder.Services.AddJWT(builder.Configuration);
builder.Services.AddSwaggerJWT();

//builder.Services.AddSingleton(_ =>
//              builder.Configuration
//                  .GetSection(nameof(JwtOptions))
//                  .Get<JwtOptions>()!);

//var jwtOpts = builder.Configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>()!;

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//                .AddJwtBearer(o =>
//                {
//                    o.TokenValidationParameters = new TokenValidationParameters
//                    {
//                        ValidateIssuer = true,
//                        ValidateAudience = false,
//                        ValidateLifetime = true,
//                        ValidateIssuerSigningKey = true,
//                        ValidIssuer = jwtOpts.Issuer,
//                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOpts.Key)),
//                        ClockSkew = TimeSpan.Zero
//                    };
//                });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
