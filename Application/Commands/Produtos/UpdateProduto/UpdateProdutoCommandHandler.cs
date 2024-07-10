using Application.Commands.Fornecedores.UpdateFornecedor;
using Application.DTOs.Fornecedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Produtos.UpdateProduto
{
    public class UpdateProdutoCommandHandler : IRequestHandler<UpdateProdutoCommand, ProdutoEditDTO>
    {
        private readonly IProdutoRepository _repository;
        private readonly IMapper _mapper;

        public UpdateProdutoCommandHandler(IProdutoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProdutoEditDTO> Handle(UpdateProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = _mapper.Map<Produto>(request.Produto);

            await _repository.UpdateAsync(produto);

            return request.Produto;
        }
    }
}
