using Microsoft.EntityFrameworkCore;
using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Implementations
{
    public class LecturerRepository : Repository<Lecturer>, ILecturerRepository
    {
        private readonly TrainingScoingDBContext _context;
        public LecturerRepository(TrainingScoingDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Lecturer> GetLecturerAsync(string lecturerCode)
        {
            var lec = await _context.Lecturers.FirstOrDefaultAsync(l => l.LecturerCode == lecturerCode);
            return lec;
        }

        public async Task<List<string>> GetUserRolesAsync(string lecturerCode)
        {
            var users = _context.Lecturers.ToList();
            var roles = _context.Roles.ToList();
            var userRoles = _context.LecturerRoleAssignments.ToList();

            var getRole = from u in users
                          join ur in userRoles on u.LecturerId equals ur.LecturerId
                          join r in roles on ur.RoleId equals r.RoleId
                          where u.LecturerCode == lecturerCode
                          select r.RoleName;

            return getRole.ToList();
        }
    }
}
