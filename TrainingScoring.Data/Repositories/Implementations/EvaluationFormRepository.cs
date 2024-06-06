using Microsoft.EntityFrameworkCore;
using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Implementations
{
    public class EvaluationFormRepository : Repository<EvaluationForm>, IEvaluationFormRepository
    {
        private readonly TrainingScoingDBContext _context;
        public EvaluationFormRepository(TrainingScoingDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<EvaluationForm> CreateAsync(EvaluationForm evaluationForm)
        {
            _context.Set<EvaluationForm>().Add(evaluationForm);
            await _context.SaveChangesAsync();
            return evaluationForm;
        }
        public async Task<EvaluationForm> GetByCodeAsync(string code)
        {
            return await _context.EvaluationForms.FirstOrDefaultAsync(e => e.EvaluationFormCode == code);
        }
        public async Task<EvaluationForm> GetByNameAsync(string name)
        {
            return await _context.EvaluationForms.FirstOrDefaultAsync(e => e.EvaluationFormName == name);
        }
        public async Task<EvaluationForm> GetEvaluationFormsByAcademicYearIdAsync(int academicYearId)
        {
            return await _context.EvaluationForms
                                 .FirstOrDefaultAsync(e => e.AcademicYearId == academicYearId);
        }
    }
}
