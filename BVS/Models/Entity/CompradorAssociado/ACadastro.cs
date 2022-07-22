namespace BVS.Models.Entity.CompradorAssociado
{
    public abstract class ACadastro
    {
            public Guid CadastroId { get; protected set; }
            public string? Nome { get; protected set; }
            public string? CPF { get; protected set; }

    }
}
