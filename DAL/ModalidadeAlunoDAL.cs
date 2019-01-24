using Gaditas.Entities;
using GaditasDataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gaditas.DAL
{
    public class ModalidadeAlunoDAL
    {
        private GenericRepository<ModalidadeAluno> _repository;
        private readonly AppDataContext _context;
        public ModalidadeAlunoDAL(AppDataContext context)
        {
            _repository = new GenericRepository<ModalidadeAluno>(context);
            _context = context;
        }


        public List<ModalidadeAluno> GetAll()
        {
            return _context.Modalidades_Alunos
                        .Include(blog => blog.Modalidade)
                        .Include(aluno => aluno.Aluno)
                        .Where(x => !x.DELETADO)
                    .ToList();
        }

        public ModalidadeAluno FindById(int id)
        {
            return _context.Modalidades_Alunos
                        .Include(blog => blog.Modalidade)
                        .Include(aluno => aluno.Aluno)
                    .Where(x=>x.ID == id).FirstOrDefault();
        }
        public List<ModalidadeAluno> FindByIdAluno(int idAluno)
        {
            return _context.Modalidades_Alunos
                        .Include(blog => blog.Modalidade)
                        .Include(aluno => aluno.Aluno)
                    .Where(x => x.ID_ALUNO == idAluno).ToList();
        }


        public ModalidadeAluno Delete(ModalidadeAluno modalidadeAluno) 
        {
            modalidadeAluno.DELETADO = true;
            modalidadeAluno.DT_DELETADO = DateTime.Now;

            return modalidadeAluno;
        }

        public async Task SaveChangesAsync() => await _repository.SaveChangesAsync();

        public async Task Add(ModalidadeAluno modalidadeAluno)
        {
            modalidadeAluno.DT_CADASTRO = DateTime.Now;
            modalidadeAluno.DT_ATUALIZACAO = null;
            await _repository.AddAsync(modalidadeAluno);
        }

        public void Update(int id, ModalidadeAluno modalidadeAluno)
        {
            var dbModalidadeAluno = FindById(id);

            dbModalidadeAluno.DT_ATUALIZACAO = DateTime.Now;

            _repository.Update(dbModalidadeAluno);
        }
    }
}
