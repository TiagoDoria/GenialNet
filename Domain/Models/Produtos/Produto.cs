using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Produtos
{
    public class Produto
    {
        public Guid Id { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string Marca { get; set; }
        [Required]
        [EnumDataType(typeof(UnidadeDeMedida), ErrorMessage = "O valor deve ser 'Unidade', 'Quilograma' ou 'Metro'.")]
        public UnidadeDeMedida UnidadeDeMedida { get; set; }
        [Required]
        public decimal Preco { get; set; }
        [Required]
        public Guid FornecedorId { get; set; }
    }
}
