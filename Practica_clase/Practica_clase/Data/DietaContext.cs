using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Practica_clase.Models;

namespace Practica_clase.Data
{
    public class DietaContext : DbContext
    {
        public DietaContext (DbContextOptions<DietaContext> options)
            : base(options)
        {
        }

        public DbSet<Practica_clase.Models.Dieta> Dieta { get; set; }
    }
}
