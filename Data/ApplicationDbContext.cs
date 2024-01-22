using AgendaContactos.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaContactos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Contacto> contactos { get; set; }
    }
}
