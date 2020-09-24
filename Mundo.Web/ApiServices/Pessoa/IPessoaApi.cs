using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mundo.Web.Models.Pessoa;

namespace Mundo.Web.ApiServices.Pessoa
{
    public interface IPessoaApi
    {
        Task<List<ListarPessoasViewModel>> GetAsync();
        Task<PessoasViewModel> GetAsync(Guid id);
        Task<EditarViewModel> PutPessoas(Guid id, EditarViewModel editar);
        Task<CriarPessoaViewModel> PostAsync(CriarPessoaViewModel criarPessoaViewModel);
        Task DeletePessoa(Guid id);
    }
}
