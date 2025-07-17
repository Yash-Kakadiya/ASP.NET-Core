namespace HMS.Models
{
    public class UserModel
    {
        /*CREATE TABLE [User]
  (
      UserID INT PRIMARY KEY IDENTITY(1,1),
      UserName NVARCHAR(100) NOT NULL,
      Password NVARCHAR(100) NOT NULL,
      Email NVARCHAR(100) NOT NULL,
      MobileNo NVARCHAR(100) NOT NULL,
      IsActive BIT NOT NULL DEFAULT 1,
      Created DATETIME DEFAULT GETDATE(),
      Modified DATETIME NOT NULL
  );
         */


        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }


    }
}
