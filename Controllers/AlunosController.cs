using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gaditas.Models;
using GaditasDataContext;
using AutoMapper;
using Gaditas.DAL;
using Gaditas.Entities;
using Microsoft.AspNetCore.Cors;

namespace Gaditas.Controllers
{
    public class AlunosController : BaseController
    {
        private readonly AppDataContext _context;
        private readonly IMapper _mapper;
        private readonly AlunoDAL _alunoDAL;

        public AlunosController(AppDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _alunoDAL = new AlunoDAL(_context);
        }

        // GET: Alunos
        public async Task<IActionResult> Index()
        {
            var alunos = await _alunoDAL.GetAllAsync();
            return View(_mapper.Map<List<AlunoViewModel>>(alunos));
        }

        // GET: Alunos/Details/5
        public async Task<IActionResult> Details(int? id, string message)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoViewModel = await _alunoDAL.FindByIdAsync((int)id);
            if (alunoViewModel == null)
            {
                return NotFound(); 
            }

            ViewBag.ModalidadesAluno = _mapper.Map<List<ModalidadeAlunoViewModel>>(new ModalidadeAlunoDAL(_context).FindByIdAluno((int)id));
            ViewBag.PlanosAluno = _mapper.Map<List<PlanoAlunoViewModel>>(new PlanoAlunoDAL(_context).FindByIdAluno((int)id));
            ViewBag.PagamentosAluno = _mapper.Map<List<PagamentoViewModel>>(new PagamentoDAL(_context).FindByIdAluno((int)id));
            ViewData["ID_ALUNO"] = id;
            return View(_mapper.Map<AlunoViewModel>(alunoViewModel));
        }
        [EnableCors]

        public async Task<JsonResult> getAlunosAsync()
        {
            var alunos = await _alunoDAL.GetAllAsync();
            var parse = _mapper.Map<List<AlunoViewModel>>(alunos);
            return Json(parse);
        }

        // GET: Alunos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AlunoViewModel alunoViewModel)
        {
            NotifyMessage(Enums.NotifyTypeEnum.success, $"Aluno cadastrado com sucesso!<a href='#'>teste</a>");

            if (ModelState.IsValid)
            {
                await _alunoDAL.Add(_mapper.Map<Aluno>(alunoViewModel));
                await _alunoDAL.SaveChangesAsync();

                NotifyMessage(Enums.NotifyTypeEnum.success, $"Aluno cadastrado com sucesso!<a href='#'>teste</a>");
                return RedirectToAction(nameof(Index));
            }
            return View(_mapper.Map<AlunoViewModel>(alunoViewModel));
        }

        // GET: Alunos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoViewModel = await _alunoDAL.FindByIdAsync((int)id);
            if (alunoViewModel == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<AlunoViewModel>(alunoViewModel));
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AlunoViewModel alunoViewModel)
        {
            if (id != alunoViewModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _alunoDAL.Update(id,_mapper.Map<Aluno>(alunoViewModel));

                    NotifyMessage(Enums.NotifyTypeEnum.success, "Aluno atualizado com sucesso!");

                    await _alunoDAL.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoViewModelExists(alunoViewModel.ID))
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
            return View(_mapper.Map<AlunoViewModel>(alunoViewModel));
        }

        // GET: Alunos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoViewModel = await _alunoDAL.FindByIdAsync((int)id);
            if (alunoViewModel == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<AlunoViewModel>(alunoViewModel));
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alunoViewModel = await _alunoDAL.FindByIdAsync((int)id);
            _alunoDAL.Delete(alunoViewModel);


            NotifyMessage(Enums.NotifyTypeEnum.success, "Aluno deletado com sucesso!");

            await _alunoDAL.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoViewModelExists(int id)
        {
            return _alunoDAL.FindByIdAsync((int)id) != null;
        }
    }
}
