using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConsoleEFMysql.Models
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
