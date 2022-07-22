using BVS.Models.Entity.Parceria;
using BVS.Models.Interface;
using BVS.Models.Interface.IServiceBase;

namespace BVS.Models.Service
{
    public class ServiceAlteracaoSaida : ServiceBase<AlteracaoSaida>, IServiceAlteracaoSaida
    {
        public ServiceAlteracaoSaida(IRepositoryAlteracaoSaida repositoryAlteracaoSaida) : base(repositoryAlteracaoSaida)
        {
        }
    }
}
