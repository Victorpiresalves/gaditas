using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gaditas.Entities
{
    public class PlanoAluno
    {
        [Key]
        public int ID { get; set; }
        public int ID_ALUNO { get; set; }
        public int ID_PLANO { get; set; }
        public DateTime DT_INICIO { get; set; }
        public DateTime DT_CADASTRO { get; set; }
        public DateTime? DT_ATUALIZACAO { get; set; }
        [ForeignKey("ID_PLANO")]
        public Plano Plano { get; set; }    
         [ForeignKey("ID_ALUNO")]
        public Aluno Aluno { get; set; }
    }
}