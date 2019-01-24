using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gaditas.Entities
{
    public class Pagamento
    {
        [Key]
        public int ID { get; set; }
        public int ID_ALUNO { get; set; }
        public int ID_PLANO { get; set; }
        public string DESCRICAO { get; set; }
        public decimal VALOR { get; set; }
        public int NUM_PARCELA { get; set; }
        public int QTD_TOTAL_PARCELA { get; set; }
        public bool PAGOU { get; set; }
        public DateTime DT_VENCIMENTO { get; set; }
        public DateTime DT_CADASTRO { get; set; }
        public DateTime? DT_ATUALIZACAO { get; set; }
        public DateTime? DT_PAGAMENTO { get; set; }
        [ForeignKey("ID_ALUNO")]
        public virtual Aluno Aluno { get; set; }
        [ForeignKey("ID_PLANO")]
        public virtual Plano Plano { get; set; }
    }
}