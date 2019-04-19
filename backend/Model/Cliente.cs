using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Model
{
    [Table("Cliente")]
    public class Cliente
    {
    
        [Key]
        public int IdCliente { get; set; }

        [Required] 
        [StringLength(35)]
        public string Nome { get; set; }

        [Required] 
        [StringLength(100)]
        public string Sobrenome { get; set; }

        [Required] 
        [StringLength(11)]
        public string Cpf { get; set; }

        [Required] 
        public DateTime Nascimento { get; set; }

        [ForeignKey("profissaoId")]
        public virtual Profissao Profissao { get; set; }


    }

}