namespace Application.DTOs.Fornecedores
{
    public class EnderecoEditDTO
    {
        public Guid Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public Guid FornecedorId { get; set; }
    }
}
