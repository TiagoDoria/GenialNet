using Application.DTOs.Fornecedores;
using Application.DTOs.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Produtos.UpdateProduto
{
    public class UpdateProdutoCommand : IRequest<ProdutoEditDTO>
    {
        public ProdutoEditDTO Produto { get; set; }
        public UpdateProdutoCommand(ProdutoEditDTO _produto)
        {
            Produto = _produto;
        }
    }
}
