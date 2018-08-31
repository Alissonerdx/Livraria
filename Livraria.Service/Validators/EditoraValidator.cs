using FluentValidation;
using Livraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Service.Validators
{
    public class EditoraValidator : AbstractValidator<Editora>
    {
        public EditoraValidator()
        {
            RuleFor(e => e)
                   .NotNull()
                   .OnAnyFailure(x =>
                   {
                       throw new ArgumentNullException("Editora não foi encontrada");
                   });

            RuleFor(l => l.Nome)
                    .NotEmpty().WithMessage("É necessario informar o Nome")
                    .NotNull().WithMessage("É necessario informar o Nome");

            RuleFor(l => l.DataCadastro)
                    .NotNull().WithMessage("É necessario informar a Data de Cadastro");
        }
    }
}
