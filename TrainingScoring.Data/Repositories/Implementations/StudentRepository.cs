﻿using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Implementations
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly TrainingScoingDBContext _context;
        public StudentRepository(TrainingScoingDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
