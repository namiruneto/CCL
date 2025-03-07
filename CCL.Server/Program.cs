using CLL.Application.Interfaces;
using CLL.Application.Services;
using CLL.Domain.Interfaces;
using CLL.Domain.Services;
using CLL.Infrastructure.Data;
using CLL.Infrastructure.Interfaces;
using CLL.Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                    .WithExposedHeaders("Access-Control-Allow-Origin");
        });
});


builder.Services.AddControllers();
var secretKey = Environment.GetEnvironmentVariable("MySecretKey");
var DbConnection = Environment.GetEnvironmentVariable("DbConnection");
var key = Convert.FromBase64String(secretKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "BackEnd",
        ValidAudience = "FrontEnd", 
        IssuerSigningKey = new SymmetricSecurityKey(key) 
    };
});

builder.Services.AddScoped<ILoginApplication, LoginApplication>();
builder.Services.AddScoped<IProductApplication, ProductApplication>();

builder.Services.AddScoped<ILoginDomain, LoginDomain>();
builder.Services.AddScoped<IProductDomain, ProductDomain>();

builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();


builder.Services.AddScoped<Lazy<ILoginRepository>>(sp => new Lazy<ILoginRepository>(() =>   sp.GetRequiredService<ILoginRepository>()));
builder.Services.AddScoped<Lazy<IProductRepository>>(sp => new Lazy<IProductRepository>(() =>   sp.GetRequiredService<IProductRepository>()));

builder.Services.AddScoped<Lazy<ILoginDomain>>(sp => new Lazy<ILoginDomain>(() => sp.GetRequiredService<ILoginDomain>()));
builder.Services.AddScoped<Lazy<IProductDomain>>(sp => new Lazy<IProductDomain>(() => sp.GetRequiredService<IProductDomain>()));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(DbConnection));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter your token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));

app.MapControllers();

app.Run();