using Application.DTOs.Produtos;
using Domain.Models.Produtos;
using MediatR;

namespace Application.Commands.Produtos.CreateProduto
{
    public class CreateProdutoCommand : IRequest<Produto>
    {
        public ProdutoDTO Produto { get; set; }

        public CreateProdutoCommand(ProdutoDTO _produto)
        {
            Produto = _produto;
        }
    }
}
