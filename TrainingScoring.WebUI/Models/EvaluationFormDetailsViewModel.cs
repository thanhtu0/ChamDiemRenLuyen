using System.ComponentModel;
using TrainingScoring.DomainModels;
using System.ComponentModel.DataAnnotations;

namespace TrainingScoring.WebUI.Models
{
    public class EvaluationFormDetailsViewModel
    {
        public int EvaluationFormId { get; set; }
        [DisplayName("Mã phiếu rèn luyện")]
        [Required(ErrorMessage = "{0} bắt buộc phải có")]
        public string EvaluationFormCode { get; set; }
        [DisplayName("Tên phiếu rèn luyện")]
        [Required(ErrorMessage = "{0} bắt buộc phải có")]
        public string EvaluationFormName { get; set; }
        public int AcademicYearId { get; set; }
        public List<AcademicYear> AcademicYears { get; set; }
        public IEnumerable<TrainingDirectory> TrainingDirectories { get; set; }
        public IEnumerable<TrainingContent> TrainingContents { get; set; }
        public IEnumerable<TrainingDetail> TrainingDetails { get; set; }

        public List<AcademicYear> DistinctAcademicYears { get; set; }
        public List<(string, SemesterType)> DistinctSemesters { get; set; }
        public List<SemesterType> UniqueSemesters { get; set; }
    }
}
