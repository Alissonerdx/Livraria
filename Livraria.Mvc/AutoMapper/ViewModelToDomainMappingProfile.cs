using AutoMapper;
using Livraria.Domain.Entities;
using Livraria.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Mvc.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<LivroViewModel, Livro>();
            CreateMap<EditoraViewModel, Editora>();
            CreateMap<AutorViewModel, Autor>();
        }
    }
}
