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
    public class ModalidadesController : Controller
    {
        private readonly AppDataContext _context;
        private readonly IMapper _mapper;
        private readonly ModalidadeDAL _modalidadeDAL;

        public ModalidadesController(AppDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _modalidadeDAL = new ModalidadeDAL(_context);
        }

        // GET: Modalidades
        public async Task<IActionResult> Index()
        {
            var modalidades = await _modalidadeDAL.GetAllAsync();
            return View(_mapper.Map<List<ModalidadeViewModel>>(modalidades));
        }

        // GET: Modalidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modalidade = await _modalidadeDAL.FindByIdAsync((int)id);
            if (modalidade == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<ModalidadeViewModel>(modalidade));
        }

        // GET: Modalidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Modalidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ModalidadeViewModel modalidadeViewModel)
        {
            if (new ModalidadeValidator(_context, ModelState).CustomValidator(modalidadeViewModel).IsValid)
            {
                await _modalidadeDAL.Add(_mapper.Map<Modalidade>(modalidadeViewModel));
                await _modalidadeDAL.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modalidadeViewModel);
        }

        // GET: Modalidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modalidade = await _modalidadeDAL.FindByIdAsync((int)id);
            if (modalidade == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<ModalidadeViewModel>(modalidade));
        }

        // POST: Modalidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ModalidadeViewModel modalidadeViewModel)
        {
            if (id != modalidadeViewModel.ID)
            {
                return NotFound();
            }

            if (new ModalidadeValidator(_context, ModelState).CustomValidator(modalidadeViewModel).IsValid)
            {
                try
                {
                    _modalidadeDAL.Update(id, _mapper.Map<Modalidade>(modalidadeViewModel));
                    await _modalidadeDAL.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModalidadeExists(modalidadeViewModel.ID))
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
            return View(modalidadeViewModel);
        }

        // GET: Modalidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modalidade = await _modalidadeDAL.FindByIdAsync((int)id);
            if (modalidade == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<ModalidadeViewModel>(modalidade));
        }

        // POST: Modalidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modalidade = await _modalidadeDAL.FindByIdAsync(id);
            _modalidadeDAL.Delete(modalidade);
            await _modalidadeDAL.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModalidadeExists(int id)
        {
            return _modalidadeDAL.FindByIdAsync((int)id) != null;
        }
    }
}
