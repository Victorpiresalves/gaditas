using Gaditas.Entities;
using GaditasDataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gaditas.DAL
{
    public class PagamentoDAL
    {
        private GenericRepository<Pagamento> _repository;
        private AppDataContext _context;
        public PagamentoDAL(AppDataContext context)
        {
            _repository = new GenericRepository<Pagamento>(context);
            _context = context;
        }


        public IEnumerable<Pagamento> GetAll()
        {
            return _context.Pagamentos
                       .Include(blog => blog.Aluno)
                       .Include(aluno => aluno.Plano)
                       .Where(x => !x.DELETADO)
                   .ToList();
        }

        public async Task<Pagamento> FindByIdAsync(int id) => await _repository.FindByIDAsync(id);
        public Pagamento FindById(int id)
        {
            return _context.Pagamentos
                        .Include(blog => blog.Aluno)
                        .Include(aluno => aluno.Plano)
                    .Where(x => x.ID == id).FirstOrDefault();
        }
        public List<Pagamento> FindByIdAluno(int idAluno)
        {
            return _context.Pagamentos
                        .Include(blog => blog.Aluno)
                        .Include(aluno => aluno.Plano)
                    .Where(x => x.ID_ALUNO == idAluno).ToList();
        }
        public Pagamento Delete(Pagamento pagamento) 
        {
            pagamento.DELETADO = true;
            pagamento.DT_DELETADO = DateTime.Now;

            return pagamento;
        }

        public async Task SaveChangesAsync() => await _repository.SaveChangesAsync();

        public async Task Add(Pagamento pagamento)
        {
            pagamento.DT_CADASTRO = DateTime.Now;
            pagamento.DT_ATUALIZACAO = null;
            await _repository.AddAsync(pagamento);
        }

        public void Update(int id, Pagamento pagamento)
        {
            var dbPagamento = FindById(id);

            dbPagamento.DT_ATUALIZACAO = DateTime.Now;

            _repository.Update(dbPagamento);
        }

        public async Task IncluirMensalidades(PlanoAluno planoAluno)
        {
            var Plano = new PlanoDAL(_context).FindById(planoAluno.ID_PLANO);

            for (int i = 0; i < Plano.QTD_MESES; i++)
            {
                await _repository.AddAsync(new Pagamento
                {
                    ID_ALUNO = planoAluno.ID_ALUNO,
                    ID_PLANO = planoAluno.ID_PLANO,
                    VALOR = Plano.VALOR / Plano.QTD_MESES,
                    PAGOU = false,
                    DESCRICAO = "Mensalidade",
                    DT_VENCIMENTO = planoAluno.DT_INICIO.AddMonths(i),
                    NUM_PARCELA = i + 1,
                    QTD_TOTAL_PARCELA = Plano.QTD_MESES,
                    DT_CADASTRO = DateTime.Now,
                });
            }

            if (planoAluno.INCLUIR_MATRICULA)
            {
                await _repository.AddAsync(new Pagamento
                {
                    ID_ALUNO = planoAluno.ID_ALUNO,
                    ID_PLANO = planoAluno.ID_PLANO,
                    VALOR = Plano.VALOR / Plano.QTD_MESES,
                    PAGOU = false,
                    DESCRICAO = "Matricula",
                    DT_VENCIMENTO = planoAluno.DT_INICIO,
                    NUM_PARCELA = 1,
                    QTD_TOTAL_PARCELA = 1,
                    DT_CADASTRO = DateTime.Now,
                });
            }
        }
    }
}
