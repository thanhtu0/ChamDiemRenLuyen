using TrainingScoring.DomainModels;

namespace TrainingScoring.Business.Services.Interfaces
{
    public  interface IStudentScoreService
    {
        Task<List<StudentScoreContent>> GetStudentScoreContentByIdAsync(int studentId);
        Task<StudentScoreContent> GetStudentTrainingContentByIdAsync(int studentId,int contentId);
        Task<StudentScoreContent> CreateStudentScoreContentAsync(StudentScoreContent studentScoreContent);
        Task<StudentScoreContent> UpdateStudentScoreContentAsync(StudentScoreContent studentScoreContent);

        Task<List<StudentScoreDetail>> GetStudentScoreDetailByIdAsync(int studentId);
        Task<StudentScoreDetail> GetStudentTrainingDetailByIdAsync(int studentId, int detailId);
        Task<StudentScoreDetail> CreateStudentScoreDetailAsync(StudentScoreDetail studentScoreDetail);
        Task<StudentScoreDetail> UpdateStudentScoreDetailAsync(StudentScoreDetail studentScoreDetail);

        Task<List<Score>> GetScorelByIdAsync(int studentId);
        Task<Score> GetScoreByIdAsync(int studentId, int scoreId);
        Task<Score> CreateScoreAsync(Score score);
        Task<Score> UpdateScoreAsync(Score score);

        Task<Score> GetScoreAsync(int studentId, int academicYearId);
    }
}
