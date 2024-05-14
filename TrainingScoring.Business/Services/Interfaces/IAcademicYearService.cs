using TrainingScoring.DomainModels;

namespace TrainingScoring.Business.Services.Interfaces
{
    public interface IAcademicYearService
    {
        // AcademicYear   
        #region AcademicYear
        Task<List<AcademicYear>> GetAllAcademicYearsAsync();
        Task<AcademicYear> GetAcademicYearByIdAsync(int id);
        Task<AcademicYear> CreateAcademicYearAsync(AcademicYear academicYear);
        Task<AcademicYear> UpdateAcademicYearAsync(AcademicYear academicYear);
        Task<AcademicYear> DeleteAcademicYearAsync(AcademicYear academicYear);
        #endregion
    }
}
