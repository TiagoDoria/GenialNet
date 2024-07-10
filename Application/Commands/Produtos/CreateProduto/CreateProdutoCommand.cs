using Application.DTOs.Produtos;

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
