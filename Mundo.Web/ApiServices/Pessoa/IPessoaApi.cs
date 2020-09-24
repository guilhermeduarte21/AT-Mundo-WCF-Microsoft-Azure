using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mundo.Web.Models.Pessoa;

namespace Mundo.Web.ApiServices.Pessoa
{
    public interface IPessoaApi
    {
        Task<CriarPessoaViewModel> PostAsync(CriarPessoaViewModel criarPessoaViewModel);
    }
}
