using Domain.Models.Produtos;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Fornecedores
{
    public class Fornecedor
    {
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cnpj { get; set; }
        [Required]
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }
        public Collection<Produto> Produtos { get; set; }
    }
}
