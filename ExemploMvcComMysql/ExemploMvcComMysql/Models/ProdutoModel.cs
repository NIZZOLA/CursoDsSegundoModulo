using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploMvcComMysql.Models
{
    [Table("Produto")]
    public class ProdutoModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "O campo deve ter no máximo {0} caracteres")]
        public string Descricao { get; set; }

        [MaxLength(2, ErrorMessage = "O campo deve ter no máximo {0} caracteres")]
        public string Unidade { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal Custo { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal Preco { get; set; }

        [MaxLength(13, ErrorMessage = "O código de barras deve ter no máximo {0} caracteres")]
        public string CodigoDeBarras { get; set; }

        [Column(TypeName = "decimal(12,3)")]
        public decimal Estoque { get; set; }

        public ICollection<VendaItensModel> ItensVendidos { get; set; }
    }
}
