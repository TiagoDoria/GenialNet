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
        public string Medida { get; set; }
        public Guid FornecedorId { get; set; }
    }
}
