using Application.DTOs.Produtos;
using AutoMapper;
using Domain.Repositories.Produtos;
using MediatR;

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
