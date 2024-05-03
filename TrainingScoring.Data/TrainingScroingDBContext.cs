using TrainingScoring.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingScoring.Data
{
    public class TrainingScroingDBContext : DbContext
    {
        public TrainingScroingDBContext(DbContextOptions<TrainingScroingDBContext> options) : base(options)
        {

        }

        #region DbSet
        public DbSet<Major> Majors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<LecturerRoleAssignment> LecturersRoleAssignments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<ClassCommittee> ClassCommittees { get; set; }
        public DbSet<StudentClassCommittee> StudentClassCommittees { get; set; } 
        public DbSet<ProcessDetail> ProcessDetails { get; set; }
        public DbSet<ScoringProcess> ScoringProcesses { get; set; }
        public DbSet<ScoreDetail> Scores { get; set; }
        public DbSet<Score> StudentScores { get; set; }
        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<EvaluationForm> EvaluationForms { get; set; }
        public DbSet<TrainingDirectory> TrainingDirectories { get; set; }
        public DbSet<TrainingContent> TrainingContents { get; set; }
        public DbSet<TrainingDetail> TrainingDetails { get; set; }
        public DbSet<Proof> Proofs { get; set; }
        public DbSet<TrainingContentProof> TrainingContentProofs { get; set; }
        public DbSet<TrainingDetailProof> TraniningDetailProofs { get; set; }
        public DbSet<Advisor> Advisors { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define composite primary key for LecturerRoleAssignment entity
            modelBuilder.Entity<LecturerRoleAssignment>()
                .HasKey(llr => new { llr.LecturerId, llr.RoleId });

            // Define composite primary key for StudentClassCommittee entity
            modelBuilder.Entity<StudentClassCommittee>()
                .HasKey(stc => new { stc.StudentId, stc.ClassCommitteeId });

            // Define composite primary key for TrainingContentProof entity
            modelBuilder.Entity<TrainingContentProof>()
                .HasKey(tcp => new { tcp.TrainingContentId, tcp.ProofId });

            // Define composite primary key for TraniningDetailProof entity
            modelBuilder.Entity<TrainingDetailProof>()
                .HasKey(tdp => new { tdp.TrainingDetailId, tdp.ProofId });

            // Define composite primary key for Advisor entity
            modelBuilder.Entity<Advisor>()
                .HasKey(a => new { a.LecturerId, a.GradeId });

            // Configure relationship between Lecturer and Advisor entities
            modelBuilder.Entity<Lecturer>()
                .HasMany(l => l.Advisors)
                .WithOne(a => a.Lecturer)
                .HasForeignKey(l => l.LecturerId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configure relationship between Score and EvaluationForm entities
            modelBuilder.Entity<Score>()
                    .HasOne(s => s.EvaluationForm)
                    .WithMany(e => e.Scores)
                    .HasForeignKey(s => s.EvalutionFormId)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
