using BVS.Models.Entity.Parceria;
using BVS.Models.Interface;
using BVS.Models.Interface.IServiceBase;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BVS.Models.Service
{
    public class ServiceInicioParceria : ServiceBase<InicioParceria>, IServiceInicioParceria
    {
        public ServiceInicioParceria(IRepositoryInicioParceria repositoryInicioParceria) : base(repositoryInicioParceria)
        {
        }
        //public static decimal? RendCarcaca()
        //{
        //    InicioParceria inicio = new InicioParceria();
        //    var rendCarcaca =(inicio.PesoBruto * 50) / 100;
        //    return rendCarcaca;
        //}
    }
}
