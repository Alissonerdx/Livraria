using Livraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : Base
    {
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
        T GetById(int id);
        IList<T> GetAll();
    }
}
