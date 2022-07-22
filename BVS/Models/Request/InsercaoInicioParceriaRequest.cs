using BVS.Models.Entity.Parceria;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace BVS.Models.Request
{
    public class InsercaoInicioParceriaRequest
    {
        public Guid BoiId { get; set; }
        public string Lote { get; set; }
        public int Quantidade { get; set; }
        public decimal PesoBruto { get; set; }
        public string? Origem { get; set; }
        public decimal Valor { get; set; }
        public decimal Arroba { get; set; }
        public decimal RendimentoCarcaca { get; set; }
        public DateTime DataInicioParceria { get; set; } 
        public Guid IdComprador { get; set; }
        public Guid IdAssociado { get; set; }
        public Classificacao Classificacao { get; set; }
        public CompraVenda CompraVenda { get; set; }
        [NotMapped]
        public List<SelectListItem>? Classificacoes { get; set; }
        [NotMapped]
        public List<SelectListItem>? CompraVendas { get; set; }
        public InsercaoInicioParceriaRequest(Guid boiId, string lote,int quantidade, decimal pesoBruto, string? origem, decimal valor, 
            decimal arroba, decimal rendimentoCarcaca, DateTime dataInicioParceria,Guid idComprador, Guid idAssociado, 
            Classificacao classificacao, CompraVenda compraVenda)
        {
            BoiId = boiId;
            Lote = lote;
            Quantidade = quantidade;
            PesoBruto = pesoBruto;
            Origem = origem;
            Valor = valor;
            Arroba = arroba;
            RendimentoCarcaca = rendimentoCarcaca;
            DataInicioParceria = dataInicioParceria;
            IdComprador = idComprador;
            IdAssociado = idAssociado;
            Classificacao = classificacao;
            CompraVenda = compraVenda;
        }
        public static InicioParceria ConverterParaEntidade(InsercaoInicioParceriaRequest inicioParceriaRequest)
        {
            return new InicioParceria
                (
                inicioParceriaRequest.BoiId,
                inicioParceriaRequest.Lote,
                inicioParceriaRequest.Quantidade,
                inicioParceriaRequest.PesoBruto,
                inicioParceriaRequest.Valor,
                inicioParceriaRequest.Origem,
                inicioParceriaRequest.Arroba,
                inicioParceriaRequest.RendimentoCarcaca,
                inicioParceriaRequest.DataInicioParceria,
                inicioParceriaRequest.IdComprador,
                inicioParceriaRequest.IdAssociado,
                inicioParceriaRequest.Classificacao,
                inicioParceriaRequest.CompraVenda
                );
        }
        
        public InsercaoInicioParceriaRequest()
        {     }
    }
}
