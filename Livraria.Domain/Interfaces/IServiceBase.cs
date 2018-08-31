using FluentValidation;
using Livraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Interfaces
{
    public interface IServiceBase<T> where T : Base
    {
        T Post<V>(T obj) where V : AbstractValidator<T>;
        T Put<V>(T obj) where V : AbstractValidator<T>;
        void Delete(int id);
        T GetById(int id);
        IList<T> GetAll();
    }
}
