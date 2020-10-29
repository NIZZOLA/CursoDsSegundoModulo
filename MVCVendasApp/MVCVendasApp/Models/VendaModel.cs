using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCVendasApp.Models
{
    [Table("Vendas")]
    public class VendaModel
    {
        [Key]
        
        [Display(Name = "Código")]
        public int VendaId { get; set; }

        [Display(Name = "Data da Venda")]
        public DateTime DataDaVenda { get; set; }

        [ForeignKey("Cliente")]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        public ClienteModel Cliente { get; set; }

        [Display(Name = "Previsão de Entrega")]
        public DateTime DataPrevistaDaEntrega { get; set; }

        [MaxLength(20)]
        [Display(Name = "Código do rastreamento")]

        public string CodigoDoRastreamento { get; set; }

        public ICollection<VendaItensModel> Itens { get; set; }
    }
}
