using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gaditas.Entities
{
    public class Modalidade
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string NOME { get; set; }
        public bool ATIVO { get; set; }
        [Required]
        public DateTime DT_CADASTRO { get; set; }
        public DateTime? DT_ATUALIZACAO { get; set; }
              public bool DELETADO {get;set;}
         public DateTime? DT_DELETADO { get; set; }
    }
}