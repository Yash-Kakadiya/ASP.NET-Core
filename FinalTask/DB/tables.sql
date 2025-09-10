create database finaltask
use finaltask

CREATE TABLE dbo.Students (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    EnrollmentNo NVARCHAR(50) NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    MobileNo NVARCHAR(20) NOT NULL,
    [Address] NVARCHAR(255) NULL,
    Email NVARCHAR(255) NOT NULL,
    Gender NVARCHAR(10) NOT NULL,
    IsPlayingCricket BIT NOT NULL,
    [Password] NVARCHAR(100) NOT NULL, 
	TwelfthPercentage FLOAT NOT NULL,
    LiveInRajkot BIT NOT NULL
);
