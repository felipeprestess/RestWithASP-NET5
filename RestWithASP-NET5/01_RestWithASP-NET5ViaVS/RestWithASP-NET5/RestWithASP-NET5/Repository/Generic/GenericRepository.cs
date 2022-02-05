using Microsoft.EntityFrameworkCore;
using RestWithASP_NET5.Models.Base;
using RestWithASP_NET5.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASP_NET5.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySQLContext _context;
        private DbSet<T> _dataset;

        public GenericRepository(MySQLContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public T Create(T entity)
        {
            try
            {
                _dataset.Add(entity);
                _context.SaveChanges();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(long id)
        {
            var entity = _dataset.SingleOrDefault(p => p.Id.Equals(id));
            if (entity != null)
            {
                try
                {
                    _dataset.Remove(entity);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Exists(long id)
        {
            return _dataset.Any(p => p.Id == id);
        }

        public List<T> FindAll()
        {
            return _dataset.ToList();
        }

        public T FindByID(long id)
        {
            return _dataset.SingleOrDefault(p => p.Id.Equals(id));
        }

        public T Update(T entity)
        {
            var result = _dataset.SingleOrDefault(p => p.Id.Equals(entity.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(entity);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
