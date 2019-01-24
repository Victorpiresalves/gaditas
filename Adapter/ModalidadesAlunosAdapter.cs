

using Gaditas.DAL;
using GaditasDataContext;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaditas.Adapter
{
    public class ModalidadesAlunosAdapter
    {
         private readonly AppDataContext _context;
        private readonly ModalidadeAlunoDAL _modalidadeAlunoDAL;
        public ModalidadesAlunosAdapter(AppDataContext context)
        {
            _context = context;
            _modalidadeAlunoDAL = new ModalidadeAlunoDAL(_context);
        }
        public string RetornarModalidadesAlunoString(int idAluno)
        {
            var modalidadesAluno = _modalidadeAlunoDAL.FindByIdAluno(idAluno);

            StringBuilder modalidadesDoAlunoString = new StringBuilder("N/A");
            if(modalidadesAluno.Any())
            {
                for(int i=0;i<modalidadesAluno.Count;i++)
                {
                    modalidadesDoAlunoString.Append(modalidadesAluno[i].Modalidade.NOME);
                    modalidadesDoAlunoString.Append(";");
                }
            }
            return modalidadesDoAlunoString.ToString();
        }
    }
}