using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Restaurante;
using Restaurante.Repository;
using Restaurante.Service;
using Scalar.AspNetCore;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    { 
        In = ParameterLocation.Header,
        Name="Auth",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();

});

// Add services to the container.
builder.Services.AddDbContext<Db>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<Db>()
    .AddDefaultTokenProviders();


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Services
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<VentaService>();
builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<Detalle_VentaService>();

//Repositories
builder.Services.AddScoped<ClienteRepository>();
builder.Services.AddScoped<VentaRepository>();
builder.Services.AddScoped<ProductoRepository>();
builder.Services.AddScoped<Detalle_VentaRepository>();

//Autenticacion
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:7249";
        options.RequireHttpsMetadata = false;
    });
//Agregar autorizacion
builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<Db>();
//Autorizados
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireClaim("role", "admin"));
    options.AddPolicy("User", policy => policy.RequireClaim("role", "user"));
});

// Configurar Scalar
builder.Services.AddScalar(options =>
{
    options.UseAuthentication = true;
    options.UseAuthorization = true;
    options.OpenApiInfo = new OpenApiInfo
    {
        Title = "Restaurante API",
        Version = "v1"
    };
});


var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
