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
using Gaditas.Adapter;
using Gaditas.Validators;

namespace Gaditas.Controllers
{
    public class ModalidadesAlunosController : BaseController
    {
        private readonly AppDataContext _context;
        private readonly IMapper _mapper;
        private readonly ModalidadeAlunoDAL _modalidadeAlunoDAL;

        public ModalidadesAlunosController(AppDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _modalidadeAlunoDAL = new ModalidadeAlunoDAL(_context);
        }

        // GET: ModalidadesAlunos
        public IActionResult Index(int? id_aluno)
        {
            var modalidadesAlunos = _modalidadeAlunoDAL.GetAll();
            if (id_aluno != 0 && id_aluno != null)
            {
                modalidadesAlunos = modalidadesAlunos.Where(x => x.ID_ALUNO == id_aluno).ToList();
            }
            return View(_mapper.Map<List<ModalidadeAlunoViewModel>>(modalidadesAlunos));
        }

        // GET: ModalidadesAlunos/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modalidadeAlunoViewModel = _modalidadeAlunoDAL.FindById((int)id);
            if (modalidadeAlunoViewModel == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<ModalidadeAlunoViewModel>(modalidadeAlunoViewModel));
        }

        // GET: ModalidadesAlunos/Create
        public IActionResult Create(int? id_aluno)
        {
            var modalidadesAluno = new ModalidadeAlunoViewModel
            {
                ID_ALUNO = id_aluno != null ? (int)id_aluno : 0,
                ListaModalidades = new ModalidadesAdapter(_context).GetList()
            };
            ViewData["ID_ALUNO"] = id_aluno;

            return View(modalidadesAluno);
        }

        // POST: ModalidadesAlunos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ModalidadeAlunoViewModel modalidadeAlunoViewModel)
        {
            //Carregar lista de modalidades
            modalidadeAlunoViewModel.ListaModalidades = new ModalidadesAdapter(_context).GetList();

            if (new ModalidadeAlunoValidator(_context, ModelState).CustomValidator(modalidadeAlunoViewModel).IsValid)
            {
                await _modalidadeAlunoDAL.Add(_mapper.Map<ModalidadeAluno>(modalidadeAlunoViewModel));
                await _modalidadeAlunoDAL.SaveChangesAsync();

                NotifyMessage(Enums.NotifyTypeEnum.success, "Modalidade inserida com sucesso!");
                return RedirectToAction("Details", "Alunos", new { id = modalidadeAlunoViewModel.ID_ALUNO, message = "Modalidade inserida com sucesso!" });
            }
            AddErrors();
            return View(modalidadeAlunoViewModel);
            //ViewBag.Teste = "teste";
            //return RedirectToAction("Details", "Alunos", new { id = modalidadeAlunoViewModel.ID_ALUNO });
            //return View(modalidadeAlunoViewModel);
            //return RedirectToAction("Details", "Alunos", new { id = modalidadeAlunoViewModel.ID_ALUNO });
        }

        // GET: ModalidadesAlunos/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modalidadeAlunoViewModel = _modalidadeAlunoDAL.FindById((int)id);
            if (modalidadeAlunoViewModel == null)
            {
                return NotFound();
            }
            return View(modalidadeAlunoViewModel);
        }

        // POST: ModalidadesAlunos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ModalidadeAlunoViewModel modalidadeAlunoViewModel)
        {
            if (id != modalidadeAlunoViewModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _modalidadeAlunoDAL.Update(id, _mapper.Map<ModalidadeAluno>(modalidadeAlunoViewModel));
                    await _modalidadeAlunoDAL.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModalidadeAlunoViewModelExists(modalidadeAlunoViewModel.ID))
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
            return View(modalidadeAlunoViewModel);
        }

        // GET: ModalidadesAlunos/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modalidadeAlunoViewModel = _modalidadeAlunoDAL.FindById((int)id);
            if (modalidadeAlunoViewModel == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<ModalidadeAlunoViewModel>(modalidadeAlunoViewModel));
        }

        // POST: ModalidadesAlunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modalidadeAlunoViewModel = _modalidadeAlunoDAL.FindById((int)id);
            _modalidadeAlunoDAL.Delete(modalidadeAlunoViewModel);
            await _modalidadeAlunoDAL.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModalidadeAlunoViewModelExists(int id)
        {
            return _modalidadeAlunoDAL.FindById((int)id) != null;
        }
    }
}
