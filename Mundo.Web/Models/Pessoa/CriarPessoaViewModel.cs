using Mundo.Web.Models.Estado;
using Mundo.Web.Models.Pais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mundo.Web.Models.Pessoa
{
    public class CriarPessoaViewModel
    {
        public string UrlFoto { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataAniversario { get; set; }
        public PaisViewModel PaisOrigiem { get; set; }
        public EstadoViewModel EstadoOrigem { get; set; }

        public List<string> Erros { get; set; } = new List<string>();
    }
}
