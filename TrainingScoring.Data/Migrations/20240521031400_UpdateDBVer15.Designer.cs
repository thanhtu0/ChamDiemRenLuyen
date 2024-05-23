﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrainingScoring.Data;

#nullable disable

namespace TrainingScoring.Data.Migrations
{
    [DbContext(typeof(TrainingScoingDBContext))]
    [Migration("20240521031400_UpdateDBVer15")]
    partial class UpdateDBVer15
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TrainingScoring.DomainModels.AcademicYear", b =>
                {
                    b.Property<int>("AcademicYearId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AcademicYearId"), 1L, 1);

                    b.Property<string>("AcademicYearName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Semester")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SemesterCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AcademicYearId");

                    b.ToTable("AcademicYears");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"), 1L, 1);

                    b.Property<string>("CourseCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EndYear")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("StartYear")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"), 1L, 1);

                    b.Property<string>("DepartmentCode")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.EvaluationForm", b =>
                {
                    b.Property<int>("EvaluationFormId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EvaluationFormId"), 1L, 1);

                    b.Property<int>("AcademicYearId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("EvaluationFormCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EvaluationFormName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("EvaluationFormId");

                    b.HasIndex("AcademicYearId");

                    b.ToTable("EvaluationForms");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.Grade", b =>
                {
                    b.Property<int>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GradeId"), 1L, 1);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("GradeCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("GradeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("MajorId")
                        .HasColumnType("int");

                    b.HasKey("GradeId");

                    b.HasIndex("CourseId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("MajorId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.GradeLecturerAssignment", b =>
                {
                    b.Property<int>("LecturerId")
                        .HasColumnType("int");

                    b.Property<int>("GradeId")
                        .HasColumnType("int");

                    b.HasKey("LecturerId", "GradeId");

                    b.HasIndex("GradeId");

                    b.ToTable("GradeLecturerAssignments");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.Lecturer", b =>
                {
                    b.Property<int>("LecturerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LecturerId"), 1L, 1);

                    b.Property<string>("Contactaddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LecturerCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Lecturerclassification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobiePhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Workplaceunit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LecturerId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Lecturers");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.LecturerRoleAssignment", b =>
                {
                    b.Property<int>("LecturerId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("LecturerId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("LecturerRoleAssignments");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.Major", b =>
                {
                    b.Property<int>("MajorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MajorId"), 1L, 1);

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("MajorCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("MajorName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MajorId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Majors");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.ProcessDetail", b =>
                {
                    b.Property<int>("DetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetailId"), 1L, 1);

                    b.Property<int>("ProcessId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("DetailId");

                    b.HasIndex("ProcessId");

                    b.HasIndex("RoleId");

                    b.ToTable("ProcessDetails");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.Proof", b =>
                {
                    b.Property<int>("ProofId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProofId"), 1L, 1);

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSizeByte")
                        .HasColumnType("bigint");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProofId");

                    b.ToTable("Proofs");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<string>("RoleDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.Score", b =>
                {
                    b.Property<int>("ScoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScoreId"), 1L, 1);

                    b.Property<int>("AcademicYearId")
                        .HasColumnType("int");

                    b.Property<int>("EvalutionFormId")
                        .HasColumnType("int");

                    b.Property<int>("ProcessId")
                        .HasColumnType("int");

                    b.Property<int>("ScoreDetailId")
                        .HasColumnType("int");

                    b.Property<int>("ScoringProcessProcessId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("ScoreId");

                    b.HasIndex("AcademicYearId");

                    b.HasIndex("EvalutionFormId");

                    b.HasIndex("ScoreDetailId");

                    b.HasIndex("ScoringProcessProcessId");

                    b.HasIndex("StudentId");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.ScoreDetail", b =>
                {
                    b.Property<int>("ScoreDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScoreDetailId"), 1L, 1);

                    b.Property<DateTime>("ScoreDetailDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ScoreDetailEvalution")
                        .HasColumnType("int");

                    b.Property<int>("ScoreDetailValue")
                        .HasColumnType("int");

                    b.HasKey("ScoreDetailId");

                    b.ToTable("ScoreDetails");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.ScoringProcess", b =>
                {
                    b.Property<int>("ProcessId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProcessId"), 1L, 1);

                    b.Property<string>("ProcessName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ProcessId");

                    b.ToTable("ScoringProcesses");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"), 1L, 1);

                    b.Property<string>("CitizenIdentificationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateofIssueofCitizenIdentificationCard")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ethnicity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GradeId")
                        .HasColumnType("int");

                    b.Property<string>("Hometown")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsClassmittee")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Permanentaddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceOfBirth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Religion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("StudentId");

                    b.HasIndex("GradeId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.TrainingContent", b =>
                {
                    b.Property<int>("TrainingContentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrainingContentId"), 1L, 1);

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsProof")
                        .HasColumnType("bit");

                    b.Property<int>("MaxScore")
                        .HasColumnType("int");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("TrainingContentName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("TrainingDirectoryId")
                        .HasColumnType("int");

                    b.Property<string>("TypeofScore")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrainingContentId");

                    b.HasIndex("TrainingDirectoryId");

                    b.ToTable("TrainingContents");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.TrainingContentProof", b =>
                {
                    b.Property<int>("TrainingContentId")
                        .HasColumnType("int");

                    b.Property<int>("ProofId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("TrainingContentId", "ProofId");

                    b.HasIndex("ProofId")
                        .IsUnique();

                    b.ToTable("TrainingContentProofs");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.TrainingDetail", b =>
                {
                    b.Property<int>("TrainingDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrainingDetailId"), 1L, 1);

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsProof")
                        .HasColumnType("bit");

                    b.Property<int>("MaxScore")
                        .HasColumnType("int");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("TrainingContentId")
                        .HasColumnType("int");

                    b.Property<string>("TrainingDetailName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("TypeofScore")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrainingDetailId");

                    b.HasIndex("TrainingContentId");

                    b.ToTable("TrainingDetails");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.TrainingDetailProof", b =>
                {
                    b.Property<int>("TrainingDetailId")
                        .HasColumnType("int");

                    b.Property<int>("ProofId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("TrainingDetailId", "ProofId");

                    b.HasIndex("ProofId")
                        .IsUnique();

                    b.ToTable("TraniningDetailProofs");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.TrainingDirectory", b =>
                {
                    b.Property<int>("TrainingDirectoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrainingDirectoryId"), 1L, 1);

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("EvaluationFormId")
                        .HasColumnType("int");

                    b.Property<int>("MaxScore")
                        .HasColumnType("int");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("TrainingDirectoryName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("TrainingDirectoryId");

                    b.HasIndex("EvaluationFormId");

                    b.ToTable("TrainingDirectories");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.EvaluationForm", b =>
                {
                    b.HasOne("TrainingScoring.DomainModels.AcademicYear", "AcademicYear")
                        .WithMany("EvaluationForms")
                        .HasForeignKey("AcademicYearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AcademicYear");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.Grade", b =>
                {
                    b.HasOne("TrainingScoring.DomainModels.Course", "Course")
                        .WithMany("Grades")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainingScoring.DomainModels.Department", "Department")
                        .WithMany("Grades")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainingScoring.DomainModels.Major", "Major")
                        .WithMany("Grades")
                        .HasForeignKey("MajorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Department");

                    b.Navigation("Major");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.GradeLecturerAssignment", b =>
                {
                    b.HasOne("TrainingScoring.DomainModels.Grade", "Grade")
                        .WithMany("GradeLecturerAssignments")
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainingScoring.DomainModels.Lecturer", "Lecturer")
                        .WithMany("GradeLecturerAssignments")
                        .HasForeignKey("LecturerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Grade");

                    b.Navigation("Lecturer");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.Lecturer", b =>
                {
                    b.HasOne("TrainingScoring.DomainModels.Department", "Department")
                        .WithMany("Lecturers")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.LecturerRoleAssignment", b =>
                {
                    b.HasOne("TrainingScoring.DomainModels.Lecturer", "Lecturer")
                        .WithMany("LecturerRoleAssignments")
                        .HasForeignKey("LecturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainingScoring.DomainModels.Role", "Role")
                        .WithMany("LecturerRoleAssignments")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lecturer");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.Major", b =>
                {
                    b.HasOne("TrainingScoring.DomainModels.Department", null)
                        .WithMany("Majors")
                        .HasForeignKey("DepartmentId");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.ProcessDetail", b =>
                {
                    b.HasOne("TrainingScoring.DomainModels.ScoringProcess", "ScoringProcess")
                        .WithMany("ProcessDetail")
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainingScoring.DomainModels.Role", "Role")
                        .WithMany("ProcessDetail")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("ScoringProcess");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.Score", b =>
                {
                    b.HasOne("TrainingScoring.DomainModels.AcademicYear", "AcademicYear")
                        .WithMany("Scores")
                        .HasForeignKey("AcademicYearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainingScoring.DomainModels.EvaluationForm", "EvaluationForm")
                        .WithMany("Scores")
                        .HasForeignKey("EvalutionFormId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TrainingScoring.DomainModels.ScoreDetail", "ScoreDetail")
                        .WithMany("Scores")
                        .HasForeignKey("ScoreDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainingScoring.DomainModels.ScoringProcess", "ScoringProcess")
                        .WithMany("Scores")
                        .HasForeignKey("ScoringProcessProcessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainingScoring.DomainModels.Student", "Student")
                        .WithMany("Scores")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AcademicYear");

                    b.Navigation("EvaluationForm");

                    b.Navigation("ScoreDetail");

                    b.Navigation("ScoringProcess");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.Student", b =>
                {
                    b.HasOne("TrainingScoring.DomainModels.Grade", "Grade")
                        .WithMany("Students")
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grade");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.TrainingContent", b =>
                {
                    b.HasOne("TrainingScoring.DomainModels.TrainingDirectory", "TrainingDirectory")
                        .WithMany("TrainingContents")
                        .HasForeignKey("TrainingDirectoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TrainingDirectory");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.TrainingContentProof", b =>
                {
                    b.HasOne("TrainingScoring.DomainModels.Proof", "Proof")
                        .WithOne("TrainingContentProofs")
                        .HasForeignKey("TrainingScoring.DomainModels.TrainingContentProof", "ProofId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainingScoring.DomainModels.TrainingContent", "TrainingContent")
                        .WithMany("TrainingContentProofs")
                        .HasForeignKey("TrainingContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proof");

                    b.Navigation("TrainingContent");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.TrainingDetail", b =>
                {
                    b.HasOne("TrainingScoring.DomainModels.TrainingContent", "TrainingContent")
                        .WithMany("TrainingDetails")
                        .HasForeignKey("TrainingContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TrainingContent");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.TrainingDetailProof", b =>
                {
                    b.HasOne("TrainingScoring.DomainModels.Proof", "Proof")
                        .WithOne("TraniningDetailProofs")
                        .HasForeignKey("TrainingScoring.DomainModels.TrainingDetailProof", "ProofId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainingScoring.DomainModels.TrainingDetail", "TrainingDetail")
                        .WithMany("TraniningDetailProofs")
                        .HasForeignKey("TrainingDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proof");

                    b.Navigation("TrainingDetail");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.TrainingDirectory", b =>
                {
                    b.HasOne("TrainingScoring.DomainModels.EvaluationForm", "EvaluationForm")
                        .WithMany("TrainingDirectories")
                        .HasForeignKey("EvaluationFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EvaluationForm");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.AcademicYear", b =>
                {
                    b.Navigation("EvaluationForms");

                    b.Navigation("Scores");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.Course", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.Department", b =>
                {
                    b.Navigation("Grades");

                    b.Navigation("Lecturers");

                    b.Navigation("Majors");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.EvaluationForm", b =>
                {
                    b.Navigation("Scores");

                    b.Navigation("TrainingDirectories");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.Grade", b =>
                {
                    b.Navigation("GradeLecturerAssignments");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.Lecturer", b =>
                {
                    b.Navigation("GradeLecturerAssignments");

                    b.Navigation("LecturerRoleAssignments");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.Major", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.Proof", b =>
                {
                    b.Navigation("TrainingContentProofs")
                        .IsRequired();

                    b.Navigation("TraniningDetailProofs")
                        .IsRequired();
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.Role", b =>
                {
                    b.Navigation("LecturerRoleAssignments");

                    b.Navigation("ProcessDetail");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.ScoreDetail", b =>
                {
                    b.Navigation("Scores");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.ScoringProcess", b =>
                {
                    b.Navigation("ProcessDetail");

                    b.Navigation("Scores");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.Student", b =>
                {
                    b.Navigation("Scores");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.TrainingContent", b =>
                {
                    b.Navigation("TrainingContentProofs");

                    b.Navigation("TrainingDetails");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.TrainingDetail", b =>
                {
                    b.Navigation("TraniningDetailProofs");
                });

            modelBuilder.Entity("TrainingScoring.DomainModels.TrainingDirectory", b =>
                {
                    b.Navigation("TrainingContents");
                });
#pragma warning restore 612, 618
        }
    }
}
