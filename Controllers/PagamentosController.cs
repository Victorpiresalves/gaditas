using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gaditas.Entities;
using GaditasDataContext;
using Gaditas.DAL;
using AutoMapper;
using Gaditas.Models;

namespace Gaditas.Controllers
{
    public class PagamentosController : Controller
    {
        private readonly AppDataContext _context;
        private readonly PagamentoDAL _pagamentoDAL;
        private readonly IMapper _mapper;
        public PagamentosController(AppDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _pagamentoDAL = new PagamentoDAL(_context);
        }

        // GET: Pagamentos
        public IActionResult Index()
        {
            var pagamentos = _pagamentoDAL.GetAll();
            return View(_mapper.Map<List<PagamentoViewModel>>(pagamentos));
        }

        // GET: Pagamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamento = await _context.Pagamentos
                .Include(p => p.Aluno)
                .Include(p => p.Plano)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pagamento == null)
            {
                return NotFound();
            }

            return View(pagamento);
        }

        // GET: Pagamentos/Create
        public IActionResult Create()
        {
            ViewData["ID_ALUNO"] = new SelectList(_context.Alunos, "ID", "CPF");
            ViewData["ID_PLANO_ALUNO"] = new SelectList(_context.Planos_Alunos, "ID", "ID");
            return View();
        }

        // POST: Pagamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ID_ALUNO,ID_PLANO_ALUNO,VALOR,NUM_PARCELA,QTD_TOTAL_PARCELA,DT_VENCIMENTO,DT_CADASTRO,DT_ATUALIZACAO")] Pagamento pagamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_ALUNO"] = new SelectList(_context.Alunos, "ID", "CPF", pagamento.ID_ALUNO);
            ViewData["ID_PLANO_ALUNO"] = new SelectList(_context.Planos_Alunos, "ID", "ID", pagamento.ID_PLANO);
            return View(pagamento);
        }

        // GET: Pagamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamento = await _context.Pagamentos.Include(p=>p.Aluno).Include(p=>p.Plano).Where(p=>p.ID == id).FirstOrDefaultAsync();
            if (pagamento == null)
            {
                return NotFound();
            }
            ViewData["ID_ALUNO"] = new SelectList(_context.Alunos, "ID", "CPF", pagamento.ID_ALUNO);
            ViewData["ID_PLANO_ALUNO"] = new SelectList(_context.Planos_Alunos, "ID", "ID", pagamento.ID_PLANO);
            var x = _mapper.Map<PagamentoViewModel>(pagamento);
            return View(_mapper.Map<PagamentoViewModel>(pagamento));
        }

        // POST: Pagamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ID_ALUNO,ID_PLANO_ALUNO,VALOR,NUM_PARCELA,QTD_TOTAL_PARCELA,DT_VENCIMENTO,DT_CADASTRO,DT_ATUALIZACAO")] Pagamento pagamento)
        {
            if (id != pagamento.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagamentoExists(pagamento.ID))
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
            ViewData["ID_ALUNO"] = new SelectList(_context.Alunos, "ID", "CPF", pagamento.ID_ALUNO);
            ViewData["ID_PLANO_ALUNO"] = new SelectList(_context.Planos_Alunos, "ID", "ID", pagamento.ID_PLANO);
            return View(pagamento);
        }

        // GET: Pagamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamento = await _context.Pagamentos
                .Include(p => p.Aluno)
                .Include(p => p.Plano)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pagamento == null)
            {
                return NotFound();
            }

            return View(pagamento);
        }

        // POST: Pagamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pagamento = await _context.Pagamentos.FindAsync(id);
            _context.Pagamentos.Remove(pagamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagamentoExists(int id)
        {
            return _context.Pagamentos.Any(e => e.ID == id);
        }
    }
}
