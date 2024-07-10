namespace Application.DTOs.Produtos
{
    public class ProdutoDTO
    {
        public string Descricao { get; set; }
        public string Marca { get; set; }
        public string Medida { get; set; }
        public Guid FornecedorId { get; set; }
    }
}
