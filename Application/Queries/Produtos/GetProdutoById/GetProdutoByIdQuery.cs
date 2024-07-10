using Application.DTOs.Fornecedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Produtos.GetProdutoById
{
    public class GetProdutoByIdQuery : IRequest<ProdutoDTO>
    {
        public Guid Id { get; set; }

        public GetProdutoByIdQuery(Guid _id)
        {
            Id = _id;
        }
    }
}
