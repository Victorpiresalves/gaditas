using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Gaditas.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gaditas.Models
{
    public class PlanoAlunoViewModel
    {
        [Key]
        public int ID { get; set; }
        public int ID_ALUNO { get; set; }
        [Display(Name = "Plano")]
        public int ID_PLANO { get; set; }
        [Display(Name = "Data de Início")]
        [DataType(DataType.Date)]
        public DateTime DT_INICIO { get; set; }
        [Display(Name = "Data de Cadastro")]
        public DateTime DT_CADASTRO { get; set; }
        [Display(Name = "Atualizado em")]
        public DateTime? DT_ATUALIZACAO { get; set; }
        public virtual PlanoViewModel Plano { get; set; }    
        public virtual AlunoViewModel Aluno { get; set; }

        public List<SelectListItem> ListaPlanos { get; set; }
    }
}