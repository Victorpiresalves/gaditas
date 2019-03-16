using Gaditas.Controllers;
using Gaditas.DAL;
using Gaditas.Models;
using GaditasDataContext;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Gaditas.Validators
{
    public class ModalidadeAlunoValidator
    {
        private AppDataContext _context;
        private ModelStateDictionary _ModelState;
        private ModalidadeAlunoDAL _modalidadeAlunoDAL;

        public ModalidadeAlunoValidator(AppDataContext context, ModelStateDictionary ModelState)
        {
            _context = context;
            _ModelState = ModelState;
            _modalidadeAlunoDAL = new ModalidadeAlunoDAL(context);
        }

        public ModelStateDictionary CustomValidator(ModalidadeAlunoViewModel modalidadeAlunoViewModel)
        {
            #region Create
            var retornarModalidadeAluno = _modalidadeAlunoDAL.ReturnModalidadeAlunoByIdAlunoAndIdModalidade(modalidadeAlunoViewModel.ID_ALUNO, modalidadeAlunoViewModel.ID_MODALIDADE);
            if (retornarModalidadeAluno != null)
            {
                _ModelState.AddModelError("ID_MODALIDADE", "O Aluno já esta cadastrado nessa modalidade.");
            }
            #endregion

            #region Edit

            #endregion

            return _ModelState;
        }
    }
}