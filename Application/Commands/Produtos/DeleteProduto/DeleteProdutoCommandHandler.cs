using Application.Commands.Fornecedores.DeleteFornecedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Produtos.DeleteProduto
{
    public class DeleteProdutoCommandHandler : IRequestHandler<DeleteProdutoCommand, bool>
    {
        private readonly IProdutoRepository _repository;

        public DeleteProdutoCommandHandler(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteProdutoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var produto = await _repository.FindByIdAsync(request.Id);

                if (produto == null)
                {
                    return false;
                }

                await _repository.DeleteAsync(produto.Id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
