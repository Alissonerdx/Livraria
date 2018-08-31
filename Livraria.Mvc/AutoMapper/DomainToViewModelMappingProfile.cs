using AutoMapper;
using Livraria.Domain.Entities;
using Livraria.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Mvc.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Livro, LivroViewModel>();
            CreateMap<Editora, EditoraViewModel>();
            CreateMap<Autor, AutorViewModel>();
        }
    }
}
