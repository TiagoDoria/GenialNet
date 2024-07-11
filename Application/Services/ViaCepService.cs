using Application.DTOs.Fornecedores;
using System.Net.Http.Json;
using System.Text.RegularExpressions;

namespace Application.Services
{
    public class ViaCepService : IViaCepService
    {
        private readonly HttpClient _httpClient;
        private static readonly Regex CepRegex = new Regex(@"^\d{5}-?\d{3}$");

        public ViaCepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<EnderecoDTO> GetEnderecoByCepAsync(string cep)
        {
            if (!IsValidCep(cep))
            {
                throw new Exception("CEP inválido!");
            }
            var response = await _httpClient.GetFromJsonAsync<EnderecoDTO>($"https://viacep.com.br/ws/{cep}/json/");
            return response;
        }

        private bool IsValidCep(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep))
            {
                return false;
            }

            return CepRegex.IsMatch(cep);
        }
    }
}
