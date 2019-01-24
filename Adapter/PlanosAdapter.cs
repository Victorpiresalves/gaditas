using Gaditas.DAL;
using GaditasDataContext;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gaditas.Adapter
{
    public class PlanosAdapter
    {
        private readonly AppDataContext _context;
        private readonly PlanoDAL _planoDAL;
        public PlanosAdapter(AppDataContext context)
        {
            _context = context;
            _planoDAL = new PlanoDAL(_context);
        }
        public List<SelectListItem> GetList(int? id = null)
        {
            var planos = _planoDAL.GetAll().ToList();
            List<SelectListItem> list = new List<SelectListItem>();

            if (planos.Count() > 0)
            {
                for (int i = 0; i < planos.Count(); i++)
                {
                    list.Add(new SelectListItem
                    {
                        Text = planos[i].NOME,
                        Value = planos[i].ID.ToString(),
                        Selected = id != null && id == planos[i].ID ? true : false
                    });
                }
            }
            return list;
        }
    }
}
