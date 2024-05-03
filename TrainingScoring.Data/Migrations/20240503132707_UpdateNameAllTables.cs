using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingScoring.Data.Migrations
{
    public partial class UpdateNameAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advisor_Grade_GradeId",
                table: "Advisor");

            migrationBuilder.DropForeignKey(
                name: "FK_Advisor_Lecturer_LecturerId",
                table: "Advisor");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationForm_AcademicYear_AcademicYearId",
                table: "EvaluationForm");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationForm_Semester_SemesterId",
                table: "EvaluationForm");

            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Course_CourseId",
                table: "Grade");

            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Department_DepartmentId",
                table: "Grade");

            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Major_MajorId",
                table: "Grade");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecturer_Department_DepartmentId",
                table: "Lecturer");

            migrationBuilder.DropForeignKey(
                name: "FK_LecturerRoleAssignment_Lecturer_LecturerId",
                table: "LecturerRoleAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_LecturerRoleAssignment_Role_RoleId",
                table: "LecturerRoleAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Major_Department_DepartmentId",
                table: "Major");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessDetail_Role_RoleId",
                table: "ProcessDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessDetail_ScoringProcess_ProcessId",
                table: "ProcessDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Score_AcademicYear_AcademicYearId",
                table: "Score");

            migrationBuilder.DropForeignKey(
                name: "FK_Score_EvaluationForm_EvalutionFormId",
                table: "Score");

            migrationBuilder.DropForeignKey(
                name: "FK_Score_ScoreDetail_ScoreDetailId",
                table: "Score");

            migrationBuilder.DropForeignKey(
                name: "FK_Score_ScoringProcess_ScoringProcessProcessId",
                table: "Score");

            migrationBuilder.DropForeignKey(
                name: "FK_Score_Semester_SemesterId",
                table: "Score");

            migrationBuilder.DropForeignKey(
                name: "FK_Score_Student_StudentId",
                table: "Score");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Grade_GradeId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentClassCommittee_ClassCommittee_ClassCommitteeId",
                table: "StudentClassCommittee");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentClassCommittee_Student_StudentId",
                table: "StudentClassCommittee");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingContent_TrainingDirectory_TrainingDirectoryId",
                table: "TrainingContent");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingContentProof_Proof_ProofId",
                table: "TrainingContentProof");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingContentProof_TrainingContent_TrainingContentId",
                table: "TrainingContentProof");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingDetail_TrainingContent_TrainingContentId",
                table: "TrainingDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingDirectory_EvaluationForm_EvaluationFormId",
                table: "TrainingDirectory");

            migrationBuilder.DropForeignKey(
                name: "FK_TraniningDetailProof_Proof_ProofId",
                table: "TraniningDetailProof");

            migrationBuilder.DropForeignKey(
                name: "FK_TraniningDetailProof_TrainingDetail_TrainingDetailId",
                table: "TraniningDetailProof");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TraniningDetailProof",
                table: "TraniningDetailProof");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingDirectory",
                table: "TrainingDirectory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingDetail",
                table: "TrainingDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingContentProof",
                table: "TrainingContentProof");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingContent",
                table: "TrainingContent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentClassCommittee",
                table: "StudentClassCommittee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Semester",
                table: "Semester");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScoringProcess",
                table: "ScoringProcess");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScoreDetail",
                table: "ScoreDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Score",
                table: "Score");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proof",
                table: "Proof");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcessDetail",
                table: "ProcessDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Major",
                table: "Major");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LecturerRoleAssignment",
                table: "LecturerRoleAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lecturer",
                table: "Lecturer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grade",
                table: "Grade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EvaluationForm",
                table: "EvaluationForm");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassCommittee",
                table: "ClassCommittee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Advisor",
                table: "Advisor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AcademicYear",
                table: "AcademicYear");

            migrationBuilder.RenameTable(
                name: "TraniningDetailProof",
                newName: "TraniningDetailProofs");

            migrationBuilder.RenameTable(
                name: "TrainingDirectory",
                newName: "TrainingDirectories");

            migrationBuilder.RenameTable(
                name: "TrainingDetail",
                newName: "TrainingDetails");

            migrationBuilder.RenameTable(
                name: "TrainingContentProof",
                newName: "TrainingContentProofs");

            migrationBuilder.RenameTable(
                name: "TrainingContent",
                newName: "TrainingContents");

            migrationBuilder.RenameTable(
                name: "StudentClassCommittee",
                newName: "StudentClassCommittees");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "Semester",
                newName: "Semesters");

            migrationBuilder.RenameTable(
                name: "ScoringProcess",
                newName: "ScoringProcesses");

            migrationBuilder.RenameTable(
                name: "ScoreDetail",
                newName: "ScoreDetails");

            migrationBuilder.RenameTable(
                name: "Score",
                newName: "Scores");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "Proof",
                newName: "Proofs");

            migrationBuilder.RenameTable(
                name: "ProcessDetail",
                newName: "ProcessDetails");

            migrationBuilder.RenameTable(
                name: "Major",
                newName: "Majors");

            migrationBuilder.RenameTable(
                name: "LecturerRoleAssignment",
                newName: "LecturerRoleAssignments");

            migrationBuilder.RenameTable(
                name: "Lecturer",
                newName: "Lecturers");

            migrationBuilder.RenameTable(
                name: "Grade",
                newName: "Grades");

            migrationBuilder.RenameTable(
                name: "EvaluationForm",
                newName: "EvaluationForms");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Departments");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameTable(
                name: "ClassCommittee",
                newName: "ClassCommittees");

            migrationBuilder.RenameTable(
                name: "Advisor",
                newName: "Advisors");

            migrationBuilder.RenameTable(
                name: "AcademicYear",
                newName: "AcademicYears");

            migrationBuilder.RenameIndex(
                name: "IX_TraniningDetailProof_ProofId",
                table: "TraniningDetailProofs",
                newName: "IX_TraniningDetailProofs_ProofId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingDirectory_EvaluationFormId",
                table: "TrainingDirectories",
                newName: "IX_TrainingDirectories_EvaluationFormId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingDetail_TrainingContentId",
                table: "TrainingDetails",
                newName: "IX_TrainingDetails_TrainingContentId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingContentProof_ProofId",
                table: "TrainingContentProofs",
                newName: "IX_TrainingContentProofs_ProofId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingContent_TrainingDirectoryId",
                table: "TrainingContents",
                newName: "IX_TrainingContents_TrainingDirectoryId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentClassCommittee_ClassCommitteeId",
                table: "StudentClassCommittees",
                newName: "IX_StudentClassCommittees_ClassCommitteeId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_GradeId",
                table: "Students",
                newName: "IX_Students_GradeId");

            migrationBuilder.RenameIndex(
                name: "IX_Score_StudentId",
                table: "Scores",
                newName: "IX_Scores_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Score_SemesterId",
                table: "Scores",
                newName: "IX_Scores_SemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_Score_ScoringProcessProcessId",
                table: "Scores",
                newName: "IX_Scores_ScoringProcessProcessId");

            migrationBuilder.RenameIndex(
                name: "IX_Score_ScoreDetailId",
                table: "Scores",
                newName: "IX_Scores_ScoreDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_Score_EvalutionFormId",
                table: "Scores",
                newName: "IX_Scores_EvalutionFormId");

            migrationBuilder.RenameIndex(
                name: "IX_Score_AcademicYearId",
                table: "Scores",
                newName: "IX_Scores_AcademicYearId");

            migrationBuilder.RenameIndex(
                name: "IX_ProcessDetail_RoleId",
                table: "ProcessDetails",
                newName: "IX_ProcessDetails_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_ProcessDetail_ProcessId",
                table: "ProcessDetails",
                newName: "IX_ProcessDetails_ProcessId");

            migrationBuilder.RenameIndex(
                name: "IX_Major_DepartmentId",
                table: "Majors",
                newName: "IX_Majors_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_LecturerRoleAssignment_RoleId",
                table: "LecturerRoleAssignments",
                newName: "IX_LecturerRoleAssignments_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Lecturer_DepartmentId",
                table: "Lecturers",
                newName: "IX_Lecturers_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Grade_MajorId",
                table: "Grades",
                newName: "IX_Grades_MajorId");

            migrationBuilder.RenameIndex(
                name: "IX_Grade_DepartmentId",
                table: "Grades",
                newName: "IX_Grades_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Grade_CourseId",
                table: "Grades",
                newName: "IX_Grades_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_EvaluationForm_SemesterId",
                table: "EvaluationForms",
                newName: "IX_EvaluationForms_SemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_EvaluationForm_AcademicYearId",
                table: "EvaluationForms",
                newName: "IX_EvaluationForms_AcademicYearId");

            migrationBuilder.RenameIndex(
                name: "IX_Advisor_GradeId",
                table: "Advisors",
                newName: "IX_Advisors_GradeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TraniningDetailProofs",
                table: "TraniningDetailProofs",
                columns: new[] { "TrainingDetailId", "ProofId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingDirectories",
                table: "TrainingDirectories",
                column: "TrainingDirectoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingDetails",
                table: "TrainingDetails",
                column: "TrainingDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingContentProofs",
                table: "TrainingContentProofs",
                columns: new[] { "TrainingContentId", "ProofId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingContents",
                table: "TrainingContents",
                column: "TrainingContentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentClassCommittees",
                table: "StudentClassCommittees",
                columns: new[] { "StudentId", "ClassCommitteeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Semesters",
                table: "Semesters",
                column: "SemesterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScoringProcesses",
                table: "ScoringProcesses",
                column: "ProcessId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScoreDetails",
                table: "ScoreDetails",
                column: "ScoreDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scores",
                table: "Scores",
                column: "ScoreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proofs",
                table: "Proofs",
                column: "ProofId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcessDetails",
                table: "ProcessDetails",
                column: "DetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Majors",
                table: "Majors",
                column: "MajorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LecturerRoleAssignments",
                table: "LecturerRoleAssignments",
                columns: new[] { "LecturerId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lecturers",
                table: "Lecturers",
                column: "LecturerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grades",
                table: "Grades",
                column: "GradeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EvaluationForms",
                table: "EvaluationForms",
                column: "EvalutionFormId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassCommittees",
                table: "ClassCommittees",
                column: "ClassCommitteeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Advisors",
                table: "Advisors",
                columns: new[] { "LecturerId", "GradeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AcademicYears",
                table: "AcademicYears",
                column: "AcademicYearId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advisors_Grades_GradeId",
                table: "Advisors",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "GradeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Advisors_Lecturers_LecturerId",
                table: "Advisors",
                column: "LecturerId",
                principalTable: "Lecturers",
                principalColumn: "LecturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationForms_AcademicYears_AcademicYearId",
                table: "EvaluationForms",
                column: "AcademicYearId",
                principalTable: "AcademicYears",
                principalColumn: "AcademicYearId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationForms_Semesters_SemesterId",
                table: "EvaluationForms",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "SemesterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Courses_CourseId",
                table: "Grades",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Departments_DepartmentId",
                table: "Grades",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Majors_MajorId",
                table: "Grades",
                column: "MajorId",
                principalTable: "Majors",
                principalColumn: "MajorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LecturerRoleAssignments_Lecturers_LecturerId",
                table: "LecturerRoleAssignments",
                column: "LecturerId",
                principalTable: "Lecturers",
                principalColumn: "LecturerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LecturerRoleAssignments_Roles_RoleId",
                table: "LecturerRoleAssignments",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturers_Departments_DepartmentId",
                table: "Lecturers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Majors_Departments_DepartmentId",
                table: "Majors",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessDetails_Roles_RoleId",
                table: "ProcessDetails",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessDetails_ScoringProcesses_ProcessId",
                table: "ProcessDetails",
                column: "ProcessId",
                principalTable: "ScoringProcesses",
                principalColumn: "ProcessId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_AcademicYears_AcademicYearId",
                table: "Scores",
                column: "AcademicYearId",
                principalTable: "AcademicYears",
                principalColumn: "AcademicYearId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_EvaluationForms_EvalutionFormId",
                table: "Scores",
                column: "EvalutionFormId",
                principalTable: "EvaluationForms",
                principalColumn: "EvalutionFormId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_ScoreDetails_ScoreDetailId",
                table: "Scores",
                column: "ScoreDetailId",
                principalTable: "ScoreDetails",
                principalColumn: "ScoreDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_ScoringProcesses_ScoringProcessProcessId",
                table: "Scores",
                column: "ScoringProcessProcessId",
                principalTable: "ScoringProcesses",
                principalColumn: "ProcessId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Semesters_SemesterId",
                table: "Scores",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "SemesterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Students_StudentId",
                table: "Scores",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClassCommittees_ClassCommittees_ClassCommitteeId",
                table: "StudentClassCommittees",
                column: "ClassCommitteeId",
                principalTable: "ClassCommittees",
                principalColumn: "ClassCommitteeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClassCommittees_Students_StudentId",
                table: "StudentClassCommittees",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Grades_GradeId",
                table: "Students",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "GradeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingContentProofs_Proofs_ProofId",
                table: "TrainingContentProofs",
                column: "ProofId",
                principalTable: "Proofs",
                principalColumn: "ProofId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingContentProofs_TrainingContents_TrainingContentId",
                table: "TrainingContentProofs",
                column: "TrainingContentId",
                principalTable: "TrainingContents",
                principalColumn: "TrainingContentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingContents_TrainingDirectories_TrainingDirectoryId",
                table: "TrainingContents",
                column: "TrainingDirectoryId",
                principalTable: "TrainingDirectories",
                principalColumn: "TrainingDirectoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingDetails_TrainingContents_TrainingContentId",
                table: "TrainingDetails",
                column: "TrainingContentId",
                principalTable: "TrainingContents",
                principalColumn: "TrainingContentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingDirectories_EvaluationForms_EvaluationFormId",
                table: "TrainingDirectories",
                column: "EvaluationFormId",
                principalTable: "EvaluationForms",
                principalColumn: "EvalutionFormId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TraniningDetailProofs_Proofs_ProofId",
                table: "TraniningDetailProofs",
                column: "ProofId",
                principalTable: "Proofs",
                principalColumn: "ProofId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TraniningDetailProofs_TrainingDetails_TrainingDetailId",
                table: "TraniningDetailProofs",
                column: "TrainingDetailId",
                principalTable: "TrainingDetails",
                principalColumn: "TrainingDetailId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advisors_Grades_GradeId",
                table: "Advisors");

            migrationBuilder.DropForeignKey(
                name: "FK_Advisors_Lecturers_LecturerId",
                table: "Advisors");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationForms_AcademicYears_AcademicYearId",
                table: "EvaluationForms");

            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationForms_Semesters_SemesterId",
                table: "EvaluationForms");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Courses_CourseId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Departments_DepartmentId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Majors_MajorId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_LecturerRoleAssignments_Lecturers_LecturerId",
                table: "LecturerRoleAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_LecturerRoleAssignments_Roles_RoleId",
                table: "LecturerRoleAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecturers_Departments_DepartmentId",
                table: "Lecturers");

            migrationBuilder.DropForeignKey(
                name: "FK_Majors_Departments_DepartmentId",
                table: "Majors");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessDetails_Roles_RoleId",
                table: "ProcessDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessDetails_ScoringProcesses_ProcessId",
                table: "ProcessDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_AcademicYears_AcademicYearId",
                table: "Scores");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_EvaluationForms_EvalutionFormId",
                table: "Scores");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_ScoreDetails_ScoreDetailId",
                table: "Scores");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_ScoringProcesses_ScoringProcessProcessId",
                table: "Scores");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Semesters_SemesterId",
                table: "Scores");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Students_StudentId",
                table: "Scores");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentClassCommittees_ClassCommittees_ClassCommitteeId",
                table: "StudentClassCommittees");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentClassCommittees_Students_StudentId",
                table: "StudentClassCommittees");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Grades_GradeId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingContentProofs_Proofs_ProofId",
                table: "TrainingContentProofs");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingContentProofs_TrainingContents_TrainingContentId",
                table: "TrainingContentProofs");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingContents_TrainingDirectories_TrainingDirectoryId",
                table: "TrainingContents");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingDetails_TrainingContents_TrainingContentId",
                table: "TrainingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingDirectories_EvaluationForms_EvaluationFormId",
                table: "TrainingDirectories");

            migrationBuilder.DropForeignKey(
                name: "FK_TraniningDetailProofs_Proofs_ProofId",
                table: "TraniningDetailProofs");

            migrationBuilder.DropForeignKey(
                name: "FK_TraniningDetailProofs_TrainingDetails_TrainingDetailId",
                table: "TraniningDetailProofs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TraniningDetailProofs",
                table: "TraniningDetailProofs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingDirectories",
                table: "TrainingDirectories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingDetails",
                table: "TrainingDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingContents",
                table: "TrainingContents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingContentProofs",
                table: "TrainingContentProofs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentClassCommittees",
                table: "StudentClassCommittees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Semesters",
                table: "Semesters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScoringProcesses",
                table: "ScoringProcesses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scores",
                table: "Scores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScoreDetails",
                table: "ScoreDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proofs",
                table: "Proofs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcessDetails",
                table: "ProcessDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Majors",
                table: "Majors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lecturers",
                table: "Lecturers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LecturerRoleAssignments",
                table: "LecturerRoleAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grades",
                table: "Grades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EvaluationForms",
                table: "EvaluationForms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassCommittees",
                table: "ClassCommittees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Advisors",
                table: "Advisors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AcademicYears",
                table: "AcademicYears");

            migrationBuilder.RenameTable(
                name: "TraniningDetailProofs",
                newName: "TraniningDetailProof");

            migrationBuilder.RenameTable(
                name: "TrainingDirectories",
                newName: "TrainingDirectory");

            migrationBuilder.RenameTable(
                name: "TrainingDetails",
                newName: "TrainingDetail");

            migrationBuilder.RenameTable(
                name: "TrainingContents",
                newName: "TrainingContent");

            migrationBuilder.RenameTable(
                name: "TrainingContentProofs",
                newName: "TrainingContentProof");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student");

            migrationBuilder.RenameTable(
                name: "StudentClassCommittees",
                newName: "StudentClassCommittee");

            migrationBuilder.RenameTable(
                name: "Semesters",
                newName: "Semester");

            migrationBuilder.RenameTable(
                name: "ScoringProcesses",
                newName: "ScoringProcess");

            migrationBuilder.RenameTable(
                name: "Scores",
                newName: "Score");

            migrationBuilder.RenameTable(
                name: "ScoreDetails",
                newName: "ScoreDetail");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "Proofs",
                newName: "Proof");

            migrationBuilder.RenameTable(
                name: "ProcessDetails",
                newName: "ProcessDetail");

            migrationBuilder.RenameTable(
                name: "Majors",
                newName: "Major");

            migrationBuilder.RenameTable(
                name: "Lecturers",
                newName: "Lecturer");

            migrationBuilder.RenameTable(
                name: "LecturerRoleAssignments",
                newName: "LecturerRoleAssignment");

            migrationBuilder.RenameTable(
                name: "Grades",
                newName: "Grade");

            migrationBuilder.RenameTable(
                name: "EvaluationForms",
                newName: "EvaluationForm");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Department");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameTable(
                name: "ClassCommittees",
                newName: "ClassCommittee");

            migrationBuilder.RenameTable(
                name: "Advisors",
                newName: "Advisor");

            migrationBuilder.RenameTable(
                name: "AcademicYears",
                newName: "AcademicYear");

            migrationBuilder.RenameIndex(
                name: "IX_TraniningDetailProofs_ProofId",
                table: "TraniningDetailProof",
                newName: "IX_TraniningDetailProof_ProofId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingDirectories_EvaluationFormId",
                table: "TrainingDirectory",
                newName: "IX_TrainingDirectory_EvaluationFormId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingDetails_TrainingContentId",
                table: "TrainingDetail",
                newName: "IX_TrainingDetail_TrainingContentId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingContents_TrainingDirectoryId",
                table: "TrainingContent",
                newName: "IX_TrainingContent_TrainingDirectoryId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingContentProofs_ProofId",
                table: "TrainingContentProof",
                newName: "IX_TrainingContentProof_ProofId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_GradeId",
                table: "Student",
                newName: "IX_Student_GradeId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentClassCommittees_ClassCommitteeId",
                table: "StudentClassCommittee",
                newName: "IX_StudentClassCommittee_ClassCommitteeId");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_StudentId",
                table: "Score",
                newName: "IX_Score_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_SemesterId",
                table: "Score",
                newName: "IX_Score_SemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_ScoringProcessProcessId",
                table: "Score",
                newName: "IX_Score_ScoringProcessProcessId");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_ScoreDetailId",
                table: "Score",
                newName: "IX_Score_ScoreDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_EvalutionFormId",
                table: "Score",
                newName: "IX_Score_EvalutionFormId");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_AcademicYearId",
                table: "Score",
                newName: "IX_Score_AcademicYearId");

            migrationBuilder.RenameIndex(
                name: "IX_ProcessDetails_RoleId",
                table: "ProcessDetail",
                newName: "IX_ProcessDetail_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_ProcessDetails_ProcessId",
                table: "ProcessDetail",
                newName: "IX_ProcessDetail_ProcessId");

            migrationBuilder.RenameIndex(
                name: "IX_Majors_DepartmentId",
                table: "Major",
                newName: "IX_Major_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Lecturers_DepartmentId",
                table: "Lecturer",
                newName: "IX_Lecturer_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_LecturerRoleAssignments_RoleId",
                table: "LecturerRoleAssignment",
                newName: "IX_LecturerRoleAssignment_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_MajorId",
                table: "Grade",
                newName: "IX_Grade_MajorId");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_DepartmentId",
                table: "Grade",
                newName: "IX_Grade_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_CourseId",
                table: "Grade",
                newName: "IX_Grade_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_EvaluationForms_SemesterId",
                table: "EvaluationForm",
                newName: "IX_EvaluationForm_SemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_EvaluationForms_AcademicYearId",
                table: "EvaluationForm",
                newName: "IX_EvaluationForm_AcademicYearId");

            migrationBuilder.RenameIndex(
                name: "IX_Advisors_GradeId",
                table: "Advisor",
                newName: "IX_Advisor_GradeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TraniningDetailProof",
                table: "TraniningDetailProof",
                columns: new[] { "TrainingDetailId", "ProofId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingDirectory",
                table: "TrainingDirectory",
                column: "TrainingDirectoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingDetail",
                table: "TrainingDetail",
                column: "TrainingDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingContent",
                table: "TrainingContent",
                column: "TrainingContentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingContentProof",
                table: "TrainingContentProof",
                columns: new[] { "TrainingContentId", "ProofId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentClassCommittee",
                table: "StudentClassCommittee",
                columns: new[] { "StudentId", "ClassCommitteeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Semester",
                table: "Semester",
                column: "SemesterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScoringProcess",
                table: "ScoringProcess",
                column: "ProcessId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Score",
                table: "Score",
                column: "ScoreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScoreDetail",
                table: "ScoreDetail",
                column: "ScoreDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proof",
                table: "Proof",
                column: "ProofId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcessDetail",
                table: "ProcessDetail",
                column: "DetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Major",
                table: "Major",
                column: "MajorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lecturer",
                table: "Lecturer",
                column: "LecturerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LecturerRoleAssignment",
                table: "LecturerRoleAssignment",
                columns: new[] { "LecturerId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grade",
                table: "Grade",
                column: "GradeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EvaluationForm",
                table: "EvaluationForm",
                column: "EvalutionFormId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassCommittee",
                table: "ClassCommittee",
                column: "ClassCommitteeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Advisor",
                table: "Advisor",
                columns: new[] { "LecturerId", "GradeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AcademicYear",
                table: "AcademicYear",
                column: "AcademicYearId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advisor_Grade_GradeId",
                table: "Advisor",
                column: "GradeId",
                principalTable: "Grade",
                principalColumn: "GradeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Advisor_Lecturer_LecturerId",
                table: "Advisor",
                column: "LecturerId",
                principalTable: "Lecturer",
                principalColumn: "LecturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationForm_AcademicYear_AcademicYearId",
                table: "EvaluationForm",
                column: "AcademicYearId",
                principalTable: "AcademicYear",
                principalColumn: "AcademicYearId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationForm_Semester_SemesterId",
                table: "EvaluationForm",
                column: "SemesterId",
                principalTable: "Semester",
                principalColumn: "SemesterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Course_CourseId",
                table: "Grade",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Department_DepartmentId",
                table: "Grade",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Major_MajorId",
                table: "Grade",
                column: "MajorId",
                principalTable: "Major",
                principalColumn: "MajorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturer_Department_DepartmentId",
                table: "Lecturer",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LecturerRoleAssignment_Lecturer_LecturerId",
                table: "LecturerRoleAssignment",
                column: "LecturerId",
                principalTable: "Lecturer",
                principalColumn: "LecturerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LecturerRoleAssignment_Role_RoleId",
                table: "LecturerRoleAssignment",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Major_Department_DepartmentId",
                table: "Major",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessDetail_Role_RoleId",
                table: "ProcessDetail",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessDetail_ScoringProcess_ProcessId",
                table: "ProcessDetail",
                column: "ProcessId",
                principalTable: "ScoringProcess",
                principalColumn: "ProcessId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Score_AcademicYear_AcademicYearId",
                table: "Score",
                column: "AcademicYearId",
                principalTable: "AcademicYear",
                principalColumn: "AcademicYearId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Score_EvaluationForm_EvalutionFormId",
                table: "Score",
                column: "EvalutionFormId",
                principalTable: "EvaluationForm",
                principalColumn: "EvalutionFormId");

            migrationBuilder.AddForeignKey(
                name: "FK_Score_ScoreDetail_ScoreDetailId",
                table: "Score",
                column: "ScoreDetailId",
                principalTable: "ScoreDetail",
                principalColumn: "ScoreDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Score_ScoringProcess_ScoringProcessProcessId",
                table: "Score",
                column: "ScoringProcessProcessId",
                principalTable: "ScoringProcess",
                principalColumn: "ProcessId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Score_Semester_SemesterId",
                table: "Score",
                column: "SemesterId",
                principalTable: "Semester",
                principalColumn: "SemesterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Score_Student_StudentId",
                table: "Score",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Grade_GradeId",
                table: "Student",
                column: "GradeId",
                principalTable: "Grade",
                principalColumn: "GradeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClassCommittee_ClassCommittee_ClassCommitteeId",
                table: "StudentClassCommittee",
                column: "ClassCommitteeId",
                principalTable: "ClassCommittee",
                principalColumn: "ClassCommitteeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClassCommittee_Student_StudentId",
                table: "StudentClassCommittee",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingContent_TrainingDirectory_TrainingDirectoryId",
                table: "TrainingContent",
                column: "TrainingDirectoryId",
                principalTable: "TrainingDirectory",
                principalColumn: "TrainingDirectoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingContentProof_Proof_ProofId",
                table: "TrainingContentProof",
                column: "ProofId",
                principalTable: "Proof",
                principalColumn: "ProofId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingContentProof_TrainingContent_TrainingContentId",
                table: "TrainingContentProof",
                column: "TrainingContentId",
                principalTable: "TrainingContent",
                principalColumn: "TrainingContentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingDetail_TrainingContent_TrainingContentId",
                table: "TrainingDetail",
                column: "TrainingContentId",
                principalTable: "TrainingContent",
                principalColumn: "TrainingContentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingDirectory_EvaluationForm_EvaluationFormId",
                table: "TrainingDirectory",
                column: "EvaluationFormId",
                principalTable: "EvaluationForm",
                principalColumn: "EvalutionFormId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TraniningDetailProof_Proof_ProofId",
                table: "TraniningDetailProof",
                column: "ProofId",
                principalTable: "Proof",
                principalColumn: "ProofId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TraniningDetailProof_TrainingDetail_TrainingDetailId",
                table: "TraniningDetailProof",
                column: "TrainingDetailId",
                principalTable: "TrainingDetail",
                principalColumn: "TrainingDetailId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
