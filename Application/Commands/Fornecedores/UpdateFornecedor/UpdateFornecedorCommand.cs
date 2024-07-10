using Application.DTOs.Fornecedores;
using MediatR;

namespace Application.Commands.Fornecedores.UpdateFornecedor
{
    public class UpdateFornecedorCommand : IRequest<FornecedorEditDTO>
    {
        public FornecedorEditDTO Fornecedor { get; set; }
        public UpdateFornecedorCommand(FornecedorEditDTO _fornecedor)
        {
            Fornecedor = _fornecedor;
        }
    }
}
