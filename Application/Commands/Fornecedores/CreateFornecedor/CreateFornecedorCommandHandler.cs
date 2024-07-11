using Application.DTOs.Fornecedores;
using Application.DTOs.Produtos;
using Application.Services;
using Application.Utils;
using AutoMapper;
using Domain.Models.Fornecedores;
using Domain.Models.Produtos;
using Domain.Repositories.Fornecedores;
using Domain.Repositories.Produtos;
using MediatR;

namespace Application.Commands.Fornecedores.CreateFornecedor
{
    public class CreateFornecedorCommandHandler : IRequestHandler<CreateFornecedorCommand, Fornecedor>
    {
        private readonly IFornecedorRepository _repository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        private readonly IViaCepService _viaCepService;

        public CreateFornecedorCommandHandler(IFornecedorRepository repository, IMapper mapper, IViaCepService viaCepService, IProdutoRepository produtoRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _viaCepService = viaCepService;
            _produtoRepository = produtoRepository;
        }

        private async Task ValidarFornecedorAsync(FornecedorDTO fornecedorDto)
        {
            if (!Validations.ValidarCnpj(fornecedorDto.Cnpj))
            {
                throw new Exception("CNPJ inválido!");
            }

            if (await _repository.FindByCnpjAsync(fornecedorDto.Cnpj))
            {
                throw new Exception("Fornecedor já cadastrado!");
            }
        }

        public async Task<Fornecedor> Handle(CreateFornecedorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var fornecedorDto = request.Fornecedor;

                await ValidarFornecedorAsync(fornecedorDto);
                var produtos = fornecedorDto.Produtos.Select(p => _produtoRepository.FindAsync(p.Descricao, p.Marca)).ToList();
                var resultados = await Task.WhenAll(produtos);
                if(resultados.Any(resultado => resultado))
                {
                    throw new Exception("Produto já cadastrado");
                }

                fornecedorDto.Endereco = await _viaCepService.GetEnderecoByCepAsync(fornecedorDto.Endereco.Cep);

                var fornecedor = _mapper.Map<Fornecedor>(fornecedorDto);

                return await _repository.AddAsync(fornecedor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
