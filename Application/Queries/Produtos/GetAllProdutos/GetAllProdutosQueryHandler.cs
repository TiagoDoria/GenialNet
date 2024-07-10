using Application.DTOs.Fornecedores;
using Application.DTOs.Produtos;
using Application.Queries.Fornecedores.GetAllFornecedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Produtos.GetAllProdutos
{
    public class GetAllProdutosQueryHandler : IRequestHandler<GetAllProdutosQuery, IEnumerable<ProdutoDTO>>
    {
        private readonly IProdutoRepository _repository;
        private readonly IMapper _mapper;
        public GetAllProdutosQueryHandler(IProdutoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoDTO>> Handle(GetAllProdutosQuery request, CancellationToken cancellationToken)
        {
            var produtos = await _repository.FindAllAsync();

            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
        }
    }
}
