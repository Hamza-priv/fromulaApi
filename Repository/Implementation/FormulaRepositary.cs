using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fromulaApi.DataBase;
using Microsoft.EntityFrameworkCore;

namespace fromulaApi.Repository.Implementation
{
    public class FormulaRepositary<T> : IFormulaRepo<T> where T : class
    {
        protected FormulaDatabase _context;

        // Specify which table I want to connect. 
        internal DbSet<T> _dbSet;

        public FormulaRepositary(FormulaDatabase context)
        {
            _context = context;
            //Here we are telling dbSet that he needs to connect with this context and which has type "T"
            this._dbSet = context.Set<T>();
        }
        public async Task<bool> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public async Task<IEnumerable<T>> All()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<bool> Delete(T entity)
        {
            _dbSet.Remove(entity);
            return true;
        }

// ? make it nullable
        public virtual async Task<T?> GetByID(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<bool> Update(T entity)
        {
            _dbSet.Update(entity);
            return true;
        }
    }
}