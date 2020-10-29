using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCVendasApp.Models
{
    [Table("VendaItens")]
    public class VendaItensModel
    {
        [Key]
        public int VendaItensId { get; set; }

        [ForeignKey("Venda")]
        public int VendaId { get; set; }

        public VendaModel Venda { get; set; }

        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }

        public ProdutoModel Produto { get; set; }

        public int Quantidade { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal ValorDeVenda { get; set; }
    }
}
