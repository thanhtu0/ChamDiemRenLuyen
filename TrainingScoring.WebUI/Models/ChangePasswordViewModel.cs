using System.ComponentModel.DataAnnotations;

namespace TrainingScoring.WebUI.Models
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu cũ.")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu mới.")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword", ErrorMessage = "Mật khẩu mới không tương khớp.")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Vui lòng xác nhận mật khẩu mới.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
