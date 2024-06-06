using System.ComponentModel;
using TrainingScoring.DomainModels;

namespace TrainingScoring.WebUI.Models
{
    public class StudentFormViewModel
    {
        public int EvaluationFormId { get; set; }
        public int AcademicYearId { get; set; }
        public string EvaluationFormCode { get; set; }
        public string EvaluationFormName { get; set; }
        public AcademicYear AcademicYears { get; set; }
        public IEnumerable<TrainingDirectory> TrainingDirectories { get; set; }
        public IEnumerable<TrainingContent> TrainingContents { get; set; }
        public IEnumerable<TrainingDetail> TrainingDetails { get; set; }
        public List<StudentScoreContent> StudentScoreContents { get; set; }
        public List<StudentScoreDetail> StudentScoreDetails { get; set; }
        public IEnumerable<Score> Scores { get; set; }
    }
}
