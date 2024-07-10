using Application.DTOs.Fornecedores;
using AutoMapper;
using Domain.Repositories.Fornecedores;
using MediatR;

namespace Application.Queries.Fornecedores.GetFornecedorById
{
    public class GetFornecedorByIdQueryHandler : IRequestHandler<GetFornecedorByIdQuery, FornecedorDTO>
    {
        private readonly IFornecedorRepository _repository;
        private readonly IMapper _mapper;

        public GetFornecedorByIdQueryHandler(IFornecedorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<FornecedorDTO> Handle(GetFornecedorByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var fornecedor = await _repository.FindByIdAsync(request.Id);

                if (fornecedor == null)
                {
                    return null;
                }

                return _mapper.Map<FornecedorDTO>(fornecedor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
