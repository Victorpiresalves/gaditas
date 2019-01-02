using Gaditas.DAL;
using GaditasDataContext;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gaditas.Adapter
{
    public class ModalidadesAdapter
    {
        private readonly AppDataContext _context;
        private readonly ModalidadeDAL _modalidadeDAL;
        public ModalidadesAdapter(AppDataContext context)
        {
            _context = context;
            _modalidadeDAL = new ModalidadeDAL(_context);
        }
        public List<SelectListItem> GetList(int? id = null)
        {
            var modalidades = _modalidadeDAL.GetAllAsync();
            List<SelectListItem> list = new List<SelectListItem>();

            if (modalidades.Result.Count() > 0)
            {
                var result = modalidades.Result.ToList();
                for (int i = 0; i < result.Count(); i++)
                {
                    list.Add(new SelectListItem
                    {
                        Text = result[i].NOME,
                        Value = result[i].ID.ToString(),
                        Selected = id != null && id == result[i].ID ? true : false
                    });
                }
            }
            return list;
        }
    }
}
