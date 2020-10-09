using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConsoleEFMysql.Models
{
    public class LivroModel
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(50, ErrorMessage = "O campo deve ter no máximo {0} caracteres")]
        public string Nome { get; set; }
        
        [MaxLength(50, ErrorMessage = "O campo deve ter no máximo {0} caracteres")]
        public string Autor { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal Preco { get; set; }

        public DateTime Lancamento { get; set; } = DateTime.UtcNow;

        [MaxLength(13, ErrorMessage = "O código de barras deve ter no máximo {0} caracteres")]
        public string CodigoDeBarras { get; set; }

        [MaxLength(13, ErrorMessage = "O código ISBN deve ter no máximo {0} caracteres")]
        public string ISBN { get; set; }

        [MaxLength(50, ErrorMessage = "O campo deve ter no máximo {0} caracteres")]
        public string Editora { get; set; }


        public ICollection<VendaItensModel> ItensVendidos { get; set; }
    }
}
