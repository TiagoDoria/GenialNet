using Application.DTOs.Fornecedores;
using MediatR;

namespace Application.Queries.Fornecedores.GetAllFornecedores
{
    public class GetAllFornecedoresQuery : IRequest<IEnumerable<FornecedorDTO>>
    {
    }
}
