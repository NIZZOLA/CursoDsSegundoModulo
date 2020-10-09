using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConsoleEFMysql.Models
{
    [Table("Vendas")]
    public class VendaModel
    {
        [Key]
        public int VendaId { get; set; }

        public DateTime DataDaVenda { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }

        public ClienteModel Cliente { get; set; }

        public ICollection<VendaItensModel> Itens { get; set; }

    }
}
