using Application.DTOs.Produtos;
using MediatR;

namespace Application.Commands.Produtos.UpdateProduto
{
    public class UpdateProdutoCommand : IRequest<ProdutoEditDTO>
    {
        public ProdutoEditDTO Produto { get; set; }
        public UpdateProdutoCommand(ProdutoEditDTO _produto)
        {
            Produto = _produto;
        }
    }
}
