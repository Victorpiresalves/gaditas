using Gaditas.Entities;
using GaditasDataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gaditas.DAL
{
    public class PlanoDAL
    {
        private GenericRepository<Plano> _repository;
        private AppDataContext _context;
        public PlanoDAL(AppDataContext context)
        {
            _repository = new GenericRepository<Plano>(context);
            _context = context;
        }


        public IEnumerable<Plano> GetAll() => _repository.GetAll().Where(x => !x.DELETADO).ToList();
        public async Task<Plano> FindByIdAsync(int id) => await _repository.FindByIDAsync(id);
        public Plano FindById(int id) => _repository.FindByID(id);
        public Plano Delete(Plano plano) 
        {
            plano.DELETADO = true;
            plano.DT_DELETADO = DateTime.Now;

            return plano;
        }

        public async Task SaveChangesAsync() => await _repository.SaveChangesAsync();

        public async Task Add(Plano plano)
        {
            plano.DT_CADASTRO = DateTime.Now;
            plano.DT_ATUALIZACAO = null;
            await _repository.AddAsync(plano);
        }

        public void Update(int id, Plano plano)
        {
            var dbPlano = FindById(id);
            
            dbPlano.NOME = plano.NOME;
            dbPlano.VALOR = plano.VALOR;
            dbPlano.QTD_MESES = plano.QTD_MESES;

            dbPlano.DT_ATUALIZACAO = DateTime.Now;

            _repository.Update(dbPlano);
        }
        public Plano ReturnPlanoByNome(string nome)
        {
            return _context.Planos.Where(x => x.NOME == nome && !x.DELETADO).FirstOrDefault();
        }
    }
}
