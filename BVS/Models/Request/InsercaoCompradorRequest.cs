using BVS.Models.Entity.CompradorAssociado;

namespace BVS.Models.Request
{
    public class InsercaoCompradorRequest
    {
        public Guid CadastroId { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public InsercaoCompradorRequest(Guid cadastroId, string nome, string cpf)
        {
            CadastroId = cadastroId;
            Nome = nome;
            CPF = cpf;
        }
        public static Comprador ConverterParaEntidade(InsercaoCompradorRequest compradorRequest)
        {
            return new Comprador
                (
                compradorRequest.CadastroId,
                compradorRequest.Nome,
                compradorRequest.CPF
                );
        }
        public InsercaoCompradorRequest()
        {

        }
    }
}
