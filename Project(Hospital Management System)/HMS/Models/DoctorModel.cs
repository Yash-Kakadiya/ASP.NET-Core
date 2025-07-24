using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Data;
using System.Security.Principal;
using System.Xml.Linq;

namespace HMS.Models
{
    public class DoctorModel
    {
        /*
         * CREATE TABLE Doctor
            (
                DoctorID INT PRIMARY KEY IDENTITY(1,1),
                DoctorName NVARCHAR(100) NOT NULL,
                Phone NVARCHAR(20) NOT NULL,
                Email NVARCHAR(100) NOT NULL,
                Qualification NVARCHAR(100) NOT NULL,
                Specialization NVARCHAR(100) NOT NULL,
                IsActive BIT NOT NULL DEFAULT 1,
                Created DATETIME NOT NULL DEFAULT GETDATE(),
                Modified DATETIME NOT NULL,
                UserID INT NOT NULL,

                CONSTRAINT FK_Doctor_User FOREIGN KEY (UserID) REFERENCES [User](UserID)
            );
         */
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Qualification { get; set; }
        public string Specialization { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public int UserID { get; set; }
    }
}
