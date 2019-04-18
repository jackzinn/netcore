using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Model
{
    public class Profissao
    {
        [Key]
        public int IdProfissao { get; set; }
        [Required] 
        public string Nome { get; set; }
        public string Descricao { get; set; }
        
        public ICollection<Cliente> Cliente { get; set; }
    }
}