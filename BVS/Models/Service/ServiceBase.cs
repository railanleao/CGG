using BVS.Models.Interface;
using BVS.Models.Interface.IServiceBase;

namespace BVS.Models.Service
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _repositoryBase;

        public ServiceBase(IGenericRepository<TEntity> repositoryBase) =>
                    _repositoryBase = repositoryBase;
        
        public virtual async Task<object> AdicionarAsync(TEntity objeto) =>        
            await _repositoryBase.AdicionarAsync(objeto);        

        public virtual async Task AtualizarAsync(TEntity objeto) => 
            await _repositoryBase.AtualizarAsync(objeto);

        public void Dispose() =>
            _repositoryBase.Dispose();
        public virtual async Task<TEntity?> ObterPorIdAsync(Guid id) =>
           await _repositoryBase.ObterPorIdAsync(id);
        
        public virtual async Task<IEnumerable<TEntity>> ObterTodosAsync() =>
           await _repositoryBase.ObterTodosAsync();

        public virtual async Task RemoverAsync(TEntity objeto) =>
            await _repositoryBase.RemoverAsync(objeto);
        public virtual async Task RemoverPorIdAsync(Guid id) =>
            await _repositoryBase.RemoverPorIdAsync(id);
    }
}
