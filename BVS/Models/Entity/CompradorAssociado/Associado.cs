using BVS.Models.Entity.Parceria;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BVS.Models.Entity.CompradorAssociado
{
    public class Associado : ACadastro
    {
        public Associado()
        {
        }                                                    
        public Associado(string cpf, DateTime dataDaParceria, string fazenda, Guid? idComprador, string nome ) : 
        this (default, cpf, dataDaParceria, fazenda, idComprador, nome)
        {
        }

        public Associado(Guid cadastroId, string cpf, DateTime dataDaParceria, string fazenda, Guid? idComprador, string nome)
        {
            CadastroId = cadastroId;
            CPF = cpf;
            DataDaParceria = dataDaParceria;
            Fazenda = fazenda;            
            IdComprador = idComprador;            
            Nome = nome;
              
        }
       
        public string? Fazenda { get; set; }
        [DisplayName("Data Início da Parceria")]
        public DateTime DataDaParceria { get; private set; }
        public Guid? IdComprador { get; private set; }
        public Comprador? Comprador { get; set; }
        public virtual ICollection<InicioParceria>? InicioParcerias { get; private set; }
        public virtual ICollection<AlteracaoSaida>? AlteracaoSaidas { get; private set; }
    }
}
