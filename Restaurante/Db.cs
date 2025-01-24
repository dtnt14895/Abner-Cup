using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurante.Models;

namespace Restaurante
{
    public class Db : IdentityDbContext
    {
        public Db(DbContextOptions<Db> options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Detalle_Venta> Detalle_Ventas { get; set; }
    }
}
