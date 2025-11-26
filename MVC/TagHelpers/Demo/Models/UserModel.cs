namespace Demo.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string? UserName { get; set; }
        public IFormFile? Image { get; set; }
        public string? Password { get; set; }
        public int? Age { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public string? Hobbies { get; set; }
        public string? PhoneNo { get; set; }

    }
}
