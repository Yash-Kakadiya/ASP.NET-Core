CREATE TABLE Employee (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(255) UNIQUE,
    PhoneNumber NVARCHAR(20),
    DateOfBirth DATE,
    Gender NVARCHAR(10),
    HireDate DATE NOT NULL,
    JobTitle NVARCHAR(100),
    Department NVARCHAR(100),
    Salary DECIMAL(18,2),
    IsActive BIT DEFAULT 1,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME
);

EXEC PR_Employee_Insert 
    @FirstName = 'Yash',
    @LastName = 'Kakadiya',
    @Email = 'yash@example.com',
    @PhoneNumber = '9876543210',
    @DateOfBirth = '2000-01-01',
    @Gender = 'Male',
    @HireDate = '2025-07-22',
    @JobTitle = 'Software Engineer',
    @Department = 'IT',
    @Salary = 65000.00,
    @IsActive = 1;

CREATE OR Alter PROCEDURE PR_Employee_Insert
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @Email NVARCHAR(255),
    @PhoneNumber NVARCHAR(20) = NULL,
    @DateOfBirth DATE = NULL,
    @Gender NVARCHAR(10) = NULL,
    @HireDate DATE,
    @JobTitle NVARCHAR(100) = NULL,
    @Department NVARCHAR(100) = NULL,
    @Salary DECIMAL(18,2) = NULL,
    @IsActive BIT = 1
AS
BEGIN
    INSERT INTO Employee (FirstName, LastName, Email, PhoneNumber, DateOfBirth, Gender, HireDate, JobTitle, Department, Salary, IsActive, UpdatedAt)
    VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @DateOfBirth, @Gender, @HireDate, @JobTitle, @Department, @Salary, @IsActive,GETDATE());
END;

EXEC PR_Employee_SelectAll;

CREATE OR Alter PROCEDURE PR_Employee_SelectAll
AS
BEGIN
    SELECT * FROM Employee;
END;

EXEC PR_Employee_SelectByID 
    @EmployeeID = 1;

CREATE OR Alter PROCEDURE PR_Employee_SelectByID
    @EmployeeID INT
AS
BEGIN
    SELECT * FROM Employee WHERE EmployeeID = @EmployeeID;
END;

EXEC PR_Employee_Update 
    @EmployeeID = 1,
    @FirstName = 'Yash',
    @LastName = 'Kakadiya',
    @Email = 'yash_updated@example.com',
    @PhoneNumber = '9999988888',
    @DateOfBirth = '2000-01-01',
    @Gender = 'Male',
    @HireDate = '2025-07-22',
    @JobTitle = 'Senior Developer',
    @Department = 'R&D',
    @Salary = 80000.00,
    @IsActive = 1;

CREATE OR Alter PROCEDURE PR_Employee_Update
    @EmployeeID INT,
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @Email NVARCHAR(255),
    @PhoneNumber NVARCHAR(20) = NULL,
    @DateOfBirth DATE = NULL,
    @Gender NVARCHAR(10) = NULL,
    @HireDate DATE,
    @JobTitle NVARCHAR(100) = NULL,
    @Department NVARCHAR(100) = NULL,
    @Salary DECIMAL(18,2) = NULL,
    @IsActive BIT = 1
AS
BEGIN
    UPDATE Employee
    SET FirstName = @FirstName,
        LastName = @LastName,
        Email = @Email,
        PhoneNumber = @PhoneNumber,
        DateOfBirth = @DateOfBirth,
        Gender = @Gender,
        HireDate = @HireDate,
        JobTitle = @JobTitle,
        Department = @Department,
        Salary = @Salary,
        IsActive = @IsActive,
        UpdatedAt = GETDATE()
    WHERE EmployeeID = @EmployeeID;
END;

EXEC DeleteEmployee 
    @EmployeeID = 1;

CREATE OR Alter PROCEDURE PR_Employee_Delete
    @EmployeeID INT
AS
BEGIN
    DELETE FROM Employee WHERE EmployeeID = @EmployeeID;
END;
