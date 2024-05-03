using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingScoring.Data.Repositories.Interface
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAnsync(int id);
        Task<int> CreateAsync(T entity);
        Task<int> UpdateASync(T entity);
        Task<int> DeleteAsync(int id);
    }
}
