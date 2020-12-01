using Microsoft.EntityFrameworkCore;
using UDB_.Models;

namespace MvcCarreras.Data
{
    public class MvcCarrerasContext : DbContext
    {
        public MvcCarrerasContext(DbContextOptions<MvcCarrerasContext> options)
            : base(options)
        {
        }

        public DbSet<Carreras> Carreras { get; set; }
    }
}