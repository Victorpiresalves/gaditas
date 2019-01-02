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
                       .Include(aluno => aluno.Plano_Aluno)
                   .ToList();
        }

        public async Task<Pagamento> FindByIdAsync(int id) => await _repository.FindByIDAsync(id);
        public Pagamento FindById(int id)
        {
            return _context.Pagamentos
                        .Include(blog => blog.Aluno)
                        .Include(aluno => aluno.Plano_Aluno)
                    .Where(x => x.ID == id).FirstOrDefault();
        }
        public List<Pagamento> FindByIdAluno(int idAluno)
        {
            return _context.Pagamentos
                        .Include(blog => blog.Aluno)
                        .Include(aluno => aluno.Plano_Aluno)
                    .Where(x => x.ID_ALUNO == idAluno).ToList();
        }
        public Pagamento Delete(Pagamento pagamento) => _repository.Delete(pagamento);

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
    }
}
