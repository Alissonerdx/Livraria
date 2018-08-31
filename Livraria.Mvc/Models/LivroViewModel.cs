using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Mvc.Models
{
    public class LivroViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Titulo é obrigatório")]
        [Display(Name = "Título *")]
        public string Titulo { get; set; }

        public string ISBN { get; set; }

        [MaxLength(600)]
        public string Assunto { get; set; }

        public int Ano { get; set; }

        [Display(Name = "Quantidade de Páginas")]
        public int NumeroDePaginas { get; set; }

        [Display(Name = "Quantidade em Estoque")]
        public int QuantidadeEmEstoque { get; set; }

        [Display(Name = "Peso em gramas")]
        public double Peso { get; set; }

        [Required(ErrorMessage = "É necessario selecionar um Autor")]
        [Display(Name = "Autor *")]
        public int AutorId { get; set; }

        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

        public AutorViewModel Autor { get; set; }

        [Required(ErrorMessage = "É necessario selecionar uma Editora")]
        [Display(Name = "Editora *")]
        public int EditoraId { get; set; }

        public EditoraViewModel Editora { get; set; }
    }
}
