using BVS.Models.Entity.CompradorAssociado;

namespace BVS.Models.Response
{
    public class CompradorResponse
    {
        public Guid CadastroId { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public CompradorResponse(Guid cadastroId, string? nome, string? cpf)
        {
            CadastroId = cadastroId;
            Nome = nome;
            CPF = cpf;
        }
        public static CompradorResponse ConverteParaResponse(Comprador comprador)
        {
            return new CompradorResponse
            (
                comprador.CadastroId,
                comprador.Nome,
                comprador.CPF
             );
        }
    }
}
