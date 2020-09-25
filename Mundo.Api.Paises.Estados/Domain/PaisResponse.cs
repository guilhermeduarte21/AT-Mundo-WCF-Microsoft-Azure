using System;

namespace Mundo.Api.Paises.Estados.Domain
{
    public class PaisResponse
    {
        public Guid Id { get; set; }
        public string UrlFoto { get; set; }
        public string Nome { get; set; }
    }
}
