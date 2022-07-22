using BVS.Models.Entity.ContextBVS;
using BVS.Models.Entity.Parceria;
using BVS.Models.Interface;
using Microsoft.EntityFrameworkCore;

namespace BVS.Models.Repositories
{
    public class RepositoryAlteracaoSaida : RepositoryBase<AlteracaoSaida>, IRepositoryAlteracaoSaida
    {
        public RepositoryAlteracaoSaida(BVSContext context) : base(context)
        {
        }
        public async override Task<IEnumerable<AlteracaoSaida>> ObterTodosAsync()
        {
            return await _context.AlteracaoSaidas
                .Include(ats => ats.Comprador)
                .Include(ats => ats.Associado)
                .Include(ats => ats.InicioParceria)
                .AsSingleQuery()                
                .ToListAsync();
        }
        public async override Task<AlteracaoSaida?> ObterPorIdAsync(Guid id)
        {
            return await _context.AlteracaoSaidas
                .Include(ats => ats.Comprador)
                .Include(ats => ats.Associado)
                .Include(ats => ats.InicioParceria)
                .Where(ats => ats.InicioParceriaId == id)
                .AsSingleQuery()
                .FirstOrDefaultAsync();
        }
    }
}
