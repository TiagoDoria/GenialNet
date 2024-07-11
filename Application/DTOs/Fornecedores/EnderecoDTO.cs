using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Fornecedores
{
    public class EnderecoDTO
    {
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
