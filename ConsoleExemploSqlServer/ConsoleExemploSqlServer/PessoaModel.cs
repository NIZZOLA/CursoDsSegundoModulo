using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConsoleExemploSqlServer
{
    public class PessoaModel
    {
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(18)]
        public string DocumentCpf { get; set; }

        [MaxLength(18)]
        public string DocumentRg { get; set; }

        //public GenderTypeEnum Gender { get; set; }
        public DateTime BirthDate { get; set; }

        [MaxLength(15)]
        public string FixedPhoneNumber { get; set; }
        [MaxLength(15)]
        public string CellPhoneNumber { get; set; }
        [MaxLength(15)]
        public string OtherPhoneNumber { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string SecondaryEmail { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }

        public bool Active { get; set; }

        [MaxLength(20)]
        public string ReferenceId { get; set; }

        public DateTime? DeactivateDate { get; set; }


    }
}
