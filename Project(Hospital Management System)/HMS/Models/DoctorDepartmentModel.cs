namespace HMS.Models
{
    public class DoctorDepartmentModel
    {
        /*
         * CREATE TABLE DoctorDepartment
            (
                DoctorDepartmentID INT PRIMARY KEY IDENTITY(1,1),
                DoctorID INT NOT NULL,
                DepartmentID INT NOT NULL,
                Created DATETIME NOT NULL DEFAULT GETDATE(),
                Modified DATETIME NOT NULL,
                UserID INT NOT NULL,

                CONSTRAINT FK_DoctorDepartment_Doctor FOREIGN KEY (DoctorID) REFERENCES Doctor(DoctorID),
                CONSTRAINT FK_DoctorDepartment_Department FOREIGN KEY (DepartmentID) REFERENCES Department(DepartmentID),
                CONSTRAINT FK_DoctorDepartment_User FOREIGN KEY (UserID) REFERENCES [User](UserID)
            );
         */

        public int DoctorDepartmentID { get; set; }
        public int DoctorID { get; set; }
        public int DepartmentID { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public int UserID { get; set; }
    }
}
