using Application.DTOs.Produtos;
using AutoMapper;
using Domain.Models.Produtos;
using Domain.Repositories.Produtos;
using MediatR;

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
