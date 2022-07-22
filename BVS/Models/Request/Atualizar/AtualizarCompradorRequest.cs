using BVS.Models.Entity.CompradorAssociado;

namespace BVS.Models.Request.Atualizar
{
    public class AtualizarCompradorRequest
    {
        public Guid CadastroId { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public AtualizarCompradorRequest(Guid cadastroId, string nome, string cpf)
        {
            CadastroId = cadastroId;
            Nome = nome;
            CPF = cpf;
        }
        public static Comprador ConverterParaEntidade(AtualizarCompradorRequest compradorRequest)
        {
            return new Comprador
                (
                compradorRequest.CadastroId,
                compradorRequest.Nome,
                compradorRequest.CPF
                );
        }
        public AtualizarCompradorRequest()
        {

        }
    }
}
