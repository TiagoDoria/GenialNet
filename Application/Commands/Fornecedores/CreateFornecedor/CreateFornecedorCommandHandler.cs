using Application.Services;
using Application.Utils;
using AutoMapper;
using Domain.Models.Fornecedores;
using Domain.Repositories.Fornecedores;
using MediatR;

namespace Application.Commands.Fornecedores.CreateFornecedor
{
    public class CreateFornecedorCommandHandler : IRequestHandler<CreateFornecedorCommand, Fornecedor>
    {
        private readonly IFornecedorRepository _repository;
        private readonly IMapper _mapper;
        private readonly IViaCepService _viaCepService;

        public CreateFornecedorCommandHandler(IFornecedorRepository repository, IMapper mapper, IViaCepService viaCepService)
        {
            _repository = repository;
            _mapper = mapper;
            _viaCepService = viaCepService;
        }

        public async Task<Fornecedor> Handle(CreateFornecedorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var fornecedorDto = request.Fornecedor;

                await ValidarFornecedor.ValidarFornecedorAsync(fornecedorDto);

                //if (!Validations.ValidarCnpj(fornecedorDto.Cnpj))
                //{
                //    throw new Exception("CNPJ inválido!");
                //}

                //if(await _repository.Fornecedores.FindByCnpjAsync(fornecedorDto.Cnpj))
                //{
                //    throw new Exception("Fornecedor já cadastrado!");
                //}

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
