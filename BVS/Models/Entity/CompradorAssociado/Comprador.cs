using BVS.Models.Entity.Parceria;

namespace BVS.Models.Entity.CompradorAssociado
{
    public class Comprador : ACadastro
    {
        
        public virtual ICollection<Associado>? Associados { get; private set; } 
        public virtual ICollection<InicioParceria>? InicioParcerias { get; private set; } 
        public virtual ICollection<AlteracaoSaida>? AlteracaoSaidas { get; private set; } 
        
        public Comprador(Guid cadastroId, string? nome, string? cpf)
        {
            CadastroId = cadastroId;
            Nome = nome;
            CPF = cpf;
        }
        public Comprador()
        {
        }

        public Comprador(string nome, string cpf) : this (default,nome, cpf)
        {
        }
        //[InverseProperty("CadastroId")] propriedade de navegação.
    }
}
