using Mundo.Domain.Mundo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mundo.Domain.Pessoa
{
    public class Pessoas
    {
        public Guid Id { get; set; }
        public string UrlFoto { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataAniversario { get; set; }
        public virtual List<Pessoas> Amigos { get; set; } = new List<Pessoas>();
        public Pais PaisOrigiem { get; set; }
        public Estado EstadoOrigem { get; set; }
    }
}
