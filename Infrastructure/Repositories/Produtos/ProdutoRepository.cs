using Domain.Models.Produtos;
using Domain.Repositories.Produtos;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Produtos
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;
        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Produto> AddAsync(Produto entity)
        {
            _context.Produtos.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                Produto produto =
                await _context.Produtos.Where(x => x.Id == id)
                    .FirstOrDefaultAsync() ?? new Produto();

                if (produto.Id == Guid.Empty) return false;
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<IEnumerable<Produto>> FindAllAsync()
        {
            List<Produto> produtos = await _context.Produtos.ToListAsync();
            return produtos;
        }

        public async Task<Produto> FindByIdAsync(Guid id)
        {
            Produto produto =
                await _context.Produtos.Where(x => x.Id == id)     
                .FirstOrDefaultAsync() ?? new Produto();
            return produto;
        }

        public async Task<Produto> UpdateAsync(Produto entity)
        {
            _context.Produtos.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
