﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingScoring.Data.Repositories.Interfaces;

namespace TrainingScoring.Data.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly TrainingScroingDBContext _context;

        public Repository(TrainingScroingDBContext context)
        {
            _context = context;
        }
        public async Task<int> CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAnsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<int> UpdateASync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
