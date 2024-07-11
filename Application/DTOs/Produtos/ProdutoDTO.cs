using Domain.Models.Produtos;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Produtos
{
    public class ProdutoDTO
    {
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string Marca { get; set; }
        [Required]
        public UnidadeDeMedidaDTO UnidadeDeMedida { get; set; }
        [Required]
        public decimal Preco { get; set; }
        public Guid FornecedorId { get; set; }
    }
}
