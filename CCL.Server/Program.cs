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

// Add services to the container.

builder.Services.AddControllers();
var secretKey = Environment.GetEnvironmentVariable("MySecretKey");
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
        ValidIssuer = "BackEnd", // Aseg�rate de que coincida con lo que est�s usando al crear el token
        ValidAudience = "FrontEnd", // Aseg�rate de que coincida con lo que est�s usando al crear el token
        IssuerSigningKey = new SymmetricSecurityKey(key) // Usar la misma clave
    };
});

builder.Services.AddScoped<ILoginApplication, LoginApplication>();

builder.Services.AddScoped<ILoginDomain, LoginDomain>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();

builder.Services.AddScoped<Lazy<ILoginRepository>>(sp => new Lazy<ILoginRepository>(() =>   sp.GetRequiredService<ILoginRepository>()));
builder.Services.AddScoped<Lazy<ILoginDomain>>(sp => new Lazy<ILoginDomain>(() => sp.GetRequiredService<ILoginDomain>()));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql("Host=localhost;Port=5432;Database=CLL;Username=postgres;Password=12345678"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // Configuraci�n de autenticaci�n
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


// Configure the HTTP request pipeline.
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