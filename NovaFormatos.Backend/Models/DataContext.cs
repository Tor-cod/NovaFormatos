using Microsoft.EntityFrameworkCore;
using NovaFormatos.Shared.Data;


namespace NovaFormatos.Backend.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<tblprospectos> tblprospectos { get; set; }
        public DbSet<colonias> colonias { get; set; }
    }
}
