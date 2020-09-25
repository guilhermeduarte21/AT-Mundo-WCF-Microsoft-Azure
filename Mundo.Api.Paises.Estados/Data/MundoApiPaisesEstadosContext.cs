using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mundo.Api.Paises.Estados.Domain;

namespace Mundo.Api.Paises.Estados.Data
{
    public class MundoApiPaisesEstadosContext : DbContext
    {
        public MundoApiPaisesEstadosContext (DbContextOptions<MundoApiPaisesEstadosContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pais>().HasMany(x => x.Estados);
        }

        public DbSet<Pais> Pais { get; set; }
        public DbSet<Estado> Estados { get; set; }
    }
}
