using Application.DTOs.Fornecedores;

namespace Application.Services
{
    public interface IViaCepService
    {
        Task<EnderecoDTO> GetEnderecoByCepAsync(string cep);
    }
}
