using Application.DTOs.Produtos;
using AutoMapper;
using Domain.Models.Produtos;
using Domain.Repositories.Produtos;
using MediatR;

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

        private async Task ValidarProdutoAsync(ProdutoDTO produtoDto)
        {
            if (await _repository.FindAsync(produtoDto.Descricao, produtoDto.Marca))
            {
                throw new Exception("Produto já cadastrado!");
            }
        }

        public async Task<Produto> Handle(CreateProdutoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var produtoDto = request.Produto;

                await ValidarProdutoAsync(produtoDto);

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
