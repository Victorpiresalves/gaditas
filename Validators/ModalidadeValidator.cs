using Gaditas.DAL;
using Gaditas.Models;
using GaditasDataContext;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gaditas.Validators
{
    public class ModalidadeValidator
    {
        private AppDataContext _context;
        private ModelStateDictionary _ModelState;
        private ModalidadeDAL _modalidadeDAL;

        public ModalidadeValidator(AppDataContext context, ModelStateDictionary ModelState)
        {
            _context = context;
            _ModelState = ModelState;
            _modalidadeDAL = new ModalidadeDAL(context);
        }

        public ModelStateDictionary CustomValidator(ModalidadeViewModel modalidadeViewModel)
        {
            #region Create
            var modalidadeByNome = _modalidadeDAL.ReturnModalidadeByNome(modalidadeViewModel.NOME);
            
            if (modalidadeViewModel.ID == 0)
            {
                if (modalidadeByNome != null)
                {
                    _ModelState.AddModelError("NOME", "Já existe uma modalidade com esse nome.");
                }
            }
            #endregion

            #region Edit
            if(modalidadeViewModel.ID != 0)
            {
                if (modalidadeByNome != null && modalidadeByNome.ID != modalidadeViewModel.ID)
                {
                    _ModelState.AddModelError("NOME", "Já existe uma modalidade com esse nome.");
                }
            }
            #endregion

            return _ModelState;
        }
    }
}
