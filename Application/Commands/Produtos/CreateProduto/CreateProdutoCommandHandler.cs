using Application.Commands.Fornecedores.CreateFornecedor;
using Application.Services;
using Application.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Produtos.CreateProduto
{
    public class CreateProdutoCommandHandler : IRequestHandler<CreateProdutoCommand, Produto>
    {
        private readonly IProdutoRepository _repository;
        private readonly IMapper _mapper;

        public CreateProdutoCommandHandler(IProdutoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Produto> Handle(CreateProdutoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var produtoDto = request.Produto;   

                var produto = _mapper.Map<Produto>(produtoDto);

                return await _repository.AddAsync(produto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
