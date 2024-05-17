using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingScoring.Data.Repositories.Implementations;
using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

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
            var teacher = await _context.Lecturers.FirstOrDefaultAsync(l => l.LecturerCode == code && l.Password == password);

            if (student != null)
            {
                return student.StudentCode;
            }
            else
            {
                return teacher.LecturerCode;
            }
        }

        public async Task<bool> ChangePasswordAsync(string code, string oldPassword, string newPassword, string confirmNewPassword)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.StudentCode == code && s.Password == oldPassword);
            if (student == null)
                return false;

            if (newPassword != confirmNewPassword)
                return false;

            student.Password = newPassword;
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
