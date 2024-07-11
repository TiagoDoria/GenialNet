using Application.DTOs.Produtos;
using MediatR;

namespace Application.Queries.Produtos.GetProdutoById
{
    public class GetProdutoByIdQuery : IRequest<ProdutoDTO>
    {
        public Guid Id { get; set; }

        public GetProdutoByIdQuery(Guid _id)
        {
            Id = _id;
        }
    }
}
