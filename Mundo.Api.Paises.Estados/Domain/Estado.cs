using System;
using System.Collections.Generic;
using System.Text;

namespace Mundo.Api.Paises.Estados.Domain
{
    public class Estado
    {
        public Guid Id { get; set; }
        public string UrlFoto { get; set; }
        public string Nome { get; set; }
    }
}
