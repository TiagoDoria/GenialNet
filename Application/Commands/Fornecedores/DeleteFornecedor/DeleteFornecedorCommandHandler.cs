using Domain.Repositories.Fornecedores;
using MediatR;

namespace Application.Commands.Fornecedores.DeleteFornecedor
{
    public class DeleteFornecedorCommandHandler : IRequestHandler<DeleteFornecedorCommand, bool>
    {
        private readonly IFornecedorRepository _repository;

        public DeleteFornecedorCommandHandler(IFornecedorRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteFornecedorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var fornecedor = await _repository.FindByIdAsync(request.Id);

                if (fornecedor == null)
                {
                    return false; 
                }

                await _repository.DeleteAsync(fornecedor.Id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
