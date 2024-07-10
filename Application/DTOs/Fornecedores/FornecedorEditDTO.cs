using Application.DTOs.Fornecedores;
using Application.DTOs.Produtos;
using System.Collections.ObjectModel;

namespace Application.DTOs.Fornecedores
{
    public class FornecedorEditDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public EnderecoEditDTO Endereco { get; set; }
        public Collection<ProdutoEditDTO> Produtos { get; set; }
    }
}
