using System;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Principal;

//    CREATE TABLE Employee(
//    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
//    FirstName NVARCHAR(100) NOT NULL,
//    LastName NVARCHAR(100) NOT NULL,
//    Email NVARCHAR(255) UNIQUE,
//    PhoneNumber NVARCHAR(20),
//    DateOfBirth DATE,
//    Gender NVARCHAR(10),
//    HireDate DATE NOT NULL,
//    JobTitle NVARCHAR(100),
//    Department NVARCHAR(100),
//    Salary DECIMAL(18,2),
//    IsActive BIT DEFAULT 1,
//    CreatedAt DATETIME DEFAULT GETDATE(),
//    UpdatedAt DATETIME
//);
namespace HMS.Models
{
    public class EmployeeModel
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public DateTime HireDate { get; set; }
        public string JobTitle { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}
