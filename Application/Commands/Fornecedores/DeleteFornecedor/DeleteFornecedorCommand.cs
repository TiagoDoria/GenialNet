using MediatR;

namespace Application.Commands.Fornecedores.DeleteFornecedor
{
    public class DeleteFornecedorCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteFornecedorCommand(Guid _id)
        {
            Id = _id;
        }
    }
}
