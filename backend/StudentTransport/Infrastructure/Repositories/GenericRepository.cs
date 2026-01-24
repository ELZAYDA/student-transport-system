using Application.Interfaces;
using Domain.Common;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
    where T : BaseEntity
    {
        protected readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T?> GetByIdAsync(int id)
            => await _context.Set<T>().FindAsync(id);

        public async Task<IReadOnlyList<T>> GetAllAsync()
            => await _context.Set<T>().ToListAsync();

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}
