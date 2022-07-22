using BVS.Models.Entity.ContextBVS;
using BVS.Models.Entity.Parceria;
using BVS.Models.Interface;
using Microsoft.EntityFrameworkCore;

namespace BVS.Models.Repositories
{
    public class RepositoryInicioParceria : RepositoryBase<InicioParceria>, IRepositoryInicioParceria
    {
        public RepositoryInicioParceria(BVSContext context) : base(context)
        {
        }
        public async override Task<IEnumerable<InicioParceria>> ObterTodosAsync()
        {
            return await _context.InicioParcerias
                .Include(i => i.Comprador)
                .Include(i => i.Associado)
                .AsSingleQuery()
                .ToListAsync();
        }
        public async override Task<InicioParceria?> ObterPorIdAsync(Guid id)
        {
            return await _context.InicioParcerias
                .Include(i => i.Comprador)
                .Include(i => i.Associado)
                .Where(i => i.BoiId == id)
                .AsSingleQuery()
                .FirstOrDefaultAsync();
        }      
    }
}
