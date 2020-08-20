using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Practica_clase.Models;

namespace Practica_clase.Data
{
    public class ProgresoContext : DbContext
    {
        public ProgresoContext (DbContextOptions<ProgresoContext> options)
            : base(options)
        {
        }

        public DbSet<Practica_clase.Models.Progreso> Progreso { get; set; }
    }
}
