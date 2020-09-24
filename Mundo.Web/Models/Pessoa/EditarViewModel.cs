using System;
using System.Collections.Generic;

namespace Mundo.Web.Models.Pessoa
{
    public class EditarViewModel
    {
        public Guid Id { get; set; }
        public string UrlFoto { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataAniversario { get; set; }

        public List<string> Erros { get; set; } = new List<string>();
    }
}
