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
            var planos = _planoDAL.GetAllAsync();
            List<SelectListItem> list = new List<SelectListItem>();

            if (planos.Result.Count() > 0)
            {
                var result = planos.Result.ToList();
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
