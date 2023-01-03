using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todean_Olaeriu.Models;

namespace Todean_Olaeriu.Data
{
    public class Todean_OlaeriuContext : DbContext
    {
        public Todean_OlaeriuContext (DbContextOptions<Todean_OlaeriuContext> options)
            : base(options)
        {
        }

        public DbSet<Todean_Olaeriu.Models.Serviciu> Serviciu { get; set; } = default!;

        public DbSet<Todean_Olaeriu.Models.Orar> Orar { get; set; }

        public DbSet<Todean_Olaeriu.Models.Medic> Medic { get; set; }

        public DbSet<Todean_Olaeriu.Models.Specialitate> Specialitate { get; set; }
    }
}
