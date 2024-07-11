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
        [RegularExpression(@"\d{14}", ErrorMessage = "CNPJ inválido")]
        public string Cnpj { get; set; }
        [Required]
        [RegularExpression(@"\d{10,11}", ErrorMessage = "Telefone inválido")]
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }
        public Collection<Produto> Produtos { get; set; }
    }
}
