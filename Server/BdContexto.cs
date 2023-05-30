using Microsoft.EntityFrameworkCore;
using Servicios_Prestamos.Shared.Modelos;

namespace Servicios_Prestamos.Server
{
    public class BdContexto : DbContext
    {
        public BdContexto(DbContextOptions<BdContexto> options) : base(options)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Solicitud_Prestamo> Solicitudes { get; set; }
    }
}
