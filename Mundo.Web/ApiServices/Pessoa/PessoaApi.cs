using Mundo.Web.Models.Pessoa;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mundo.Web.ApiServices.Pessoa
{
    public class PessoaApi : IPessoaApi
    {
        public async Task<CriarPessoaViewModel> PostAsync(CriarPessoaViewModel criarPessoaViewModel)
        {
            var criarPessoaViewModelJson = JsonConvert.SerializeObject(criarPessoaViewModel);

            HttpClient httpClient = new HttpClient();

            var conteudo = new StringContent(criarPessoaViewModelJson, Encoding.UTF8, "appication/json");

            var response = await httpClient.PostAsync("https://localhost:44311/api/pessoas", conteudo);

            return criarPessoaViewModel;
        }
    }
}
