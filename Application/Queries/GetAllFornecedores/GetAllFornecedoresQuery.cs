using Application.DTOs.Fornecedores;
using MediatR;

namespace Application.Queries.GetAllFornecedores
{
    public class GetAllFornecedoresQuery : IRequest<IEnumerable<FornecedorDTO>>
    {
    }
}
