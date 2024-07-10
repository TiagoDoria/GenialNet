using Application.DTOs.Produtos;
using System.Collections.ObjectModel;

namespace Application.DTOs.Fornecedores
{
    public class FornecedorDTO
    {
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public EnderecoDTO Endereco { get; set; }
        public Collection<ProdutoDTO> Produtos { get; set; }
    }
}
