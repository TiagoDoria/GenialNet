using Application.DTOs.Fornecedores;
using Application.DTOs.Produtos;
using Application.Queries.Fornecedores.GetFornecedorById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
