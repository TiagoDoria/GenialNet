namespace Application.DTOs.Produtos
{
    public class ProdutoEditDTO
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public string Marca { get; set; }
        public string Medida { get; set; }
    }
}
