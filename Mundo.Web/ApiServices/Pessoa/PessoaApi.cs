using Mundo.Web.Models.Pessoa;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Mundo.Web.ApiServices.Pessoa
{
    public class PessoaApi : IPessoaApi
    {
        private readonly HttpClient _httpClient;

        public PessoaApi()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.BaseAddress = new Uri("https://localhost:44311/api/pessoas");
        }

        public async Task<List<ListarPessoasViewModel>> GetAsync()
        {
            var response = await _httpClient.GetAsync("api/Amigos");

            var responseContent = await response.Content.ReadAsStringAsync();

            var list = JsonConvert.DeserializeObject<List<ListarPessoasViewModel>>(responseContent);

            return list;
        }

        public async Task<PessoasViewModel> GetAsync(Guid id)
        {
            var response = await _httpClient.GetAsync("api/Amigos/" + id);

            var responseContent = await response.Content.ReadAsStringAsync();

            var pessoa = JsonConvert.DeserializeObject<PessoasViewModel>(responseContent);

            return pessoa;
        }

        public async Task<EditarViewModel> PutPessoas(Guid id, EditarViewModel editarViewModel)
        {
            var editarViewModelJson = JsonConvert.SerializeObject(editarViewModel);

            var conteudo = new StringContent(editarViewModelJson, Encoding.UTF8, "appication/json");

            var response = await _httpClient.PutAsync("api/Amigos/" + id, conteudo);

            if (response.IsSuccessStatusCode)
            {
                return editarViewModel;
            }
            else
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var erros = JsonConvert.DeserializeObject<List<string>>(responseContent);

                editarViewModel.Erros = erros;
            }

            return editarViewModel;
        }

        public async Task<CriarPessoaViewModel> PostAsync(CriarPessoaViewModel criarPessoaViewModel)
        {
            var criarPessoaViewModelJson = JsonConvert.SerializeObject(criarPessoaViewModel);

            var conteudo = new StringContent(criarPessoaViewModelJson, Encoding.UTF8, "appication/json");

            var response = await _httpClient.PostAsync("api/Amigos", conteudo);

            if (response.IsSuccessStatusCode)
            {
                return criarPessoaViewModel;
            }
            else
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var erros = JsonConvert.DeserializeObject<List<string>>(responseContent);

                criarPessoaViewModel.Erros = erros;
            }

            return criarPessoaViewModel;
        }

        public async Task DeletePessoa(Guid id)
        {
            var response = await _httpClient.DeleteAsync("api/Amigos/" + id);
        }
    }
}
