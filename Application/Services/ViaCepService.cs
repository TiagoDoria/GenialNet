using Application.DTOs.Fornecedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ViaCepService : IViaCepService
    {
        private readonly HttpClient _httpClient;

        public ViaCepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<EnderecoDTO> GetEnderecoByCepAsync(string cep)
        {
            var response = await _httpClient.GetFromJsonAsync<EnderecoDTO>($"https://viacep.com.br/ws/{cep}/json/");
            return response;
        }
    }
}
