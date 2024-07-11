using Application.DTOs.Produtos;
using AutoMapper;
using Domain.Repositories.Produtos;
using MediatR;

namespace Application.Queries.Produtos.GetProdutoById
{
    public class GetProdutoByIdQueryHandler : IRequestHandler<GetProdutoByIdQuery, ProdutoDTO>
    {
        private readonly IProdutoRepository _repository;
        private readonly IMapper _mapper;

        public GetProdutoByIdQueryHandler(IProdutoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProdutoDTO> Handle(GetProdutoByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var produto = await _repository.FindByIdAsync(request.Id);

                if (produto == null)
                {
                    return null;
                }

                return _mapper.Map<ProdutoDTO>(produto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
