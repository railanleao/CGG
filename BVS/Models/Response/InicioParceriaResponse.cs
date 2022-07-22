using BVS.Models.Entity.CompradorAssociado;
using BVS.Models.Entity.Parceria;

namespace BVS.Models.Response
{
    public class InicioParceriaResponse
    {
        public Guid BoiId { get; set; }
        public string Lote { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataInicioParceria { get; set; }
        public decimal PesoBruto { get; set; }
        public string? Origem { get; set; }
        public decimal Valor { get; set; }
        public decimal Arroba { get; set; }
        public decimal RendimentoCarcaca { get; set; }
        public Guid IdComprador { get; set; }
        public Comprador? Comprador { get; set; }
        public Guid IdAssociado { get; set; }
        public Associado? Associado { get; set; }
        public CompradorResponse CompradorResponse { get; set; }
        public AssociadoResponse AssociadoResponse { get; set; }
        public InicioParceriaResponse(Guid boiId, string lote, int quantidade, decimal pesoBruto, decimal valor, string origem, decimal arroba, 
            decimal rendimentoCarcaca, DateTime dataInicioParceria, Guid idComprador, Guid idAssociado, CompradorResponse compradorResponse, 
            AssociadoResponse associadoResponse)
        {
            BoiId = boiId;
            Lote = lote;
            Quantidade = quantidade;
            PesoBruto = pesoBruto;
            Valor = valor;
            Origem = origem;
            Arroba = arroba;
            RendimentoCarcaca = rendimentoCarcaca;
            DataInicioParceria = dataInicioParceria;
            IdComprador = idComprador;
            IdAssociado = idAssociado;
            this.CompradorResponse = compradorResponse;
            this.AssociadoResponse = associadoResponse;
        }
        public static InicioParceriaResponse ConverteParaResponse(InicioParceria inicioParceria)
        {
            return new InicioParceriaResponse
                (
                    inicioParceria.BoiId,
                    inicioParceria.Lote,
                    inicioParceria.Quantidade,
                    inicioParceria.PesoBruto,
                    inicioParceria.Valor,
                    inicioParceria.Origem,
                    inicioParceria.Arroba,
                    inicioParceria.RendimentoCarcaca,
                    inicioParceria.DataInicioParceria,
                    inicioParceria.IdComprador,
                    inicioParceria.IdAssociado,
                    new CompradorResponse(inicioParceria.Comprador.CadastroId,
                    inicioParceria.Comprador.Nome, inicioParceria.Comprador.CPF),
                    new AssociadoResponse (inicioParceria.Associado.CadastroId, inicioParceria.Associado.CPF, 
                    inicioParceria.Associado.DataDaParceria, inicioParceria.Associado.Fazenda, 
                    inicioParceria.Associado.Nome, inicioParceria.Associado.IdComprador,
                    new CompradorResponse(inicioParceria.Comprador.CadastroId,
                    inicioParceria.Comprador.Nome, inicioParceria.Comprador.CPF))
                );
        }
    }
}
