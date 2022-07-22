using BVS.Models.Entity.CompradorAssociado;
using BVS.Models.Entity.Parceria;

namespace BVS.Models.Response
{
    public class AlteracaoSaidaResponse
    {
        public Guid BoiId { get; set; }
        public decimal? PesoMedioAlterado { get; set; }
        public decimal PesoBruto { get; set; }
        public decimal Arroba { get; set; }
        public decimal RendimentoCarcaca { get; set; }
        public DateTime Saida { get; set; }
        public Guid IdComprador { get; set; }
        public Comprador? Comprador { get; set; }
        public Guid IdAssociado { get; set; }
        public Associado? Associado { get; set; }
        public Guid? InicioParceriaId { get; set; }
        public CompradorResponse CompradorResponse { get; set; }
        public AssociadoResponse AssociadoResponse { get; set; }
        public AlteracaoSaidaResponse(Guid boiId, decimal? pesoMedioAlterado, decimal pesoBruto, decimal arroba, decimal rendimentoCarcaca, 
            DateTime saida, Guid idComprador, Guid idAssociado, Guid? inicioParceriaId, CompradorResponse compradorResponse, 
            AssociadoResponse associadoResponse)
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
            this.CompradorResponse = compradorResponse;
            this.AssociadoResponse = associadoResponse;
        }
        public static AlteracaoSaidaResponse ConverteParaResponse(AlteracaoSaida alteracao)
        {
            return new AlteracaoSaidaResponse
                (
                alteracao.BoiId,
                alteracao.PesoMedioAlterado,
                alteracao.PesoBruto,
                alteracao.Arroba,
                alteracao.RendimentoCarcaca,
                alteracao.Saida,
                alteracao.IdComprador,
                alteracao.IdAssociado,
                alteracao.InicioParceriaId,
                new CompradorResponse(alteracao.Comprador.CadastroId, 
                alteracao.Comprador.Nome, alteracao.Comprador.CPF),
                new AssociadoResponse(alteracao.Associado.CadastroId, alteracao.Associado.CPF, alteracao.Associado.DataDaParceria, 
                alteracao.Associado.Fazenda, alteracao.Associado.Nome, alteracao.Associado.IdComprador,
                new CompradorResponse(alteracao.Comprador.CadastroId,
                alteracao.Comprador.Nome, alteracao.Comprador.CPF))
                );
        }
    }
}
