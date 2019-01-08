using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gaditas.Models
{
    public class PagamentoViewModel
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Aluno")]
        public int ID_ALUNO { get; set; }
        [Display(Name = "Plano do Aluno")]
        public int ID_PLANO_ALUNO { get; set; }
        [Display(Name = "Valor")]
        public decimal VALOR { get; set; }
        [Display(Name = "Nº Parcela")]
        public int NUM_PARCELA { get; set; }
        [Display(Name = "Qtd Total Parcela")]
        public int QTD_TOTAL_PARCELA { get; set; }


        public bool PAGOU { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data de Vencimento")]
        public DateTime DT_VENCIMENTO { get; set; }
        [Display(Name = "Data de Cadastro")]
        public DateTime DT_CADASTRO { get; set; }
        [Display(Name = "Atualizado em")]
        public DateTime? DT_ATUALIZACAO { get; set; }
        [Display(Name = "Data do Pagamento")]
        public DateTime? DT_PAGAMENTO { get; set; }
        public virtual AlunoViewModel Aluno { get; set; }
        public virtual PlanoAlunoViewModel PlanoAluno { get; set; }

    }
}