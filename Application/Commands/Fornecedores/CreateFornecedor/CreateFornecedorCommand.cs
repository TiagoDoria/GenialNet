using Application.DTOs.Fornecedores;
using Domain.Models.Fornecedores;
using MediatR;

namespace Application.Commands.Fornecedores.CreateFornecedor
{
    public class CreateFornecedorCommand : IRequest<Fornecedor>
    {
        public FornecedorDTO Fornecedor { get; set; }

        public CreateFornecedorCommand(FornecedorDTO _fornecedor)
        {
            Fornecedor = _fornecedor;
        }
    }
}
