using System;
using System.Collections.Generic;

namespace Study.Domain.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(Guid id);
        void SaveChanges();
    }
}
