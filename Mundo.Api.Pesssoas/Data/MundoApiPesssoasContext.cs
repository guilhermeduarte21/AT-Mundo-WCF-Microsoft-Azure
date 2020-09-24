using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mundo.Api.Pesssoas.Domain.Pessoa;

namespace Mundo.Api.Pesssoas.Data
{
    public class MundoApiPesssoasContext : DbContext
    {
        public MundoApiPesssoasContext (DbContextOptions<MundoApiPesssoasContext> options) : base(options)
        {

        }

        public DbSet<Pessoas> Pessoas { get; set; }
    }
}
