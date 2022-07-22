using BVS.Models.Entity.CompradorAssociado;
using BVS.Models.Entity.ContextBVS;
using BVS.Models.Interface;

namespace BVS.Models.Repositories
{
    public class RepositoryComprador : RepositoryBase<Comprador>, IRepositoryComprador
    {
        public RepositoryComprador(BVSContext context) : base(context)
        {

        }
        
    }   
}
