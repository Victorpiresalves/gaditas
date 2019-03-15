using System.Collections.Generic;
using System.Threading.Tasks;
using Gaditas.DAL;
using Gaditas.Entities;
using GaditasDataContext;

namespace Gaditas.Adapter
{
    public class ModalidadeAlunoAdapter
    {
        private readonly AppDataContext _context;
        private readonly ModalidadeAlunoDAL _modalidadeAlunoDAL;
        public ModalidadeAlunoAdapter(AppDataContext context)
        {
            _context = context;
            _modalidadeAlunoDAL = new ModalidadeAlunoDAL(_context);
        }


        public List<ModalidadeAluno> GetAll() => _modalidadeAlunoDAL.GetAll();


        public ModalidadeAluno FindById(int id) => _modalidadeAlunoDAL.FindById(id);

        public List<ModalidadeAluno> FindByIdAluno(int idAluno) => _modalidadeAlunoDAL.FindByIdAluno(idAluno);


        public ModalidadeAluno Delete(ModalidadeAluno modalidadeAluno) => _modalidadeAlunoDAL.Delete(modalidadeAluno);

        public async Task SaveChangesAsync() => await _modalidadeAlunoDAL.SaveChangesAsync();

        public async Task Add(ModalidadeAluno modalidadeAluno) => await _modalidadeAlunoDAL.Add(modalidadeAluno);

        public void Update(int id, ModalidadeAluno modalidadeAluno) => _modalidadeAlunoDAL.Update(id, modalidadeAluno);

        public ModalidadeAluno ReturnModalidadeAlunoByIdAlunoAndIdModalidade(int idAluno, int idMolidade) => _modalidadeAlunoDAL.ReturnModalidadeAlunoByIdAlunoAndIdModalidade(idAluno, idMolidade);
    }
}