using Application.DTOs.Produtos;
using MediatR;

namespace Application.Queries.Produtos.GetAllProdutos
{
    public class GetAllProdutosQuery : IRequest<IEnumerable<ProdutoDTO>>
    {
    }
}
