using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Fornecedores
{
    public class Endereco
    {
        public Guid Id { get; set; }
        [Required]
        public string Cep { get; set; }
        [Required]
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public string Localidade { get; set; }
        [Required]
        public string Uf { get; set; }
    }
}
