using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gaditas.Entities
{
    public class ModalidadeAluno
    {
        [Key]
        public int ID { get; set; }
        public int ID_ALUNO { get; set; }
        public int ID_MODALIDADE { get; set; }
        public DateTime DT_CADASTRO { get; set; }
        public DateTime? DT_ATUALIZACAO { get; set; }
        [ForeignKey("ID_ALUNO")]
        public Aluno Aluno { get; set; }
        [ForeignKey("ID_MODALIDADE")]
        public Modalidade Modalidade { get; set; }
              public bool DELETADO {get;set;}
         public DateTime? DT_DELETADO { get; set; }
    }
}