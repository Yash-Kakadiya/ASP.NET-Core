namespace HMS.Models
{
    public class PatientModel
    {
        /*
         * 
        CREATE TABLE Patient
        (
            PatientID INT PRIMARY KEY IDENTITY(1,1),
            PatientName NVARCHAR(100) NOT NULL,
            DateOfBirth DATETIME NOT NULL,
            Gender NVARCHAR(10) NOT NULL,
            Email NVARCHAR(100) NOT NULL,
            Phone NVARCHAR(100) NOT NULL,
            Address NVARCHAR(250) NOT NULL,
            City NVARCHAR(100) NOT NULL,
            State NVARCHAR(100) NOT NULL,
            IsActive BIT NOT NULL DEFAULT 1,
            Created DATETIME NOT NULL DEFAULT GETDATE(),
            Modified DATETIME NOT NULL,
            UserID INT NOT NULL,

            CONSTRAINT FK_Patient_User FOREIGN KEY (UserID) REFERENCES [User](UserID)
        );
         */
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public int UserID { get; set; }
    }
}
