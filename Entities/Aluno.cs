using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gaditas.Entities
{
    public class Aluno
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(150)]
        public string NOME_COMPLETO { get; set; }
        [Required]
        public DateTime DT_NASCIMENTO { get; set; }
        [Required]
        [StringLength(14)]
        public string CPF { get; set; }
        [Required]
        [StringLength(12)]
        public string RG { get; set; }
        [Required]
        public DateTime DT_CADASTRO { get; set; }
        public DateTime? DT_ATUALIZACAO { get; set; }
    }
}