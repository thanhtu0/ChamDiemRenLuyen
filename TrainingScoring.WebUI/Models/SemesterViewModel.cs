namespace TrainingScoring.WebUI.Models
{
    public class SemesterViewModel
    {
        public List<SemesterOption> Semesters { get; set; }
        public class SemesterOption
        {
            public string AcademicYear { get; set; }
            public int Semester { get; set; }
        }
    }
}
