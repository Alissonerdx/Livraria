using FluentValidation;
using Livraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Service.Validators
{
    public class LivroValidator : AbstractValidator<Livro>
    {
        public LivroValidator()
        {
            RuleFor(l => l)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("Livro não foi encontrado.");
                    });

            RuleFor(l => l.Titulo)
                    .NotEmpty().WithMessage("É necessario informar o Titulo.")
                    .NotNull().WithMessage("É necessario informar o Titulo.");

            RuleFor(l => l.Assunto)
                   .MaximumLength(600).WithMessage("Quantidade de caracteres no Assunto excedeu o limite maximo.");


            RuleFor(l => l.Ano)
                    .LessThanOrEqualTo(DateTime.Now.Year).WithMessage("O Ano não pode ser maior que o ano atual.")
                    .GreaterThan(0).WithMessage("O Ano deve ser maior que 0.");

            RuleFor(l => l.DataCadastro)
                    .NotNull().WithMessage("É necessario informar a Data de Cadastro.");

            RuleFor(l => l.AutorId)
                    .NotEqual(0).WithMessage("AutorId não pode ser 0.");

            RuleFor(l => l.EditoraId)
                    .NotEqual(0).WithMessage("EditoraId não pode ser 0.");

        }
    }
}
