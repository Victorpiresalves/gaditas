using System;
using System.ComponentModel.DataAnnotations;

namespace Gaditas.Models
{
    public class ModalidadeViewModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Modalidade")]
        public string NOME { get; set; }
        [Display(Name = "Ativo")]
        public bool ATIVO { get; set; }
        [Required]
        [Display(Name = "Data de Cadastro")]
        public DateTime DT_CADASTRO { get; set; }
        [Display(Name = "Atualizado em")]
        public DateTime? DT_ATUALIZACAO { get; set; }
    }
}