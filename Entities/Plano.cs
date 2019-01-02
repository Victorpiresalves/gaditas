using System;
using System.ComponentModel.DataAnnotations;

namespace Gaditas.Entities
{
    public class Plano
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(150)]
        public string NOME { get; set; }
        [Required]
        public decimal VALOR { get; set; }
        [Required]
        public int QTD_MESES { get; set; }
        [Required]
        public DateTime DT_CADASTRO { get; set; }
        public DateTime? DT_ATUALIZACAO{get;set;}
    }
}