using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Interfaces
{
    public interface IUserAccountRepository
    {
        Task<string> LoginAsync(string code, string password);
        Task<bool> ChangePasswordAsync(string code, string oldPassword, string newPassword, string confirmNewPassword);
    }
}
