using Domain.Models.Fornecedores;

namespace Domain.Repositories.Fornecedores
{
    public interface IFornecedorRepository
    {
        Task<IEnumerable<Fornecedor>> FindAllAsync();
        Task<Fornecedor> FindByIdAsync(Guid id);
        Task<Fornecedor> AddAsync(Fornecedor entity);
        Task<Fornecedor> UpdateAsync(Fornecedor entity);
        Task<bool> DeleteAsync(Guid id);
    }
}
