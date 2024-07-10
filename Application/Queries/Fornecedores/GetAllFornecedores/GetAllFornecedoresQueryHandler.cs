using Application.DTOs.Fornecedores;
using AutoMapper;
using Domain.Repositories.Fornecedores;
using MediatR;

namespace Application.Queries.Fornecedores.GetAllFornecedores
{
    public class GetAllFornecedoresQueryHandler : IRequestHandler<GetAllFornecedoresQuery, IEnumerable<FornecedorDTO>>
    {
        private readonly IFornecedorRepository _repository;
        private readonly IMapper _mapper;
        public GetAllFornecedoresQueryHandler(IFornecedorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FornecedorDTO>> Handle(GetAllFornecedoresQuery request, CancellationToken cancellationToken)
        {
            var fornecedores = await _repository.FindAllAsync();

            return _mapper.Map<IEnumerable<FornecedorDTO>>(fornecedores);
        }
    }
}
