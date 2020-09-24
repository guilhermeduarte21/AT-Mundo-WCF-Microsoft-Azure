using Mundo.Web.Models.Estado;
using Mundo.Web.Models.Pais;
using System;
using System.Collections.Generic;

namespace Mundo.Web.Models.Pessoa
{
    public class PessoasViewModel
    {
        public Guid Id { get; set; }
        public string UrlFoto { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataAniversario { get; set; }
        public virtual List<PessoasViewModel> Amigos { get; set; } = new List<PessoasViewModel>();
        public PaisViewModel PaisOrigiem { get; set; }
        public EstadoViewModel EstadoOrigem { get; set; }
    }
}
