using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Model
{
    [Table("Profissao")]
    public class Profissao
    {

        [Key]
        public int IdProfissao { get; set; }

        [StringLength(100)]
        [Required] 
        public string Nome { get; set; }

        [StringLength(1000)]
        public string Descricao { get; set; }
    
    }
}