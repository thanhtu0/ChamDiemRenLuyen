using TrainingScoring.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingScoring.Data
{
    public class TrainingScoingDBContext : DbContext
    {
        public TrainingScoingDBContext(DbContextOptions<TrainingScoingDBContext> options) : base(options)
        {

        }

        #region DbSet
        public DbSet<Major> Majors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<LecturerRoleAssignment> LecturerRoleAssignments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<ProcessDetail> ProcessDetails { get; set; }
        public DbSet<ScoringProcess> ScoringProcesses { get; set; }
        public DbSet<ScoreDetail> Scores { get; set; }
        public DbSet<Score> StudentScores { get; set; }
        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<EvaluationForm> EvaluationForms { get; set; }
        public DbSet<TrainingDirectory> TrainingDirectories { get; set; }
        public DbSet<TrainingContent> TrainingContents { get; set; }
        public DbSet<TrainingDetail> TrainingDetails { get; set; }
        public DbSet<Proof> Proofs { get; set; }
        public DbSet<TrainingContentProof> TrainingContentProofs { get; set; }
        public DbSet<TrainingDetailProof> TraniningDetailProofs { get; set; }
        public DbSet<GradeLecturerAssignment> GradeLecturerAssignments { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Define composite primary key for GradeLecturerAssignment entity
            modelBuilder.Entity<GradeLecturerAssignment>()
                .HasKey(glr => new { glr.LecturerId, glr.GradeId });

            modelBuilder.Entity<GradeLecturerAssignment>()
                .HasOne(gla => gla.Lecturer) 
                .WithMany(l => l.GradeLecturerAssignments)
                .HasForeignKey(gla => gla.LecturerId)
                .OnDelete(DeleteBehavior.NoAction);

            // Define composite primary key for LecturerRoleAssignment entity
            modelBuilder.Entity<LecturerRoleAssignment>()
                .HasKey(llr => new { llr.LecturerId, llr.RoleId });

            // Define composite primary key for TrainingContentProof entity
            modelBuilder.Entity<TrainingContentProof>()
                .HasKey(tcp => new { tcp.TrainingContentId, tcp.ProofId });

            // Define composite primary key for TraniningDetailProof entity
            modelBuilder.Entity<TrainingDetailProof>()
                .HasKey(tdp => new { tdp.TrainingDetailId, tdp.ProofId });

            // Configure relationship between Score and EvaluationForm entities
            modelBuilder.Entity<Score>()
                    .HasOne(s => s.EvaluationForm)
                    .WithMany(e => e.Scores)
                    .HasForeignKey(s => s.EvalutionFormId)
                    .OnDelete(DeleteBehavior.NoAction);

            // Lecturer gender (enum)
            modelBuilder.Entity<Lecturer>()
                    .Property(s => s.Gender)
                    .HasConversion(
                     v => v.ToString(),
                     v => (LecturerGender)Enum.Parse(typeof(LecturerGender), v));

            // Student gender (enum)
            modelBuilder.Entity<Student>()
                    .Property(s => s.Gender)
                    .HasConversion(
                     v => v.ToString(),
                     v => (StudentGender)Enum.Parse(typeof(StudentGender), v));

            // Student Classmittee gender (enum)
            modelBuilder.Entity<Student>()
                    .Property(s => s.IsClassmittee)
                    .HasConversion(
                     v => v.ToString(),
                     v => (Classmittee)Enum.Parse(typeof(Classmittee), v));

            // semester (enum)
            modelBuilder.Entity<AcademicYear>()
                    .Property(s => s.Semester)
                    .HasConversion(
                     v => v.ToString(),
                     v => (SemesterType)Enum.Parse(typeof(SemesterType), v));

            // TypeofScoreContent (enum)
            modelBuilder.Entity<TrainingContent>()
                    .Property(tc => tc.TypeofScore)
                    .HasConversion(
                     v => v.ToString(),
                     v => (TypeofScoreContent)Enum.Parse(typeof(TypeofScoreContent), v));

            // TypeofScoreDetail (enum)
            modelBuilder.Entity<TrainingDetail>()
                    .Property(td => td.TypeofScore)
                    .HasConversion(
                     v => v.ToString(),
                     v => (TypeofScoreDetail)Enum.Parse(typeof(TypeofScoreDetail), v));
        }
    }
}
