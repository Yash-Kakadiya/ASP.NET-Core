using System.ComponentModel.DataAnnotations;

namespace FinalTask.Models
{
    public class StudentModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enrollment Number is required.")]
        [Display(Name = "Enrollment No.")]
        public string EnrollmentNo { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Mobile Number is required.")]
        [Display(Name = "Mobile No.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Please enter a valid 10-digit mobile number.")]
        public string MobileNo { get; set; }

        // Address is optional as per the drawing
        public string Address { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }

        [Display(Name = "Playing Cricket?")]
        public bool IsPlayingCricket { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(12, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "12th Percentage is required.")]
        [Range(0, 100, ErrorMessage = "Percentage must be between 0 and 100.")]
        [Display(Name = "12th Percentage")]
        public double TwelfthPercentage { get; set; }

        [Display(Name = "Live in Rajkot?")]
        public bool LiveInRajkot { get; set; }
    }
}

