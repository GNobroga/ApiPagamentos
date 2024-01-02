using System.Text;
using ApiPagamentos.Authentication;
using ApiPagamentos.Extensions;
using ApiPagamentos.ValueObjects.Mapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt => {
        opt.TokenValidationParameters = new() {
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]!))
        };
    });


builder.Services.AddSwaggerGen(opt => {
    opt.SwaggerDoc("v1", new OpenApiInfo {
        Title = "Vendas API",
        Description = "Uma API para cadastro e visualização de vendas",
        Version = "1.0.0",
        Contact = new OpenApiContact {
            Email = "gabrielcardosogirarde@gmail.com",
            Name = "Gabriel Cardoso",
        }
    });
});

builder.Services.AddApiVersioning();

builder.Services.AddAutoMapper(opt => opt.AddProfile<MapperProfile>());

builder.AddApiDbContext();

builder.Services.AddSingleton<Jwt>();
builder.Services.Configure<Jwt>(builder.Configuration.GetSection("Jwt"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(opt => {
        opt.RouteTemplate = "api-docs/{documentName}/swagger.json";
    });
    app.UseSwaggerUI(opt => {
        opt.SwaggerEndpoint("/api-docs/v1/swagger.json", "Vendas API V1");
    });
}

app.AddMigration(builder.Configuration.GetConnectionString("DefaultConnection")!);

app.UseAuthorization();

app.MapControllers();

app.UseApiVersioning();

app.Run();
