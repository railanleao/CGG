using BVS.Models.Entity.Parceria;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace BVS.Models.Request
{
    public class InsercaoAlteracaoSaidaRequest
    {
        public Guid BoiId { get; set; }
        public decimal? PesoMedioAlterado { get; set; }
        public decimal PesoBruto { get; set; }
        public decimal Arroba { get; set; }
        public decimal RendimentoCarcaca { get; set; }
        public DateTime Saida { get; set; }
        public Guid IdComprador { get; set; }
        public Guid IdAssociado { get; set; }
        public Guid? InicioParceriaId { get; set; }
        public Classificacao Classificacao { get; set; }
        public CompraVenda CompraVenda { get; set; }
        [NotMapped]
        public List<SelectListItem>? Classificacoes { get; set; }
        [NotMapped]
        public List<SelectListItem>? CompraVendas { get; set; }
        public InsercaoAlteracaoSaidaRequest(Guid boiId, decimal? pesoMedioAlterado, decimal pesoBruto, decimal arroba, decimal rendimentoCarcaca, 
            DateTime saida, Guid idComprador, Guid idAssociado,  Guid? inicioParceriaId, Classificacao classificacao, CompraVenda compraVenda)
        {
            BoiId = boiId;
            PesoMedioAlterado = pesoMedioAlterado;
            PesoBruto = pesoBruto;
            Arroba = arroba;
            RendimentoCarcaca = rendimentoCarcaca;
            Saida = saida;
            IdComprador = idComprador;
            IdAssociado = idAssociado;
            InicioParceriaId = inicioParceriaId;
            Classificacao = classificacao;
            CompraVenda = compraVenda;            
        }
        public static AlteracaoSaida ConverterParaEntidade(InsercaoAlteracaoSaidaRequest insercao)
        {
            return new AlteracaoSaida
                (
                insercao.BoiId,
                insercao.PesoMedioAlterado,
                insercao.PesoBruto,
                insercao.Arroba,
                insercao.RendimentoCarcaca,
                insercao.Saida,
                insercao.IdComprador,
                insercao.IdAssociado,
                insercao.InicioParceriaId,
                insercao.Classificacao,
                insercao.CompraVenda                
                );
        }
        public InsercaoAlteracaoSaidaRequest()
        {

        }
    }
}
