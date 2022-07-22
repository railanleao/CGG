using BVS.Models.Entity.CompradorAssociado;
using BVS.Models.Interface;
using BVS.Models.Interface.IServiceBase;

namespace BVS.Models.Service
{
    public class ServiceComprador : ServiceBase<Comprador>, IServiceComprador
    {
        public ServiceComprador(IRepositoryComprador repositoryComprador) : base(repositoryComprador)
        {
        }
    }
}
