namespace BVS.Models.Interface
{
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<IEnumerable<TEntity>> ObterTodosAsync();
        Task<TEntity?> ObterPorIdAsync(Guid id);
        Task<object> AdicionarAsync(TEntity objeto);
        Task AtualizarAsync(TEntity objeto);
        Task RemoverAsync(TEntity objeto);
        Task RemoverPorIdAsync(Guid id);
       
    }
}
