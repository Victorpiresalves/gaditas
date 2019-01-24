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
    public class PlanoValidator
    {
        private AppDataContext _context;
        private ModelStateDictionary _ModelState;
        private PlanoDAL _planoDAL;

        public PlanoValidator(AppDataContext context, ModelStateDictionary ModelState)
        {
            _context = context;
            _ModelState = ModelState;
            _planoDAL = new PlanoDAL(context);
        }

        public ModelStateDictionary CustomValidator(PlanoViewModel planoViewModel)
        {
            #region Create
            var planoByNome = _planoDAL.ReturnPlanoByNome(planoViewModel.NOME);
            
            if (planoViewModel.ID == 0)
            {
                if (planoByNome != null)
                {
                    _ModelState.AddModelError("NOME", "Já existe um plano com esse nome.");
                }
            }
            #endregion

            #region Edit
            if(planoViewModel.ID != 0)
            {
                if (planoByNome != null && planoByNome.ID != planoViewModel.ID)
                {
                    _ModelState.AddModelError("NOME", "Já existe um plano com esse nome.");
                }
            }
            #endregion

            return _ModelState;
        }
    }
}
