using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppExemplo1.Models
{
    [Table("Produtos")]
    public class ProdutoModel
    {
        [Key]
        public int ProdutoId { get; set; }

        [MaxLength(50, ErrorMessage = "O campo deve ter no máximo {0} caracteres")]
        public string Descricao { get; set; }

        public double Estoque { get; set; }

        public decimal Valor { get; set; }
    }
}
