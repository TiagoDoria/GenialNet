using Application.DTOs.Fornecedores;
using AutoMapper;
using Domain.Models.Fornecedores;
using Domain.Repositories.Fornecedores;
using MediatR;

namespace Application.Commands.Fornecedores.UpdateFornecedor
{
    public class UpdateFornecedorCommandHandler : IRequestHandler<UpdateFornecedorCommand, FornecedorEditDTO>
    {
        private readonly IFornecedorRepository _repository;
        private readonly IMapper _mapper;

        public UpdateFornecedorCommandHandler(IFornecedorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<FornecedorEditDTO> Handle(UpdateFornecedorCommand request, CancellationToken cancellationToken)
        {
            var fornecedor = _mapper.Map<Fornecedor>(request.Fornecedor);

            await _repository.UpdateAsync(fornecedor);

            return request.Fornecedor;
        }
    }
}
