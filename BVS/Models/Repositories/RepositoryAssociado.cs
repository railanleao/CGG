using BVS.Models.Entity.CompradorAssociado;
using BVS.Models.Entity.ContextBVS;
using BVS.Models.Interface;
using Microsoft.EntityFrameworkCore;

namespace BVS.Models.Repositories
{
    public class RepositoryAssociado : RepositoryBase<Associado>, IRepositoryAssociado
    {
        public RepositoryAssociado(BVSContext context) : base(context)
        {
        }
        public async override Task<IEnumerable<Associado>> ObterTodosAsync()
        {
            return await _context.Associados
                .Include(a => a.Comprador)
                .AsSingleQuery()
                .ToListAsync();
        }
        public async override Task<Associado?> ObterPorIdAsync(Guid id)
        {
            return await _context.Associados
                .Include(a => a.Comprador)
                .Where(a => a.CadastroId == id)
                .AsSingleQuery()
                .FirstOrDefaultAsync();
           //     .FirstOrDefaultAsync(a => a.Equals(id));
        }
    }
}
