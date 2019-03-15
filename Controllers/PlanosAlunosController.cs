using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gaditas.Models;
using AutoMapper;
using GaditasDataContext;
using Gaditas.DAL;
using Gaditas.Entities;
using Gaditas.Adapter;

namespace Gaditas.Controllers
{
    public class PlanosAlunosController : Controller
    {
        private readonly AppDataContext _context;
        private readonly IMapper _mapper;
        private readonly PlanoAlunoDAL _planoAlunoDAL;

        public PlanosAlunosController(AppDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _planoAlunoDAL = new PlanoAlunoDAL(_context);
        }
        // GET: PlanosAlunos
        public IActionResult Index()
        {
            var planoAluno = _planoAlunoDAL.GetAll();
            return View(_mapper.Map<List<PlanoAlunoViewModel>>(planoAluno));
        }

        // GET: PlanosAlunos/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planoAlunoViewModel = _planoAlunoDAL.FindById((int)id);
            if (planoAlunoViewModel == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<PlanoAlunoViewModel>(planoAlunoViewModel));
        }

        // GET: PlanosAlunos/Create
        public IActionResult Create(int? id_aluno)
        {
            var planoAluno = new PlanoAlunoViewModel
            {
                ID_ALUNO = (int)id_aluno,
                DT_INICIO = DateTime.Now,
                ListaPlanos = new PlanoAdapter(_context).GetList()
            };

            return View(planoAluno);
        }

        // POST: PlanosAlunos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PlanoAlunoViewModel planoAlunoViewModel)
        {
            if (ModelState.IsValid)
            {
                await _planoAlunoDAL.Add(_mapper.Map<PlanoAluno>(planoAlunoViewModel));
                await _planoAlunoDAL.SaveChangesAsync();
              
                return RedirectToAction("Details", "Alunos", new { id = planoAlunoViewModel.ID_ALUNO, message = "Plano inserida com sucesso!" });
            }
            return View(planoAlunoViewModel);
        }

        // GET: PlanosAlunos/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planoAlunoViewModel = _planoAlunoDAL.FindById((int)id);
            if (planoAlunoViewModel == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<PlanoAlunoViewModel>(planoAlunoViewModel));
        }

        // POST: PlanosAlunos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PlanoAlunoViewModel planoAlunoViewModel)
        {
            if (id != planoAlunoViewModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planoAlunoViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanoAlunoViewModelExists(planoAlunoViewModel.ID))
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
            return View(planoAlunoViewModel);
        }

        // GET: PlanosAlunos/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planoAlunoViewModel = _planoAlunoDAL.FindById((int)id);
            if (planoAlunoViewModel == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<PlanoAlunoViewModel>(planoAlunoViewModel));
        }

        // POST: PlanosAlunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var planoAlunoViewModel = _planoAlunoDAL.FindById((int)id);
            _planoAlunoDAL.Delete(planoAlunoViewModel);
            await _planoAlunoDAL.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanoAlunoViewModelExists(int id)
        {
            return _planoAlunoDAL.FindByIdAsync((int)id) != null;
        }
    }
}
