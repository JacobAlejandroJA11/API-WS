using WebServiceEmpleados.Data; // Referencia al contexto de datos
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de servicios
builder.Services.AddControllers(); // Habilita controladores para rutas API
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptions => sqlServerOptions.EnableRetryOnFailure(
            maxRetryCount: 5, // N�mero de intentos de reintento
            maxRetryDelay: TimeSpan.FromSeconds(10), // M�ximo tiempo de espera entre intentos
            errorNumbersToAdd: null // Errores espec�ficos a incluir (null para todos los errores transitorios)
        )
    )
); // Configuraci�n de la base de datos

var app = builder.Build();

// Configuraci�n del middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Muestra errores en desarrollo
}

app.UseHttpsRedirection(); // Redirecciona las solicitudes HTTP a HTTPS
app.UseRouting(); // Habilita enrutamiento para las rutas API
app.UseAuthorization(); // Habilita autorizaci�n (si aplicas seguridad m�s adelante)

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Mapea las rutas a los controladores
});

app.Run(); // Inicia la aplicaci�n








/*using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
// El namespace donde se encuentra tu ApplicationDbContext
using WebServiceEmpleados.Data; // Aseg�rate de incluir tu namespace
using Microsoft.EntityFrameworkCore;


using Microsoft.EntityFrameworkCore;
using WebServiceEmpleados.Models;

namespace WebServiceEmpleados.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Area> Areas { get; set; }
    }
}




var builder = WebApplication.CreateBuilder(args);

// Configura servicios
builder.Services.AddControllers(); // Habilita controladores para el uso de rutas API
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Conexi�n a la base de datos
// Add services to the container.
builder.Services.AddRazorPages();
var app = builder.Build();

// Configura middleware
if (app.Environment.IsDevelopment()) // Configuraci�n para desarrollo
{
    app.UseDeveloperExceptionPage(); // P�gina para ver errores en desarrollo
}

app.UseRouting(); // Habilita el enrutamiento
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Mapea las rutas para los controladores
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.Run(); // Arranca la aplicaci�n*/
