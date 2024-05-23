namespace TrainingScoring.WebUI.Models
{
    public class SemesterSelectionViewModel
    {
        public int SelectedAcademicYearId { get; set; }
        public List<AcademicYearViewModel> AcademicYears { get; set; }

        public class AcademicYearViewModel
        {
            public int AcademicYearId { get; set; }
            public string Semester { get; set; }
            public string AcademicYearName { get; set; }
            public string Course { get; set; }
            public string Major { get; set; }
            public string Grade { get; set; }
            public string SemesterCode { get; set; }
        }
    }
}
