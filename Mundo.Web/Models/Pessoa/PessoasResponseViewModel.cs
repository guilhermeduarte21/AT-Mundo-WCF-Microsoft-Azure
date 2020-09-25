using System;

namespace Mundo.Web.Models.Pessoa
{
    public class PessoasResponseViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
