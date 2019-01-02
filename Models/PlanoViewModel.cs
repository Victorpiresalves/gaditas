using System;
using System.ComponentModel.DataAnnotations;

namespace Gaditas.Models
{
    public class PlanoViewModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(150)]
        [Display(Name = "Plano")]
        public string NOME { get; set; }
        [Required]
        [Display(Name = "Valor")]
        public decimal VALOR { get; set; }
        [Required]
        [Display(Name = "Quantidade de Meses")]
        public int QTD_MESES { get; set; }
        [Required]
        [Display(Name = "Data Cadastro")]
        public DateTime DT_CADASTRO { get; set; }
        [Display(Name = "Atualizado em")]
        public DateTime? DT_ATUALIZACAO{get;set;}
    }
}