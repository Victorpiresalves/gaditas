using Gaditas.Entities;
using GaditasDataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gaditas.DAL
{
    public class AlunoDAL
    {
        private GenericRepository<Aluno> _repository;
        public AlunoDAL(AppDataContext context)
        {
            _repository = new GenericRepository<Aluno>(context);
        }


        public List<Aluno> GetAll() => _repository.GetAll().Where(x => !x.DELETADO).ToList();
        public async Task<Aluno> FindByIdAsync(int id) => await _repository.FindByIDAsync(id);
        public Aluno FindById(int id) => _repository.FindByID(id);
        public Aluno Delete(Aluno aluno)
        {
            aluno.DELETADO = true;
            aluno.DT_DELETADO = DateTime.Now;

            return aluno;
        }

        public async Task SaveChangesAsync() => await _repository.SaveChangesAsync();

        public async Task Add(Aluno aluno)
        {
            aluno.DT_CADASTRO = DateTime.Now;
            aluno.DT_ATUALIZACAO = null;
            await _repository.AddAsync(aluno);
        }

        public void Update(int id, Aluno aluno)
        {
            var dbAluno = FindById(id);
            dbAluno.CPF = aluno.CPF;
            dbAluno.RG = aluno.RG;
            dbAluno.NOME_COMPLETO = aluno.NOME_COMPLETO;
            dbAluno.DT_NASCIMENTO = aluno.DT_NASCIMENTO;

            dbAluno.DT_ATUALIZACAO = DateTime.Now;


            _repository.Update(dbAluno);
        }
    }
}
