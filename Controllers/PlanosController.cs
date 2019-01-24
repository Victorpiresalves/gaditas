using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gaditas.Entities;
using GaditasDataContext;
using AutoMapper;
using Gaditas.Models;
using Gaditas.DAL;
using Gaditas.Validators;

namespace Gaditas.Controllers
{
    public class PlanosController : Controller
    {
        private readonly AppDataContext _context;
        private readonly IMapper _mapper;
        private readonly PlanoDAL _planoDAL;
        public PlanosController(AppDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _planoDAL = new PlanoDAL(_context);
        }

        // GET: Planos
        public IActionResult Index()
        {
            var planos = _planoDAL.GetAll();
            return View(_mapper.Map<List<PlanoViewModel>>(planos));
        }

        // GET: Planos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plano = await _planoDAL.FindByIdAsync((int)id);
            if (plano == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<PlanoViewModel>(plano));
        }

        // GET: Planos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Planos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PlanoViewModel planoViewModel)
        {
            if (new PlanoValidator(_context, ModelState).CustomValidator(planoViewModel).IsValid)
            {
                await _planoDAL.Add(_mapper.Map<Plano>(planoViewModel));
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(planoViewModel);
        }

        // GET: Planos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plano = await _planoDAL.FindByIdAsync((int)id);
            if (plano == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<PlanoViewModel>(plano));
        }

        // POST: Planos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,PlanoViewModel planoViewModel)
        {
            if (id != planoViewModel.ID)
            {
                return NotFound();
            }

            if (new PlanoValidator(_context, ModelState).CustomValidator(planoViewModel).IsValid)
            {
                try
                {
                    _planoDAL.Update(id, _mapper.Map<Plano>(planoViewModel));
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanoExists(planoViewModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(_mapper.Map<PlanoViewModel>(planoViewModel));
        }

        // GET: Planos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plano = await _planoDAL.FindByIdAsync((int)id);
            if (plano == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<PlanoViewModel>(plano));
        }

        // POST: Planos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plano = await _planoDAL.FindByIdAsync((int)(id));
            _planoDAL.Delete(plano);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanoExists(int id)
        {
            return _planoDAL.FindByIdAsync((int)id) != null;
        }
    }
}
