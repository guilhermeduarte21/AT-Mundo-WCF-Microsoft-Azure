using System;
using System.Collections.Generic;
using System.Text;

namespace Mundo.Domain.Paises.Estado.Mundo
{
    public class Pais
    {
        public Guid Id { get; set; }
        public string UrlFoto { get; set; }
        public string Nome { get; set; }
        public virtual List<Estado> Estados { get; set; } = new List<Estado>();
    }
}
