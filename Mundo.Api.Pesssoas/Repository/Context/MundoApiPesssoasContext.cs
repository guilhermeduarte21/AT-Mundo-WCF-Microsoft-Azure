using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mundo.Api.Pesssoas.Domain.Pessoa;

namespace Mundo.Api.Pesssoas.Repository.Context
{
    public class MundoApiPesssoasContext : DbContext
    {
        public MundoApiPesssoasContext (DbContextOptions<MundoApiPesssoasContext> options)
            : base(options)
        {
        }

        public DbSet<Mundo.Api.Pesssoas.Domain.Pessoa.Pessoas> Pessoas { get; set; }
    }
}
