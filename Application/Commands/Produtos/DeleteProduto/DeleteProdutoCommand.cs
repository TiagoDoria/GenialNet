using MediatR;

namespace Application.Commands.Produtos.DeleteProduto
{
    public class DeleteProdutoCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteProdutoCommand(Guid _id)
        {
            Id = _id;
        }
    }
}
