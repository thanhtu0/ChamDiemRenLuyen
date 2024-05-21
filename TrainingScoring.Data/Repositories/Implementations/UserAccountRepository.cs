using Microsoft.EntityFrameworkCore;
using TrainingScoring.Data.Repositories.Interfaces;

namespace TrainingScoring.Data.Repositories.Implementation
{
    public class UserAccountRepository :  IUserAccountRepository
    {
        private readonly TrainingScoingDBContext _context;

        public UserAccountRepository(TrainingScoingDBContext context)
        {
            _context = context;
        }

        public async Task<string> LoginAsync(string code, string password)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.StudentCode == code && s.Password == password);
            if (student != null)
            {
                return student.StudentCode;
            }

            var teacher = await _context.Lecturers.FirstOrDefaultAsync(l => l.LecturerCode == code && l.Password == password);
            if (teacher != null)
            {
                return teacher.LecturerCode;
            }

            return null;
        }
        public async Task<bool> ChangePasswordAsync(string code, string newPassword)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.StudentCode == code);
            if (student != null)
            {
                student.Password = newPassword;
                _context.Students.Update(student);
                await _context.SaveChangesAsync();
                return true;
            }

            var lecturer = await _context.Lecturers.FirstOrDefaultAsync(l => l.LecturerCode == code);
            if (lecturer != null)
            {
                lecturer.Password = newPassword;
                _context.Lecturers.Update(lecturer);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

    }
}
