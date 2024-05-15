using Microsoft.EntityFrameworkCore;
using TrainingScoring.Data.Repositories.Interfaces;

namespace TrainingScoring.Data.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly TrainingScoingDBContext _context;

        public Repository(TrainingScoingDBContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<int> CreateAsync(T entity)
        {
            _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.GetType().GetProperty("Id")?.GetValue(entity) as int? ?? 0;
        }

        public async Task<int> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity.GetType().GetProperty("Id")?.GetValue(entity) as int? ?? 0;
        }

        public async Task<int> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync();
        }
    }
}
