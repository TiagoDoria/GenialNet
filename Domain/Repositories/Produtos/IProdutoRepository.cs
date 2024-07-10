using Domain.Models.Produtos;

namespace Domain.Repositories.Produtos
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> FindAllAsync();
        Task<Produto> FindByIdAsync(Guid id);
        Task<Produto> AddAsync(Produto entity);
        Task<Produto> UpdateAsync(Produto entity);
        Task<bool> DeleteAsync(Guid id);
    }
}
