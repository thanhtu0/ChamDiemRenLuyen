using TrainingScoring.DomainModels;

namespace TrainingScoring.Business.Services.Interfaces
{
    public interface IUserService
    {
   
        Task<string> LoginAsync(string code, string password);
        Task<bool> ChangePasswordAsync(string code, string oldPassword, string newPassword, string confirmNewPassword);
        Task<List<Role>> GetAllUserRolesAsync();
        // get user role name
        Task<List<string>> GetUserRolesAsync(string code);
        Task<Student> GetStudentAsync(string code);
        Task<Lecturer> GetLecturerAsync(string code);

        Task<Student> GetStudentByCodeAsync(string studentCode);
        Task<Lecturer> GetLecturerByCodeAsync(string lecturerCode);
    }
}
