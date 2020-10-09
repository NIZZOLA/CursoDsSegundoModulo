using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploMvcComMysql.Models
{
    [Table("Clientes")]
    public class ClienteModel
    {
        [Key]
        public int ClienteId { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public ICollection<VendaModel> Vendas { get; set; }
    }
}
