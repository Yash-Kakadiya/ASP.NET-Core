namespace HMS.Models
{
    public class AppointmentModel
    {
        /*
         * CREATE TABLE Appointment
            (
                AppointmentID INT PRIMARY KEY IDENTITY(1,1),
                DoctorID INT NOT NULL,
                PatientID INT NOT NULL,
                AppointmentDate DATETIME NOT NULL,
                AppointmentStatus NVARCHAR(20) NOT NULL,
                Description NVARCHAR(250) NOT NULL,
                SpecialRemarks NVARCHAR(100) NOT NULL,
                Created DATETIME NOT NULL DEFAULT GETDATE(),
                Modified DATETIME NOT NULL,
                UserID INT NOT NULL,
                TotalConsultedAmount DECIMAL(5,2) NULL,

                CONSTRAINT FK_Appointment_Doctor FOREIGN KEY (DoctorID) REFERENCES Doctor(DoctorID),
                CONSTRAINT FK_Appointment_Patient FOREIGN KEY (PatientID) REFERENCES Patient(PatientID),
                CONSTRAINT FK_Appointment_User FOREIGN KEY (UserID) REFERENCES [User](UserID)
            );
         */
        public int AppointmentID { get; set; }
        public int DoctorID { get; set; }
        public int PatientID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string AppointmentStatus { get; set; }
        public string Description { get; set; }
        public string SpecialRemarks { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public int UserID { get; set; }
        public decimal? TotalConsultedAmount { get; set; }

    }
}
