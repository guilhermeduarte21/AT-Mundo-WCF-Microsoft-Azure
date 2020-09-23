using System;
using System.Collections.Generic;

namespace Mundo.Api.Pesssoas.Domain.Mundo
{
    public class Pais
    {
        public Guid Id { get; set; }
        public string UrlFoto { get; set; }
        public string Nome { get; set; }
        public virtual List<Estado> Estados { get; set; } = new List<Estado>();
    }
}