using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Implementations
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private readonly TrainingScoingDBContext _context;
        public DepartmentRepository(TrainingScoingDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
