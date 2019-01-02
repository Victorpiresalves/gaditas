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
        public PlanoAluno Delete(PlanoAluno plano) => _repository.Delete(plano);

        public async Task SaveChangesAsync() => await _repository.SaveChangesAsync();

        public async Task Add(PlanoAluno plano)
        {
            plano.DT_CADASTRO = DateTime.Now;
            plano.DT_ATUALIZACAO = null;
            await _repository.AddAsync(plano);
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
