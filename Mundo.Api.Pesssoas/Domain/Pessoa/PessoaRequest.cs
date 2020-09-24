using System;
using Mundo.Api.Pesssoas.Domain.Mundo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mundo.Api.Pesssoas.Domain.Pessoa
{
    public class PessoaRequest
    {
        public string UrlFoto { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataAniversario { get; set; }
        public Pais PaisOrigiem { get; set; }
        public Estado EstadoOrigem { get; set; }
    }
}
