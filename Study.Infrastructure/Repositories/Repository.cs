using Study.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly StudyContext _context;

        public Repository(StudyContext context) => _context = context;


        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public T GetById(Guid id)
        {
            return _context.Set<T>().FirstOrDefault(e => e.Id == id);
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            var editedEntity = _context.Set<T>().FirstOrDefault(e => e.Id == entity.Id);
            editedEntity = entity;
        }

        public void Delete(Guid id)
        {
            var entityToDelete = _context.Set<T>().FirstOrDefault(e => e.Id == id);
            if (entityToDelete != null)
            {
                _context.Set<T>().Remove(entityToDelete);
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
