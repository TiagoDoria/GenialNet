using Application.DTOs.Fornecedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utils
{
    public static class ValidarFornecedor
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public ValidarFornecedor(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public async static Task ValidarFornecedorAsync(FornecedorDto fornecedorDto)
        {
            if (!Validations.ValidarCnpj(fornecedorDto.Cnpj))
            {
                throw new ValidationException("CNPJ inválido!");
            }

            if (await _fornecedorRepository.FindByCnpjAsync(fornecedorDto.Cnpj))
            {
                throw new ValidationException("Fornecedor já cadastrado!");
            }
        }
    }
}
