using BVS.Models.Entity.ModelBind;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BVS.Models.Entity.Parceria
{
    public enum Classificacao
    {
        Boi,
        Bezerro,
    }
    public enum CompraVenda
    {
        Compra,
        Venda,
    }
    [ModelBinder(BinderType = typeof(ConvertBind))]
    public class ACadastroBoi
    {
        public Guid BoiId { get; protected set; }
        
        [DisplayName("Classificação")]
        public Classificacao? Classificacao { get; set; }
        
        
        [DisplayName("Modelo")]
        public CompraVenda? CompraVenda { get; set; }
        
        [DisplayName("Peso Bruto")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal PesoBruto { get; protected set; }
        [DisplayName("Rend. Carcaça")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal RendimentoCarcaca { get; protected set; }
        [DisplayName("Arroba")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal Arroba { get; protected set; }

        [NotMapped]
        public List<SelectListItem>? Classificacoes { get; set; }
        [NotMapped]
        public List<SelectListItem>? CompraVendas { get; set; }
    }
}
