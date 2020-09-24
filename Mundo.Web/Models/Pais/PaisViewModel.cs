using Mundo.Web.Models.Estado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mundo.Web.Models.Pais
{
    public class PaisViewModel
    {
        public Guid Id { get; set; }
        public string UrlFoto { get; set; }
        public string Nome { get; set; }
        public virtual List<EstadoViewModel> Estados { get; set; } = new List<EstadoViewModel>();
    }
}
