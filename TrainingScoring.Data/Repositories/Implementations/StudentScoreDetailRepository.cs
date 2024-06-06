using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Implementations
{
    public class StudentScoreDetailRepository : Repository<StudentScoreDetail>, IStudentScoreDetailRepository
    {
        private readonly TrainingScoingDBContext _context;

        public StudentScoreDetailRepository(TrainingScoingDBContext context) : base(context)
        {
            _context = context;
        }


        public async Task<StudentScoreDetail> GetStudentScore(int studentId, int detailId)
        {
            return await _context.StudentScoreDetails.FirstOrDefaultAsync(s => s.StudentId == studentId && s.TrainingDetailId == detailId);
        }

        public async Task<List<StudentScoreDetail>> GetByIdAsync(int studentId)
        {
            return await _context.StudentScoreDetails.Where(s => s.StudentId == studentId).ToListAsync();
        }
    }
}
