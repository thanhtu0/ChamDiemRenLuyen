using ChamDiemRenLuyen.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamDiemRenLuyen.Data
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
        public DbSet<Score> Scores { get; set; }
        public DbSet<StudentScore> StudentScores { get; set; }
        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<EvaluationForm> EvaluationForms { get; set; }
        public DbSet<TrainingDirectory> TrainingDirectories { get; set; }
        public DbSet<TrainingContent> TrainingContents { get; set; }
        public DbSet<TrainingDetail> TrainingDetails { get; set; }
        public DbSet<Proof> Proofs { get; set; }
        public DbSet<TrainingContentProof> TrainingContentProofs { get; set; }
        public DbSet<TraniningDetailProof> TraniningDetailProofs { get; set; }
        public DbSet<Advisor> Advisors { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LecturerRoleAssignment>()
                .HasKey(llr => new { llr.LecturerId, llr.RoleId });

            modelBuilder.Entity<StudentClassCommittee>()
                .HasKey(stc => new { stc.StudentId, stc.ClassCommitteeId });

            modelBuilder.Entity<TrainingContentProof>()
                .HasKey(tcp => new { tcp.TrainingContentId, tcp.ProofId });

            modelBuilder.Entity<TraniningDetailProof>()
                .HasKey(tdp => new { tdp.TrainingDetailId, tdp.ProofId });

            modelBuilder.Entity<Advisor>()
                .HasKey(a => new { a.LecturerId, a.GradeId });

            modelBuilder.Entity<Lecturer>()
                .HasMany(l => l.Advisors)
                .WithOne(a => a.Lecturer)
                .HasForeignKey(l => l.LecturerId)
                .OnDelete(DeleteBehavior.NoAction);

            #region
            //modelBuilder.Entity<Grade>(g =>
            //{
            //    g.ToTable("Grades")
            //        .HasKey(g => g.GradeId);
            //    g.HasOne(g => g.Department)
            //        .WithMany(d => d.Grades)
            //        .HasForeignKey(g => g.GradeId)
            //        .OnDelete(DeleteBehavior.NoAction);
            //    g.HasOne(g => g.Course)
            //        .WithMany(c => c.Grades)
            //        .HasForeignKey(g => g.CourseId)
            //        .OnDelete(DeleteBehavior.NoAction);
            //    g.HasOne(g => g.Major)
            //        .WithMany(m => m.Grades)
            //        .HasForeignKey(g => g.MajorId)
            //        .OnDelete(DeleteBehavior.NoAction);
            //    g.HasMany(g => g.Students)
            //        .WithOne(s => s.Grade)
            //        .HasForeignKey(g => g.StudentId)
            //        .OnDelete(DeleteBehavior.NoAction);
            //    g.HasMany(g => g.Advisors)
            //        .WithOne(a => a.Grade)
            //        .HasForeignKey(g => g.GradeId)
            //        .OnDelete(DeleteBehavior.NoAction);
            //});
            #endregion
        }
    }
}
