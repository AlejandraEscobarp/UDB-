using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UDB_.Models;

namespace MvcContactanos.Data
{
    public class MvcContactanosContext : DbContext
    {
        public MvcContactanosContext(DbContextOptions<MvcContactanosContext> options)
             : base(options)
        {
        }

        public DbSet<Contactanos> Contactanos { get; set; }
    }
}
