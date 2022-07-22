using BVS.Models.Entity.CompradorAssociado;

namespace BVS.Models.Response
{
    public class AssociadoResponse
    {
        public Guid CadastroId { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? Fazenda { get; set; }
        public DateTime DataDaParceria { get; set; }
        public Guid? IdComprador { get; set; }
        public Comprador Comprador { get; set; }
        public CompradorResponse? CompradorResponse { get; set; }
        public AssociadoResponse(Guid cadastroId, string? cpf, DateTime dataDaParceria, string? fazenda, string? nome,   
             Guid? idComprador, CompradorResponse compradorResponse)
        {
            CadastroId = cadastroId;
            Fazenda = fazenda;
            DataDaParceria = dataDaParceria;
            Nome = nome;
            CPF = cpf;
            IdComprador = idComprador;
            this.CompradorResponse = compradorResponse;
        }
        public static AssociadoResponse ConverteParaResponse(Associado associado)
        {
            return new AssociadoResponse
                (
                associado.CadastroId,
                associado.CPF,
                associado.DataDaParceria,
                associado.Fazenda,               
                associado.Nome,
                associado.IdComprador,
                new CompradorResponse (associado.Comprador.CadastroId, 
                associado.Comprador.Nome, associado.Comprador.CPF)
                );
        }
    }
}
