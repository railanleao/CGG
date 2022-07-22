using BVS.Models.Entity.CompradorAssociado;
using BVS.Models.Interface;
using BVS.Models.Interface.IServiceBase;

namespace BVS.Models.Service
{
    public class ServiceAssociado : ServiceBase<Associado>, IServiceAssociado
    {
        public ServiceAssociado(IRepositoryAssociado repositoryAssociado) : base(repositoryAssociado)
        {
        }
    }
}
