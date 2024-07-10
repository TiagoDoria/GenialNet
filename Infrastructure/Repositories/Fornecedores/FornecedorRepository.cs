using Domain.Models.Fornecedores;
using Domain.Repositories.Fornecedores;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Fornecedores
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly AppDbContext _context;
        public FornecedorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Fornecedor> AddAsync(Fornecedor entity)
        {
            _context.Fornecedores.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                Fornecedor fornecedor =
                await _context.Fornecedores.Where(x => x.Id == id)
                    .FirstOrDefaultAsync() ?? new Fornecedor();

                if (fornecedor.Id == Guid.Empty) return false;
                _context.Fornecedores.Remove(fornecedor);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<IEnumerable<Fornecedor>> FindAllAsync()
        {
            List<Fornecedor> fornecedores = await _context.Fornecedores
                .Include(x => x.Endereco)
                .Include(x => x.Produtos)
                .ToListAsync();
            return fornecedores;
        }

        public async Task<Fornecedor> FindByIdAsync(Guid id)
        {
            Fornecedor fornecedor =
                await _context.Fornecedores.Where(x => x.Id == id)
                .Include(x => x.Endereco)
                .Include(x => x.Produtos)
                .FirstOrDefaultAsync() ?? new Fornecedor();
            return fornecedor;
        }

        public async Task<bool> FindByCnpjAsync(string cnpj)
        {                   
            return await _context.Fornecedores.AnyAsync(x => x.Cnpj == cnpj);
        }

        public async Task<Fornecedor> UpdateAsync(Fornecedor entity)
        {
            _context.Fornecedores.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
