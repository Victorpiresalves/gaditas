using AutoMapper;
using Gaditas.Entities;
using Gaditas.Models;
using System.Collections.Generic;
using System.Linq;

namespace Gaditas.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Aluno, AlunoViewModel>().ReverseMap();
            CreateMap<Modalidade, ModalidadeViewModel>().ReverseMap();
            CreateMap<Plano, PlanoViewModel>().ReverseMap();

            CreateMap<ModalidadeAluno, ModalidadeAlunoViewModel>().ReverseMap();
            CreateMap<PlanoAluno, PlanoAlunoViewModel>().ReverseMap();

            //.ReverseMap();
        }
    }
}