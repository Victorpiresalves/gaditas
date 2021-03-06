﻿using Gaditas.Entities;
using GaditasDataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gaditas.DAL
{
    public class ModalidadeDAL
    {
        private GenericRepository<Modalidade> _repository;
        private AppDataContext _context;
        public ModalidadeDAL(AppDataContext context)
        {
            _repository = new GenericRepository<Modalidade>(context);
            _context = context;
        }


        public async Task<IEnumerable<Modalidade>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Modalidade> FindByIdAsync(int id) => await _repository.FindByIDAsync(id);
        public Modalidade FindById(int id) => _repository.FindByID(id);
        public Modalidade Delete(Modalidade modalidade) => _repository.Delete(modalidade);

        public async Task SaveChangesAsync() => await _repository.SaveChangesAsync();

        public async Task Add(Modalidade modalidade)
        {
            modalidade.DT_CADASTRO = DateTime.Now;
            modalidade.DT_ATUALIZACAO = null;
            await _repository.AddAsync(modalidade);
        }

        public void Update(int id, Modalidade modalidade)
        {
            var dbModalidade = FindById(id);
            
            dbModalidade.NOME = modalidade.NOME;
            dbModalidade.DT_ATUALIZACAO = DateTime.Now;
            dbModalidade.ATIVO = modalidade.ATIVO;

            _repository.Update(dbModalidade);
        }

        public Modalidade ReturnModalidadeByNome(string nome)
        {
            return _context.Modalidades.Where(x => x.NOME == nome).FirstOrDefault();
        }
    }
}
