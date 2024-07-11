using Application.DTOs.Produtos;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Fornecedores
{
    public class FornecedorDTO
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cnpj { get; set; }
        [Required]
        public string Telefone { get; set; }
        public EnderecoDTO Endereco { get; set; }
        public Collection<ProdutoDTO> Produtos { get; set; }
    }
}
