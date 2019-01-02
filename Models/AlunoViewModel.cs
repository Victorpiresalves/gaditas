using System;
using System.ComponentModel.DataAnnotations;
using Gaditas.Entities;

namespace Gaditas.Models
{
    public class AlunoViewModel : Aluno
    {
        [Key]
        public new int ID { get; set; }
        [Required]
        [StringLength(150)]
        [Display(Name = "Nome Completo")]
        public new string NOME_COMPLETO { get; set; }
        [Required]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public new DateTime DT_NASCIMENTO { get; set; }
        [Required]
        [StringLength(14)]
        [Display(Name = "CPF")]
        public new string CPF { get; set; }
        [Required]
        [StringLength(12)]
        [Display(Name = "RG")]
        public new string RG { get; set; }
        [Required]
        [Display(Name = "Data de Cadastro")]
        [DataType(DataType.DateTime)]
        public new DateTime DT_CADASTRO { get; set; }
        [Display(Name = "Atualizado em")]
        [DataType(DataType.DateTime)]
        public new DateTime? DT_ATUALIZACAO { get; set; }
    }
}