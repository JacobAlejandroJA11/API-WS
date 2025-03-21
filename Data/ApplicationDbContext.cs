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

