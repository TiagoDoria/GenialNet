using Application.DTOs.Fornecedores;
using Domain.Repositories.Fornecedores;

namespace Application.Utils
{
    public class ValidarFornecedor
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public ValidarFornecedor(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public async Task<bool> ValidarFornecedorAsync(FornecedorDTO fornecedorDto)
        {
            if (!Validations.ValidarCnpj(fornecedorDto.Cnpj))
            {
                throw new Exception("CNPJ inválido!");
            }

            if (await _fornecedorRepository.FindByCnpjAsync(fornecedorDto.Cnpj))
            {
                throw new Exception("Fornecedor já cadastrado!");
            }

            return true;
        }
    }
}
