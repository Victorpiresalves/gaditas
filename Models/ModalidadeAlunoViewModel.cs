using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Gaditas.Adapter;
using GaditasDataContext;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gaditas.Models
{
    public class ModalidadeAlunoViewModel
    {
        [Key]
        public int ID { get; set; }
        public int ID_ALUNO { get; set; }
        [Display(Name = "Modalidade")]
        public int ID_MODALIDADE { get; set; }
        [Display(Name = "Data de Cadastro")]
        public DateTime DT_CADASTRO { get; set; }
        [Display(Name = "Atualizado em")]
        public DateTime? DT_ATUALIZACAO { get; set; }
        public virtual AlunoViewModel Aluno { get; set; }
        public virtual ModalidadeViewModel Modalidade { get; set; }
        public List<SelectListItem> ListaModalidades { get; set; }
    }
}