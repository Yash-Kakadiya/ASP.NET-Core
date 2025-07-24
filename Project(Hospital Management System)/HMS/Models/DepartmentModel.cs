namespace HMS.Models
{
    public class DepartmentModel
    {
        /*
         * CREATE TABLE Department
            (
                DepartmentID INT PRIMARY KEY IDENTITY(1,1),
                DepartmentName NVARCHAR(100) NOT NULL,
                Description NVARCHAR(250) NULL,
                IsActive BIT NOT NULL DEFAULT 1,
                Created DATETIME NOT NULL DEFAULT GETDATE(),
                Modified DATETIME NOT NULL,
                UserID INT NOT NULL,

                CONSTRAINT FK_Department_User FOREIGN KEY (UserID) REFERENCES [User](UserID)
            );
         */
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public int UserID { get; set; }
    }
}
