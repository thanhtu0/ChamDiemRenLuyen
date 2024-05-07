﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingScoring.Data.Repositories.Interfaces;
using TrainingScoring.DomainModels;

namespace TrainingScoring.Data.Repositories.Implementations
{
    public class ProcessDetailRepository : Repository<ProcessDetail>, IProcessDetailRepository
    {
        private readonly TrainingScroingDBContext _context;
        public ProcessDetailRepository(TrainingScroingDBContext context) : base(context)
        {
            _context = context;
        }
    }
}