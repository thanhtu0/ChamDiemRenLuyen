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
                _logger.LogInformation($"user code service: {user}");
                if (user == null)
                {
                    throw new Exception();
                }
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
                throw new ApplicationException("Error occurred while login failed", ex);
            }
        }

        public async Task<bool> ChangePasswordAsync(string code, string oldPassword, string newPassword, string confirmNewPassword)
        {
            return await _userAccountRepository.ChangePasswordAsync(code, oldPassword, newPassword, confirmNewPassword);
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
    }
}
