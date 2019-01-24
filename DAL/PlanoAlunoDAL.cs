using Gaditas.Entities;
using GaditasDataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gaditas.DAL
{
    public class PlanoAlunoDAL
    {
        private GenericRepository<PlanoAluno> _repository;
        private AppDataContext _context;
        public PlanoAlunoDAL(AppDataContext context)
        {
            _repository = new GenericRepository<PlanoAluno>(context);
            _context = context;
        }


        public IEnumerable<PlanoAluno> GetAll()
        {
            return _context.Planos_Alunos
                       .Include(blog => blog.Aluno)
                       .Include(aluno => aluno.Plano)
                       .Where(x => !x.DELETADO)
                   .ToList();
        }

        public async Task<PlanoAluno> FindByIdAsync(int id) => await _repository.FindByIDAsync(id);
        public PlanoAluno FindById(int id)
        {
            return _context.Planos_Alunos
                        .Include(blog => blog.Aluno)
                        .Include(aluno => aluno.Plano)
                    .Where(x => x.ID == id).FirstOrDefault();
        }
        public List<PlanoAluno> FindByIdAluno(int idAluno)
        {
            return _context.Planos_Alunos
                        .Include(blog => blog.Aluno)
                        .Include(aluno => aluno.Plano)
                    .Where(x => x.ID_ALUNO == idAluno).ToList();
        }
        public PlanoAluno Delete(PlanoAluno plano) {
            plano.DELETADO = true;
            plano.DT_DELETADO = DateTime.Now;

            return plano;
        }
        public async Task SaveChangesAsync() => await _repository.SaveChangesAsync();

        public async Task Add(PlanoAluno planoAluno)
        {
            planoAluno.DT_CADASTRO = DateTime.Now;
            planoAluno.DT_ATUALIZACAO = null;

            //Incluir Mensalidades
            await new PagamentoDAL(_context).IncluirMensalidades(planoAluno);

            await _repository.AddAsync(planoAluno);
        }

        public void Update(int id, PlanoAluno plano)
        {
            var dbPlanoAluno = FindById(id);
            
            dbPlanoAluno.DT_INICIO = plano.DT_INICIO;

            dbPlanoAluno.DT_ATUALIZACAO = DateTime.Now;

            _repository.Update(dbPlanoAluno);
        }
    }
}
