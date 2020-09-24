using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mundo.Api.Pessoas.Domain;

namespace Mundo.Api.Pessoas.Data
{
    public class MundoApiPessoasContext : DbContext
    {
        public MundoApiPessoasContext (DbContextOptions<MundoApiPessoasContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Domain.Pessoas>()
                .HasMany(x => x.Amigos);
        }

        public DbSet<Domain.Pessoas> Pessoas { get; set; }
    }
}
