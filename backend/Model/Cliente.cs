using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Model
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        [Required] 
        public string Nome { get; set; }
        [Required] 
        public string Sobrenome { get; set; }
        [Required] 
        public string Cpf { get; set; }
        [Required] 
        public DateTime Nascimento { get; set; }

        [ForeignKey("profissao")]
        public Profissao Profissao { get; set; }


    }

}