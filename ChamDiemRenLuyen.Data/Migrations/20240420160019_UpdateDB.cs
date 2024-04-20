using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChamDiemRenLuyen.Data.Migrations
{
    public partial class UpdateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicYear",
                columns: table => new
                {
                    AcademicYearId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademicYearName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicYear", x => x.AcademicYearId);
                });

            migrationBuilder.CreateTable(
                name: "ClassCommittee",
                columns: table => new
                {
                    ClassCommitteeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassCommitteeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassCommittee", x => x.ClassCommitteeId);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndYear = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "ProcessDetail",
                columns: table => new
                {
                    DetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessDetail", x => x.DetailId);
                });

            migrationBuilder.CreateTable(
                name: "Proof",
                columns: table => new
                {
                    ProofId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSizeByte = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proof", x => x.ProofId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Score",
                columns: table => new
                {
                    ScoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScoreValue = table.Column<int>(type: "int", nullable: false),
                    ScoreDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Score", x => x.ScoreId);
                });

            migrationBuilder.CreateTable(
                name: "ScoringProcess",
                columns: table => new
                {
                    ProcessId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoringProcess", x => x.ProcessId);
                });

            migrationBuilder.CreateTable(
                name: "Semester",
                columns: table => new
                {
                    SemesterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SemesterName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semester", x => x.SemesterId);
                });

            migrationBuilder.CreateTable(
                name: "StudentScore",
                columns: table => new
                {
                    StudentScoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentScore", x => x.StudentScoreId);
                });

            migrationBuilder.CreateTable(
                name: "Lecturer",
                columns: table => new
                {
                    LecturerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturer", x => x.LecturerId);
                    table.ForeignKey(
                        name: "FK_Lecturer_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Major",
                columns: table => new
                {
                    MajorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MajorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Major", x => x.MajorId);
                    table.ForeignKey(
                        name: "FK_Major_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId");
                });

            migrationBuilder.CreateTable(
                name: "EvaluationForm",
                columns: table => new
                {
                    EvalutionFormId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvaluationFormName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateStarted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFinished = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AcademicYearId = table.Column<int>(type: "int", nullable: false),
                    SemesterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationForm", x => x.EvalutionFormId);
                    table.ForeignKey(
                        name: "FK_EvaluationForm_AcademicYear_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalTable: "AcademicYear",
                        principalColumn: "AcademicYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvaluationForm_Semester_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semester",
                        principalColumn: "SemesterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LecturerRoleAssignment",
                columns: table => new
                {
                    LecturerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerRoleAssignment", x => new { x.LecturerId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_LecturerRoleAssignment_Lecturer_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturer",
                        principalColumn: "LecturerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LecturerRoleAssignment_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    GradeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumberOfPupils = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    MajorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.GradeId);
                    table.ForeignKey(
                        name: "FK_Grade_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grade_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grade_Major_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Major",
                        principalColumn: "MajorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingDirectory",
                columns: table => new
                {
                    TrainingDirectoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingDirectoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaxScore = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EvaluationFormId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingDirectory", x => x.TrainingDirectoryId);
                    table.ForeignKey(
                        name: "FK_TrainingDirectory_EvaluationForm_EvaluationFormId",
                        column: x => x.EvaluationFormId,
                        principalTable: "EvaluationForm",
                        principalColumn: "EvalutionFormId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Advisor",
                columns: table => new
                {
                    LecturerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GradeId = table.Column<int>(type: "int", nullable: false),
                    StartYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndYear = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advisor", x => new { x.LecturerId, x.GradeId });
                    table.ForeignKey(
                        name: "FK_Advisor_Grade_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grade",
                        principalColumn: "GradeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Advisor_Lecturer_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturer",
                        principalColumn: "LecturerId");
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Student_Grade_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grade",
                        principalColumn: "GradeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingContent",
                columns: table => new
                {
                    TrainingContentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingContentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsProof = table.Column<bool>(type: "bit", nullable: false),
                    MaxScore = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingDirectoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingContent", x => x.TrainingContentId);
                    table.ForeignKey(
                        name: "FK_TrainingContent_TrainingDirectory_TrainingDirectoryId",
                        column: x => x.TrainingDirectoryId,
                        principalTable: "TrainingDirectory",
                        principalColumn: "TrainingDirectoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentClassCommittee",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClassCommitteeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClassCommittee", x => new { x.StudentId, x.ClassCommitteeId });
                    table.ForeignKey(
                        name: "FK_StudentClassCommittee_ClassCommittee_ClassCommitteeId",
                        column: x => x.ClassCommitteeId,
                        principalTable: "ClassCommittee",
                        principalColumn: "ClassCommitteeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentClassCommittee_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingContentProof",
                columns: table => new
                {
                    TrainingContentId = table.Column<int>(type: "int", nullable: false),
                    ProofId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingContentProof", x => new { x.TrainingContentId, x.ProofId });
                    table.ForeignKey(
                        name: "FK_TrainingContentProof_Proof_ProofId",
                        column: x => x.ProofId,
                        principalTable: "Proof",
                        principalColumn: "ProofId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingContentProof_TrainingContent_TrainingContentId",
                        column: x => x.TrainingContentId,
                        principalTable: "TrainingContent",
                        principalColumn: "TrainingContentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingDetail",
                columns: table => new
                {
                    TrainingDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingDetailName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsProof = table.Column<bool>(type: "bit", nullable: false),
                    MaxScore = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingContentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingDetail", x => x.TrainingDetailId);
                    table.ForeignKey(
                        name: "FK_TrainingDetail_TrainingContent_TrainingContentId",
                        column: x => x.TrainingContentId,
                        principalTable: "TrainingContent",
                        principalColumn: "TrainingContentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TraniningDetailProof",
                columns: table => new
                {
                    TrainingDetailId = table.Column<int>(type: "int", nullable: false),
                    ProofId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraniningDetailProof", x => new { x.TrainingDetailId, x.ProofId });
                    table.ForeignKey(
                        name: "FK_TraniningDetailProof_Proof_ProofId",
                        column: x => x.ProofId,
                        principalTable: "Proof",
                        principalColumn: "ProofId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TraniningDetailProof_TrainingDetail_TrainingDetailId",
                        column: x => x.TrainingDetailId,
                        principalTable: "TrainingDetail",
                        principalColumn: "TrainingDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advisor_GradeId",
                table: "Advisor",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationForm_AcademicYearId",
                table: "EvaluationForm",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationForm_SemesterId",
                table: "EvaluationForm",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_CourseId",
                table: "Grade",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_DepartmentId",
                table: "Grade",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_MajorId",
                table: "Grade",
                column: "MajorId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecturer_DepartmentId",
                table: "Lecturer",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerRoleAssignment_RoleId",
                table: "LecturerRoleAssignment",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Major_DepartmentId",
                table: "Major",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_GradeId",
                table: "Student",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClassCommittee_ClassCommitteeId",
                table: "StudentClassCommittee",
                column: "ClassCommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingContent_TrainingDirectoryId",
                table: "TrainingContent",
                column: "TrainingDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingContentProof_ProofId",
                table: "TrainingContentProof",
                column: "ProofId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingDetail_TrainingContentId",
                table: "TrainingDetail",
                column: "TrainingContentId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingDirectory_EvaluationFormId",
                table: "TrainingDirectory",
                column: "EvaluationFormId");

            migrationBuilder.CreateIndex(
                name: "IX_TraniningDetailProof_ProofId",
                table: "TraniningDetailProof",
                column: "ProofId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advisor");

            migrationBuilder.DropTable(
                name: "LecturerRoleAssignment");

            migrationBuilder.DropTable(
                name: "ProcessDetail");

            migrationBuilder.DropTable(
                name: "Score");

            migrationBuilder.DropTable(
                name: "ScoringProcess");

            migrationBuilder.DropTable(
                name: "StudentClassCommittee");

            migrationBuilder.DropTable(
                name: "StudentScore");

            migrationBuilder.DropTable(
                name: "TrainingContentProof");

            migrationBuilder.DropTable(
                name: "TraniningDetailProof");

            migrationBuilder.DropTable(
                name: "Lecturer");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "ClassCommittee");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Proof");

            migrationBuilder.DropTable(
                name: "TrainingDetail");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "TrainingContent");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Major");

            migrationBuilder.DropTable(
                name: "TrainingDirectory");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "EvaluationForm");

            migrationBuilder.DropTable(
                name: "AcademicYear");

            migrationBuilder.DropTable(
                name: "Semester");
        }
    }
}
