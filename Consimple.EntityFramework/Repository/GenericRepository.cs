﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Consimple.EntityFramework.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task Create(T entity)
        {
            await Table.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            Table.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            Table.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetById(long id)
        {
            return await Table.FindAsync(id);
        }

        public IQueryable<T> GetAll()
        {
            return Table.AsQueryable();
        }

        public async Task<T> GetBy(Expression<Func<T, bool>> expression)
        {
            return await Table.FirstOrDefaultAsync(expression);
        }
    }
}