using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TrainingScoring.Business.Services.Interfaces;
using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Business.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IRoleRepository _roleRepository;

        private readonly IStudentRepository _studentRepository;
        private readonly ILecturerRepository _lecturerRepository;

        public UserService(ILogger<UserService> logger, IHttpContextAccessor httpContextAccessor, IUserAccountRepository userAccountRepository, IRoleRepository roleRepository, IStudentRepository studentRepository, ILecturerRepository lecturerRepository)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _userAccountRepository = userAccountRepository;
            _roleRepository = roleRepository;
            _studentRepository = studentRepository;
            _lecturerRepository = lecturerRepository;
        }

        public async Task<string> LoginAsync(string code, string password)
        {
            try
            {
                var user = await _userAccountRepository.LoginAsync(code, password);
                _logger.LogInformation($"User code service: {user}");
                if (user == null)
                {
                    _logger.LogWarning("Login failed: Invalid username or password.");
                    return null;
                }
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                throw new ApplicationException("Error occurred while login failed", ex);
            }
        }

        public async Task<List<Role>> GetAllUserRolesAsync()
        {
            return await _roleRepository.GetAllAsync();
        }

        public async Task<List<string>> GetUserRolesAsync(string code)
        {
            var roles = await _lecturerRepository.GetUserRolesAsync(code);
            if (roles == null || roles.Count() == 0)
            {
                return new List<string>();
            }
            return roles;
        }

        public async Task<Student> GetStudentAsync(string code)
        {
            return await _studentRepository.GetStudentByCodeAsync(code);
        }

        public async Task<Lecturer> GetLecturerAsync(string code)
        {
            return await _lecturerRepository.GetLecturerAsync(code);
        }

        public async Task<Student> GetStudentByCodeAsync(string studentCode)
        {
            return await _studentRepository.GetStudentByCodeAsync(studentCode);
        }

        public async Task<Lecturer> GetLecturerByCodeAsync(string lecturerCode)
        {
            return await _lecturerRepository.GetLecturerByCodeAsync(lecturerCode);
        }
        public async Task<string> ChangePasswordAsync(string code, string oldPassword, string newPassword)
        {
            try
            {
                var user = await _userAccountRepository.LoginAsync(code, oldPassword);
                if (user == null)
                {
                    _logger.LogWarning("Change password failed: Invalid old password.");
                    return "invalid_old_password";
                }
                if (oldPassword == newPassword)
                {
                    _logger.LogWarning("Change password failed: New password matches old password.");
                    return "new_password_same_as_old";
                }

                var result = await _userAccountRepository.ChangePasswordAsync(code, newPassword);
                return result ? "success" : "error";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                throw new ApplicationException("Error occurred while changing password", ex);
            }
        }
    }
}
