using BVS.Models.Entity.CompradorAssociado;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BVS.Models.Entity.Parceria
{
    public class AlteracaoSaida : ACadastroBoi
    {
        [DisplayName("Peso Médio Alterado")]
        public decimal? PesoMedioAlterado { get; set; }
        [Display(Name = "Data da Saida")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Saida { get; private set; }
        public Guid IdComprador { get; private set; }
        public Comprador? Comprador { get; private set; }
        public Guid IdAssociado { get; private set; }
        public Associado? Associado { get; private set; }
        public Guid? InicioParceriaId { get; set; }
        public InicioParceria InicioParceria { get; set; }
        public AlteracaoSaida(Guid boiId, decimal? pesoMedioAlterado, decimal pesoBruto, decimal arroba, decimal rendimentoCarcaca, DateTime saida, 
            Guid idComprador, Guid idAssociado, Guid? inicioParceriaId, Classificacao classificacao, CompraVenda compraVenda) 
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

        public AlteracaoSaida(decimal? pesoMedioAlterado, decimal pesoBruto, decimal arroba, decimal rendimentoCarcaca, DateTime saida, Guid idComprador, Guid idAssociado, Guid? inicioParceriaId,
            Classificacao classificacao, CompraVenda compraVenda) : 
            this (default, pesoMedioAlterado, pesoBruto, arroba, rendimentoCarcaca, saida, idComprador, idAssociado, inicioParceriaId, classificacao, compraVenda)
        {            
        }
        public AlteracaoSaida()
        {
        }
    }
}